using System;
using System.Threading.Tasks;
using Ventura.Navigation;
using Ventura.Shell;
using Windows.UI.Xaml.Controls;

namespace Ventura.Controls
{
    public partial class SmartPage : ContentControl
    {

        // Page Open Transition:
        // http://amadeusw.com/xaml/animated-navigation-universal-app

        /// <summary>
        /// Opens a page as an overlay. It must be closed to return to the page that opened it.
        /// </summary>
        public async Task<object> OpenModal(string page_caption, SmartPage page2open)
        {
            ShellData shell_data = Navigator.ShellData;

            if (shell_data.ManagesSmartPage(this) == false)
                throw new InvalidOperationException("This Page object is not managed by the Ventura Navigator.");

            // Since the page is managed, we are 100% sure the FrameData and TabData will also be found.

            TabData tabdata = shell_data.FindTabData(this);

            if (tabdata.TopMost() != this)
                throw new InvalidOperationException("Only call OpenModal for the topmost Page object.");

            Navigator.CloseAllSatelliteTabs(tabdata.UniqueID);

            page2open.IsModal = true;
            page2open.PageCaption = page_caption;
            page2open.CloseAction = CloseActionKind.ReleaseTCS;
            page2open.TCS = new TaskCompletionSource<object>();

            // PushPage MUST come before the await.
            tabdata.PushPage(page2open);

            object result = await page2open.TCS.Task;

            return result;

            //await Task.CompletedTask; // Dummy task
        }


    }
}
