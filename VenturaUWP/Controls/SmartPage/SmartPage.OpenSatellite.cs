using System;
using Ventura.Navigation;
using Ventura.Shell;
using Windows.UI.Xaml.Controls;

namespace Ventura.Controls
{
    public partial class SmartPage : ContentControl
    {

        public void OpenSatellite(string tab_caption, string page_caption, SmartPage page2open, string instance_id = null)
        {

            if (instance_id != null && instance_id.Contains("/"))
                throw new ArgumentException("The instance_id cannot contain a '/' character.");

            if (instance_id == null)
                instance_id = Guid.NewGuid().ToString();

            var shelldata = Navigator.ShellData;

            if (shelldata.ManagesSmartPage(this) == false)
                throw new InvalidOperationException("This Page object is not managed by the Ventura Navigator.");

            // Since the page is managed, we are 100% sure the FrameData and TabData will also be found.

            TabData tabdata_this = shelldata.FindTabData(this);
            FrameData framedata_this = shelldata.FindFrameData(this);

            if (tabdata_this.TopMost() != this)
                throw new InvalidOperationException("Only call OpenSatellite from the topmost Page object.");

            // Create a unique ID for the satellite tab. For example:
            // MASTERPAGE_UNIQUE_ID + "/" + "COUNTRIESLIST_PAGE" + "/" "INTERNAL ID"
            // MASTERPAGE_UNIQUE_ID + "/" + "ORDERSTATUSLIST_PAGE" + "/" "INTERNAL ID

            string unique_id = tabdata_this.UniqueID + "/" + page2open.GetType().FullName + "/" + instance_id;

            // Check if a tab with the unique_id is already open.
            var found = shelldata.FindTabData(m => m.UniqueID == unique_id);

            // If the tab is found, then select the tab and make it active
            if (found != null)
            {
                var frame = shelldata.FindFrameData(found);
                frame.SelectedTab = found;
                shelldata.ActiveFrameIndex = frame.Index;
                return;
            }

            // A satellite page is guaranteed not to have satellite pages itself.
            //
            // If this tab is a satellite tab, it is not possible to open another satellite.
            // This is to prevent a tab from becoming both master and satellite at the same time.
            //
            // MASTER       LINKED
            //              MASTER      LINKED
            //                          MASTER        LINKED
            // orders1 ---> order1 ---> orders2 ----> order2
            //
            // Even though we asked for the page to be opened as a satellite page, it will be opened as a modal instead.
            // The return value however, will be received in the SatellitePageClosed event by the caller.
            //

            if (tabdata_this.IsSatellite == true)
            {
                // Open the page as a 'modal' overlay.
                page2open.IsModal = true;
                page2open.PageCaption = page_caption;
                page2open.CloseAction = CloseActionKind.CloseModal_SatelliteClosedEventOnParentPage;
                page2open.InstanceID = instance_id;

                tabdata_this.PushPage(page2open);

                return;
            }

            page2open.CloseAction = CloseActionKind.CloseTab_With_SatelliteClosedEventOnMasterTab;
            page2open.InstanceID = instance_id;

            // Is Left, then right..
            // Is right, then left...
            int opposite_frameindex = 0;

            if (framedata_this.Index == 0)
                opposite_frameindex = 1;

            // Make sure the screen is split
            shelldata.SplitScreen = true;

            // Activate
            shelldata.ActiveFrameIndex = opposite_frameindex;

            // The new tab
            FrameData framedata_satellite = shelldata.Frames[opposite_frameindex];
            var tabs = framedata_satellite.Tabs;

            TabData tabdata_satellite = new TabData(tab_caption, page_caption, page2open, tabdata_this.ColorInfo, unique_id);

            // Keep satellite tabs of the same mastertab together.
            int insertindex = -1;

            for (int i = tabs.Count - 1; i >= 0; i--)
            {
                if (tabs[i].MasterTabID == tabdata_this.UniqueID)
                {
                    insertindex = i + 1;
                    break;
                }
            }

            if (insertindex == -1)
                framedata_satellite.Tabs.Add(tabdata_satellite);
            else
                framedata_satellite.Tabs.Insert(insertindex, tabdata_satellite);

            // Make the new tab selected.
            framedata_satellite.SelectedTab = tabdata_satellite;
        }

    }

}
