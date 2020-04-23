using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using Ventura.Controls;

namespace Ventura.Shell
{
    public class FrameData : ViewmodelBase
    {
        //public delegate void TabSelectedEventDelegate(TabData tab);
        //public event TabSelectedEventDelegate TabSelectedEvent;

        //public delegate void TabDeselectedEventDelegate(TabData tab);
        //public event TabDeselectedEventDelegate TabDeselectedEvent;

        public delegate void DisplayAnotherPageEventDelegate(PageDisplayReason reason, SmartPage page);
        public event DisplayAnotherPageEventDelegate DisplayAnotherPageEvent;

        public delegate void ShelvePageEventDelegate(SmartPage page);
        public event ShelvePageEventDelegate ShelvePageEvent;

        public event Action FrameActivatedEvent;
        public event Action FrameDeActivatedEvent;

        private ObservableCollection<TabData> _tabs;
        private TabData _selected_tab;
        private bool _is_frame_activated;
        private int _index;
        private bool _allow_drop;

        public FrameData(int index)
        {
            _index = index;
            _selected_tab = null;
            _tabs = new ObservableCollection<TabData>();
            _is_frame_activated = false;
            _allow_drop = false;
        }

        public void SmartRemoveTab(TabData tab)
        {
            if (tab == null)
                throw new ArgumentNullException();

            int last_selected_tabindex = -1;

            for (int i = 0; i < _tabs.Count; i++)
            {
                if (_tabs[i].Equals(tab))
                {
                    last_selected_tabindex = i;
                    break;
                }
            }

            _tabs.Remove(tab);

            if (_tabs.Count == 0)
                return;

            if (_tabs.Count > last_selected_tabindex && last_selected_tabindex != -1)
                this.SelectedTab = _tabs[last_selected_tabindex];
            else
                this.SelectedTab = _tabs[_tabs.Count - 1];

        }

        /// <summary>
        /// 0 = Left frame, 1 = Right frame
        /// </summary>
        public int Index
        {
            get { return _index; }
        }

        public ObservableCollection<TabData> Tabs
        {
            get { return _tabs; }
        }


        public TabData SelectedTab
        {
            get { return _selected_tab; }
            set
            {
                if (_selected_tab == value) return;

                if (_selected_tab != null)
                {
                    SmartPage topmost = _selected_tab.TopMost();

                    if (topmost != null)
                    {
                        ShelvePageEvent?.Invoke(topmost);
                    }
                }

                // Reset the IsSelected flag for the individual tabs.
                foreach (var tab in _tabs)
                {
                    bool is_selected = tab.Equals(value);
                    tab.IsSelected = is_selected;
                }

                if (_selected_tab != null)
                {
                    _selected_tab.PagePushedEvent -= CurrentlySelectedTab_PagePushedEvent;
                    _selected_tab.PagePoppedEvent -= CurrentlySelectedTab_PagePoppedEvent;
                }

                _selected_tab = value;

                if (_selected_tab != null)
                {
                    _selected_tab.PagePushedEvent += CurrentlySelectedTab_PagePushedEvent;
                    _selected_tab.PagePoppedEvent += CurrentlySelectedTab_PagePoppedEvent;
                }

                NotifyPropertyChanged(nameof(SelectedTab));
                NotifyPropertyChanged(nameof(CurrentPageStack));

                if (_selected_tab != null)
                {
                    SmartPage topmost = _selected_tab.TopMost();

                    if (topmost != null)
                    {
                        DisplayAnotherPageEvent?.Invoke(PageDisplayReason.TabSelect, topmost);
                    }
                }

            }
        }

        private void CurrentlySelectedTab_PagePushedEvent(SmartPage oldpage, SmartPage newpage)
        {
            ShelvePageEvent?.Invoke(oldpage);
            DisplayAnotherPageEvent?.Invoke(PageDisplayReason.PushPage, newpage);
        }

        private void CurrentlySelectedTab_PagePoppedEvent(SmartPage oldpage, SmartPage newpage)
        {
            ShelvePageEvent?.Invoke(oldpage);

            DisplayAnotherPageEvent?.Invoke(PageDisplayReason.PopPage, newpage);
        }

        /// <summary>
        /// Get/set the activation of the Frame.
        /// </summary>
        public bool IsActivated
        {
            get { return _is_frame_activated; }
            internal set
            {
                if (_is_frame_activated == value) return;

                _is_frame_activated = value;

                NotifyPropertyChanged(nameof(IsActivated));

                if (_is_frame_activated)
                    FrameActivatedEvent?.Invoke();
                else
                    FrameDeActivatedEvent?.Invoke();
            }
        }

        public bool AllowDrop
        {
            get { return _allow_drop; }
            internal set
            {
                if (_allow_drop == value) return;

                _allow_drop = value;

                NotifyPropertyChanged(nameof(AllowDrop));
            }
        }

        /// <summary>
        /// Depends of the SelectedTab. Used by the BreadCrumb control.
        /// </summary>
        public ObservableCollection<SmartPage> CurrentPageStack
        {
            get
            {
                if (_selected_tab == null)
                    return null;

                return _selected_tab.PageStack;
            }
        }

        public enum PageDisplayReason
        {
            TabSelect,
            PushPage,
            PopPage
        }

    }
}
