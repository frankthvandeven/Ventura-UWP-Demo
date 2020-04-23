using System.IO;
using System.Threading.Tasks;
using Demo.Helpers;
using Microsoft.Data.Sqlite;
using Ventura;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using Windows.UI.Xaml;


namespace Demo
{
    // Test database: http://www.bcfi.be/nl/download

    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            this.UnhandledException += App_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            // Occurs when an exception is not handled on a background thread.
            // ie. A task is fired and forgotten Task.Run(() => {...})


            // suppress and handle it manually.
            e.SetObserved();
        }

        private void App_UnhandledException(object sender, Windows.UI.Xaml.UnhandledExceptionEventArgs e)
        {
            // Occurs when an exception is not handled on the UI thread.


            // if you want to suppress and handle it manually, 
            // otherwise app shuts down.
            e.Handled = true;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {
            await ConfigureAsync();

            VenturaApplication.OnLaunched(typeof(MainPage), e);
        }

        //protected override void OnActivated(IActivatedEventArgs args)
        //{

        //    var oo = args.Kind;
        //}

        protected override void OnBackgroundActivated(BackgroundActivatedEventArgs args)
        {
            base.OnBackgroundActivated(args);
        }


        public async Task ConfigureAsync()
        {
            // Restore the VanArsdel.db SQLite database.
            await DatabaseHelper.RestoreDatabaseFile(false);

            string db_folder = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Database");

            string connection_string = $@"Data Source={db_folder}\VanArsdel.db";

            VenturaConfig.DefaultConnector = new AdoConnector(SqliteFactory.Instance, connection_string);

        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
