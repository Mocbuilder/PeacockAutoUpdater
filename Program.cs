namespace PeacockAutoUpdater
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool noDownload = false;
            if (args != null && args.Length > 0)
            {
                for(int i = 0; i < args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "-noDownload":
                            noDownload = true;
                            break;
                        case "-newConfig":
                            File.Delete("config.json");
                            break;
                    }
                }
            }

            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(noDownload));
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            LogAndShowException(e.Exception, "UI Thread Error");
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                LogAndShowException(ex, "Background Thread Error");
            }
        }

        private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            LogAndShowException(e.Exception.Flatten(), "Async Task Error");
        }

        private static void LogAndShowException(Exception ex, string title)
        {
            MessageBox.Show($"{ex.Message}",
                            title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}