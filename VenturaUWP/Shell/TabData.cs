using System;
using System.Collections.ObjectModel;
using Ventura.Controls;
using Ventura.Helpers;

namespace Ventura.Shell
{
    /// <summary>
    /// This is the viewmodel for a single Tab.
    /// </summary>
    public class TabData : ViewmodelBase
    {
        public delegate void PagePushedEventDelegate(SmartPage oldpage, SmartPage newpage);
        public delegate void PagePoppedEventDelegate(SmartPage oldpage, SmartPage newpage);
        public event PagePushedEventDelegate PagePushedEvent;
        public event PagePoppedEventDelegate PagePoppedEvent;

        private ObservableCollection<SmartPage> _pages;
        private string _tab_caption;
        private string _unique_id;
        private DistinctColorInfo _colorinfo;
        private bool _is_selected;
        private bool _is_linked_active = false;

        internal TabData(string tab_caption, string page_caption, SmartPage page, DistinctColorInfo colorinfo, string unique_id)
        {
            if (unique_id == null || unique_id.Length == 0)
                throw new ArgumentOutOfRangeException("a unique_id must be specified");

            _tab_caption = tab_caption;
            _colorinfo = colorinfo;
            _unique_id = unique_id;
            _is_selected = false;

            _pages = new ObservableCollection<SmartPage>();

            page.PageCaption = page_caption;

            _pages.Add(page);
        }

        public string UniqueID
        {
            get { return _unique_id; }
        }

        /// <summary>
        /// The unique ID of the tab that is the master of this tab.
        /// For satellite tab support.
        /// </summary>
        public string MasterTabID
        {
            get
            {
                string[] parts = _unique_id.Split('/');

                if (parts.Length == 1)
                    return null;

                return parts[0];
            }
        }

        public bool IsSatellite
        {
            get { return _unique_id.Contains("/"); }
        }

        public DistinctColorInfo ColorInfo
        {
            get { return _colorinfo; }
        }

        /// <summary>
        /// Returns true when this tab, or a linked tab is both Selected and Active.
        /// </summary>
        public bool IsLinkedActive
        {
            get { return _is_linked_active; }
            internal set
            {
                if (_is_linked_active == value) return;

                _is_linked_active = value;

                NotifyPropertyChanged(nameof(IsLinkedActive));
            }
        }

        public bool IsSelected
        {
            get { return _is_selected; }
            internal set
            {
                if (_is_selected == value) return;

                _is_selected = value;

                NotifyPropertyChanged(nameof(IsSelected));
            }
        }

        /// <summary>
        /// Adds the Page to the stack and makes it visible.
        /// (sets the Page as the Content property).
        /// </summary>
        internal void PushPage(SmartPage newpage)
        {
            SmartPage oldpage = this.TopMost();

            _pages.Add(newpage);

            PagePushedEvent?.Invoke(oldpage, newpage);

            NotifyPropertyChanged(nameof(PageStack));
        }

        /// <summary>
        /// Removes the topmost Page from the stack and makes the previous Page visible. 
        /// (sets the previous Page as the Content property).
        /// The stack must contain at least 2 Pages when calling this method. 
        /// </summary>
        internal void PopPage()
        {
            if (_pages.Count == 0)
                throw new InvalidOperationException("The stack must contain at least 1 SmartPage");

            SmartPage oldpage = this.TopMost();

            _pages.RemoveAt(_pages.Count - 1); // Remove the last one.

            SmartPage newpage = this.TopMost();

            PagePoppedEvent?.Invoke(oldpage, newpage);

            NotifyPropertyChanged(nameof(PageStack));
        }

        public ObservableCollection<SmartPage> PageStack
        {
            get { return _pages; }
        }

        public SmartPage TopMost()
        {
            if (_pages.Count == 0)
                return null;

            return _pages[_pages.Count - 1];
        }

        internal void CloseAllPagesAtOnce()
        {
            for (int i = _pages.Count - 1; i >= 0; i--)
            {
                SmartPage page = _pages[i];

                page.ClosePage(null);

                //if (page.TCS != null)
                //    page.TCS.SetResult(null);
            }

            if (_pages.Count > 0)
                throw new Exception("should not happen");

            NotifyPropertyChanged(nameof(PageStack));
        }

        /// <summary>
        /// Returns true if the ModalStack contains the referenced Page.
        /// </summary>
        public bool ContainsPage(SmartPage page)
        {
            foreach (SmartPage item in _pages)
                if (item.Equals(page))
                    return true;

            return false;
        }

        public string Caption
        {
            get { return _tab_caption; }
            set
            {
                if (_tab_caption == value)
                    return;

                _tab_caption = value;

                NotifyPropertyChanged(nameof(Caption));

            }
        }

        /// <summary>
        /// Forces a repaint of the BreadCrumb
        /// </summary>
        internal void RefreshBreadCrumb()
        {
            for (int i = 0; i < _pages.Count; i++)
            {
                _pages[i] = _pages[i];
            }

        }

    }
}
