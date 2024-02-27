using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using PoetSharp.Desktop.Services;
using PoetSharp.Desktop.ViewModels;
using PoetSharp.Desktop.Views;
using Splat;

namespace PoetSharp.Desktop
{
    public partial class App : Application
    {
        /// <summary>
        /// Contains a reference to the main window of the application.
        /// </summary>
        public static MainWindow MainWindow;

        public override void Initialize()
        {
            Locator.CurrentMutable.RegisterConstant(() => new SentenceService(), typeof(ISentenceService));

            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var sentenceService = new SentenceService();
                MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(sentenceService);

                desktop.MainWindow = new MainWindow
                {
                    DataContext = mainWindowViewModel,
                };

                // Here is where a reference to the main window is saved to the App class
                App.MainWindow = desktop.MainWindow as MainWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}