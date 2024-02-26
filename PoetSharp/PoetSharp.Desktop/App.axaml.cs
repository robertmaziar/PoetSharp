using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using PoetSharp.Desktop.Services;
using PoetSharp.Desktop.ViewModels;
using PoetSharp.Desktop.Views;

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
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                SentenceService sentenceService = new SentenceService();

                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(sentenceService),
                };

                // Here is where a reference to the main window is saved to the App class
                App.MainWindow = desktop.MainWindow as MainWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}