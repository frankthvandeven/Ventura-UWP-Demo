using System;
using Ventura.Navigation;
using Ventura.Shell;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Ventura.Controls
{
    public sealed partial class TabbedFrame : UserControl
    {

        private void TabStrip_DragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            var data = e.Data;

            TabData tab_data = this.TabStrip.SelectedItem as TabData;

            if (tab_data == null) return;

            data.SetText(tab_data.UniqueID);

            data.RequestedOperation = DataPackageOperation.Move;

            FrameData framedata = Navigator.ShellData.FindFrameData(tab_data);

            if (framedata.Index == 0)
            {
                Navigator.ShellData.Frames[0].AllowDrop = false;
                Navigator.ShellData.Frames[1].AllowDrop = true;
            }
            else // 1
            {
                Navigator.ShellData.Frames[0].AllowDrop = true;
                Navigator.ShellData.Frames[1].AllowDrop = false;
            }

            Navigator.ShellData.SplitScreen = true;
        }

        private void UserControl_DragOver(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text) == false)
            {
                e.AcceptedOperation = DataPackageOperation.None;
                return;
            }

            e.AcceptedOperation = DataPackageOperation.Move;
        }

        private async void UserControl_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text) == false) return;

            // We need to take a Deferral as we won't be able to confirm the end of the operation synchronously.
            DragOperationDeferral def = e.GetDeferral();

            string unique_id = await e.DataView.GetTextAsync(StandardDataFormats.Text) as string;

            if (unique_id == null)
                throw new Exception("TabbedFrame drop operation failed. Did not receive a unique ID.");

            e.AcceptedOperation = DataPackageOperation.Move;

            def.Complete();

            Navigator.MoveTab(unique_id, this.ViewModel);

            // A drop should activate the TabbedFrame too.
            Navigator.ShellData.ActiveFrameIndex = ViewModel.Index;
        }

        private void TabStrip_DragItemsCompleted(ListViewBase sender, DragItemsCompletedEventArgs args)
        {
            if (Navigator.ShellData.Frames[1].Tabs.Count == 0)
            {
                Navigator.ShellData.SplitScreen = false;
            }

        }

    }
}

