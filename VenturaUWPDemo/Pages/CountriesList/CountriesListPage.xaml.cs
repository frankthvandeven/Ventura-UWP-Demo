using Demo.VenturaAutoCreate;
using Ventura.Controls;
using Windows.UI.Xaml;

namespace Demo.Pages
{
    public sealed partial class CountriesListPage : SmartPage
    {
        public CountriesListViewmodel Viewmodel { get; }
        public GetAll_CountryCodes_Recordset _CountriesRS { get; } = new GetAll_CountryCodes_Recordset();

        public CountriesListPage(CountriesListViewmodel view_model)
        {
            Viewmodel = view_model != null ? view_model : new CountriesListViewmodel(CountriesListViewmodel.ModeKind.List);

            this.InitializeComponent();
        }

        protected override void OnPageOpened()
        {
            _CountriesRS.MaxRows = 1000; // 500;
            _CountriesRS.ExecSql();

            DataGrid.ItemsSource = _CountriesRS;

            _CountriesRS.FindAndSelectAsCurrent(r => r.CountryCodeID == Viewmodel.Input_CountryCodeID);
        }

        private void DataGrid_RowClicked(object sender, RowClickedEventArgs e)
        {

        }

        private void DataGrid_RowRightClicked(object sender, RowRightClickedEventArgs e)
        {
        }

        private void Btn_Select_Click(object sender, RoutedEventArgs e)
        {
            this.ClosePage(DataGrid.SelectedItem);
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.ScrollSelectedIntoView();

        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
