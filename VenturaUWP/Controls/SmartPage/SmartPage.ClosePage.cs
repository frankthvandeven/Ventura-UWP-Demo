using System;
using Ventura.Navigation;
using Ventura.Shell;
using Windows.UI.Xaml.Controls;

namespace Ventura.Controls
{
    public partial class SmartPage : ContentControl
    {

        /// <summary>
        /// Close the Modal page or close the Tab.
        /// </summary>
        public void ClosePage(object retvar = null)
        {
            ShellData shell_data = Navigator.ShellData;

            if (shell_data.ManagesSmartPage(this) == false)
                throw new InvalidOperationException("This Page object is not managed by the Ventura Navigator.");

            // Find the tab that holds the page in its modalstack.
            TabData tabdata = shell_data.FindTabData(this);

            if (tabdata.TopMost() != this)
                throw new InvalidOperationException("Only call CloseModal for the topmost Page object.");

            Navigator.CloseAllSatelliteTabs(tabdata.UniqueID);

            tabdata.PopPage();

            // The topmost will be null if no pages left on the stack.
            var topmost = tabdata.TopMost();

            if (this.CloseAction == CloseActionKind.CloseTab)
            {
                Navigator.InternalCloseTab(tabdata);
            }
            else if (this.CloseAction == CloseActionKind.ReleaseTCS)
            {
                this.TCS.SetResult(retvar);
            }
            else if (this.CloseAction == CloseActionKind.CloseTab_With_SatelliteClosedEventOnMasterTab)
            {
                Navigator.InternalCloseTab(tabdata);

                TabData tabdata_master = shell_data.FindTabData(tabdata.MasterTabID);

                if (tabdata_master != null)
                {
                    FrameData framedata_master = shell_data.FindFrameData(tabdata_master);

                    // Make the frame containing the master page (for the satellite page) active.
                    shell_data.ActiveFrameIndex = framedata_master.Index;

                    // Make the master page the selected tab.
                    framedata_master.SelectedTab = tabdata_master;

                    SmartPage topmost_master = tabdata_master.TopMost();

                    if (topmost_master != null)
                        topmost_master.SatellitePageClosed(this.InstanceID, retvar);
                }

            }
            else if (this.CloseAction == CloseActionKind.CloseModal_SatelliteClosedEventOnParentPage)
            {
                topmost.SatellitePageClosed(this.InstanceID, retvar);
                //await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => topmost.SatellitePageClosed(this.InstanceID, retvar));

            }

        }

    }

    public enum CloseActionKind
    {
        CloseTab,
        ReleaseTCS,
        CloseTab_With_SatelliteClosedEventOnMasterTab,
        CloseModal_SatelliteClosedEventOnParentPage
    }

}
