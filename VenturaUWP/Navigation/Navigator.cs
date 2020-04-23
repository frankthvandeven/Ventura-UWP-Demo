using System;
using Ventura.Controls;
using Ventura.Helpers;
using Ventura.Shell;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace Ventura.Navigation
{
    /// <summary>
    /// The Page navigation system.
    /// </summary>
    public static partial class Navigator
    {
        private static DistinctColors _colors;
        private static ShellData _shell_data;

        static Navigator()
        {
            _colors = new DistinctColors();
            _shell_data = new ShellData();
        }

        public static ShellData ShellData
        {
            get { return _shell_data; }
        }

        public static TabData AddTab(string tab_caption, string page_caption, SmartPage page, string unique_id = null)
        {
            // The active frame can be found at: _shell_data.ActiveFrameIndex
            return AddTab(tab_caption, page_caption, page, 0, unique_id);
        }

        public static TabData AddTab(string tab_caption, string page_caption, SmartPage page2open, int frame_index, string unique_id = null)
        {
            if (unique_id != null)
            {
                if (unique_id.Contains("/"))
                    throw new ArgumentException("The unique_id cannot contain a '/' character.");

                var found = _shell_data.FindTabData(m => m.UniqueID != null && m.UniqueID == unique_id);

                if (found != null)
                {
                    var frame = _shell_data.FindFrameData(found);
                    frame.SelectedTab = found;
                    _shell_data.ActiveFrameIndex = frame.Index;
                    return found;
                }
            }

            if (unique_id == null)
            {
                unique_id = Guid.NewGuid().ToString();
            }

            if (frame_index < 0 || frame_index >= _shell_data.Frames.Count)
                throw new ArgumentOutOfRangeException($"frame_index must be a number between 0 and {_shell_data.Frames.Count - 1}.");

            // Make sure the screen is split
            if (frame_index == 1)
                _shell_data.SplitScreen = true;

            _shell_data.ActiveFrameIndex = frame_index;

            FrameData frame_data = _shell_data.Frames[frame_index];

            var color_info = _colors.GetNextColor();

            TabData tabdata = new TabData(tab_caption, page_caption, page2open, color_info, unique_id);

            frame_data.Tabs.Add(tabdata);
            frame_data.SelectedTab = tabdata;

            //await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => frame_data.SelectedTab = tabdata);

            return tabdata;
        }

        /// <summary>
        /// Closes all the satellite tabs for the specified unique_id.
        /// </summary>
        internal static void CloseAllSatelliteTabs(string unique_id)
        {
            if (unique_id == null)
                throw new ArgumentNullException("unique_id");

            // if the unique_id contains a forward-slash, it means that the ID is from a satellite page.
            if (unique_id.Contains("/"))
                return; //throw new ArgumentException("The unique_id cannot contain the '/' character.");

            foreach (FrameData frame in _shell_data.Frames)
                for (int i = frame.Tabs.Count - 1; i >= 0; i--)
                {
                    TabData tabdata = frame.Tabs[i];

                    if (tabdata.IsSatellite && tabdata.MasterTabID == unique_id)
                    {
                        tabdata.CloseAllPagesAtOnce(); // This includes closing the tab with InternalCloseTab().
                        //InternalCloseTab(tabdata);
                    }
                }

        }

        public static void CloseTab(SmartPage page)
        {
            if (_shell_data.ManagesSmartPage(page) == false)
                throw new InvalidOperationException("This Page object is not managed by the Ventura Navigator.");

            // Since the page is managed, we are 100% sure the FrameData and TabData will also be found.

            TabData tabdata = _shell_data.FindTabData(page);

            CloseAllSatelliteTabs(tabdata.UniqueID);

            tabdata.CloseAllPagesAtOnce();
        }

        public static void InternalCloseTab(TabData tabdata)
        {
            if (tabdata.PageStack.Count > 0)
                throw new InvalidOperationException("Close all the pages first before calling CloseTab.");

            FrameData framedata = _shell_data.FindFrameData(tabdata);

            if (framedata == null)
                throw new InvalidOperationException("The tabdata is not managed by the Ventura Navigator.");

            framedata.SmartRemoveTab(tabdata);

            if (framedata.Index == 1 && framedata.Tabs.Count == 0)
            {
                _shell_data.SplitScreen = false;
                _shell_data.ActiveFrameIndex = 0;
            }

        }

        /// <summary>
        /// Move a TabData object with the specified UniqueID to another FrameData.
        /// This method is only called by the drop method of the TabbedFrame control.
        /// </summary>
        internal static void MoveTab(string unique_id, FrameData framedata_target)
        {
            bool found = false;
            FrameData framedata_source = null;
            TabData tabdata_source = null;

            foreach (FrameData frame_data in _shell_data.Frames)
                foreach (TabData tab_data in frame_data.Tabs)
                    if (tab_data.UniqueID == unique_id)
                    {
                        found = true;
                        framedata_source = frame_data;
                        tabdata_source = tab_data;
                        goto Done;
                    }

                Done:

            if (found == false) throw new Exception($"Tab with UniqueID {unique_id} not found.");

            //await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
            //{
            //});

            framedata_source.IsActivated = false;
            framedata_source.SmartRemoveTab(tabdata_source);

            framedata_target.Tabs.Add(tabdata_source);
            framedata_target.SelectedTab = tabdata_source;
            framedata_target.IsActivated = true;


        }

        public static bool IsTabOpen(string unique_id)
        {
            if (unique_id == null)
                throw new ArgumentNullException();

            var found = _shell_data.FindTabData(m => m.UniqueID != null && m.UniqueID == unique_id);

            return (found != null);
        }

        public static void SelectAndActivateTab(string unique_id)
        {
            if (unique_id == null)
                throw new ArgumentNullException();

            var found = _shell_data.FindTabData(m => m.UniqueID != null && m.UniqueID == unique_id);

            if (found == null)
                throw new InvalidOperationException($"There is no tab with unique id {unique_id}");

            // Since the tabdata was found, we are 100% sure to find the frame too.
            var frame = _shell_data.FindFrameData(found);

            frame.SelectedTab = found;

            _shell_data.ActiveFrameIndex = frame.Index;
        }

    }
}
