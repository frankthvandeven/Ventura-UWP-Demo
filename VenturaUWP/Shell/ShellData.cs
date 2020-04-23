using System;
using System.Collections.ObjectModel;
using Ventura.Controls;

namespace Ventura.Shell
{
    public class ShellData : ViewmodelBase
    {
        private ObservableCollection<FrameData> _frames;
        private int _active_frame_index;
        private bool _splitscreen;


        public ShellData()
        {
            _active_frame_index = -1; // no frame activated
            _splitscreen = false;

            _frames = new ObservableCollection<FrameData>();

            _frames.Add(new FrameData(0));
            _frames.Add(new FrameData(1));

            _frames[0].PropertyChanged += FrameData_PropertyChanged;
            _frames[1].PropertyChanged += FrameData_PropertyChanged;
        }

        private void FrameData_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedTab")
                Update_TabData_IsLinked();
        }

        public bool SplitScreen
        {
            get { return _splitscreen; }
            set
            {
                if (_splitscreen == value) return;

                if (value == false && _frames[1].Tabs.Count > 0)
                {
                    throw new Exception("Closing the right frame of a splitscreen that still has tabs open is not allowed.");
                }

                _splitscreen = value;

                NotifyPropertyChanged(nameof(SplitScreen));
            }
        }

        public int ActiveFrameIndex
        {
            get { return _active_frame_index; }
            internal set
            {
                if (_active_frame_index == value) return;

                if (value == -1)
                {
                    _frames[0].IsActivated = false;
                    _frames[1].IsActivated = false;
                }
                else if (value == 0)
                {
                    _frames[1].IsActivated = false;
                    _frames[0].IsActivated = true;
                }
                else if (value == 1)
                {
                    _frames[0].IsActivated = false;
                    _frames[1].IsActivated = true;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("ActiveFrameIndex value must be -1, 0 or 1");
                }

                _active_frame_index = value;

                NotifyPropertyChanged(nameof(ActiveFrameIndex));

                Update_TabData_IsLinked();
            }
        }

        public ObservableCollection<FrameData> Frames
        {
            get { return _frames; }
        }

        public FrameData FindFrameData(SmartPage page)
        {
            foreach (FrameData framedata in _frames)
                foreach (TabData tabdata in framedata.Tabs)
                    if (tabdata.ContainsPage(page) == true)
                        return framedata;

            return null;
        }

        public FrameData FindFrameData(TabData find)
        {
            foreach (FrameData framedata in _frames)
                foreach (TabData tabdata in framedata.Tabs)
                    if (tabdata.Equals(find))
                        return framedata;

            return null;
        }



        public TabData FindTabData(SmartPage page)
        {
            foreach (FrameData framedata in _frames)
                foreach (TabData tabdata in framedata.Tabs)
                    if (tabdata.ContainsPage(page) == true)
                        return tabdata;

            return null;
        }
        
        public TabData FindTabData(Predicate<TabData> match)
        {
            foreach (FrameData framedata in _frames)
                foreach (TabData tabdata in framedata.Tabs)
                    if (match(tabdata))
                        return tabdata;

            return null;
        }

        public TabData FindTabData(string unique_id)
        {
            if (unique_id == null)
                throw new ArgumentNullException("unique_id");

            foreach (FrameData framedata in _frames)
                foreach (TabData tabdata in framedata.Tabs)
                    if (tabdata.UniqueID == unique_id)
                        return tabdata;

            return null;
        }

        /// <summary>
        /// Returns true if the SmartPage is managed by Ventura's Navigator.
        /// </summary>
        public bool ManagesSmartPage(SmartPage page)
        {
            foreach (FrameData framedata in _frames)
                foreach (TabData tabdata in framedata.Tabs)
                    foreach (SmartPage page_item in tabdata.PageStack)
                        if (page_item.Equals(page) == true)
                            return true;

            return false;
        }

        public void Update_TabData_IsLinked()
        {
            TabData active_and_selected_tab = FindActiveAndSelectedTab();

            if (active_and_selected_tab == null)
            {
                ResetLinkedActive();
                return;
            }

            string id;

            if (active_and_selected_tab.IsSatellite == false)
            {
                id = active_and_selected_tab.UniqueID;

                // A page with satellites is a master-page.
                int count = SatelliteCount(id);

                if (count == 0)
                {
                    ResetLinkedActive();
                    return;
                }

            }
            else
            {
                id = active_and_selected_tab.MasterTabID;
            }

            foreach (FrameData framedata in _frames)
                foreach (TabData tabdata in framedata.Tabs)
                {
                    if (tabdata.MasterTabID != null && tabdata.MasterTabID == id)
                        tabdata.IsLinkedActive = true;
                    else if (tabdata.UniqueID == id)
                        tabdata.IsLinkedActive = true;
                    else
                        tabdata.IsLinkedActive = false;
                }
        }

        private void ResetLinkedActive()
        {
            foreach (FrameData framedata in _frames)
                foreach (TabData tabdata in framedata.Tabs)
                    tabdata.IsLinkedActive = false;
        }



        private int SatelliteCount(string id)
        {
            int count = 0;

            foreach (FrameData framedata in _frames)
                foreach (TabData tabdata in framedata.Tabs)
                    if (tabdata.MasterTabID != null && tabdata.MasterTabID == id)
                        count++;

            return count;
        }

        private TabData FindActiveAndSelectedTab()
        {
            if (_active_frame_index == -1)
                return null;

            FrameData frame = _frames[_active_frame_index];

            if (frame.SelectedTab == null)
                return null;

            return frame.SelectedTab;
        }

    }
}