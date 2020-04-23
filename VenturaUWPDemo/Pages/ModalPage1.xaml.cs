using Ventura.Controls;
using Windows.UI.Xaml;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Demo.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ModalPage1 : SmartPage
    {
        public ModalPage1()
        {
            this.InitializeComponent();

            this.Loaded += ModalPage1_Loaded;
            this.Unloaded += ModalPage1_Unloaded;
        }

        private void ModalPage1_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        private void ModalPage1_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.ClosePage(101);
        }

        private void BtnSetCaption_Click(object sender, RoutedEventArgs e)
        {
            PageCaption = TitleText.Text;
        }

        private async void BtnOpenModal_Click(object sender, RoutedEventArgs e)
        {
            await this.OpenModal("Another modal", new ModalPage1());
        }

        protected override void OnActivated()
        {
        }

        protected override void OnDeActivated()
        {
        }

    }
}
