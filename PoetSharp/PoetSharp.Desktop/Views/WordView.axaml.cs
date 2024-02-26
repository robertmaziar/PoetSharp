using Avalonia.ReactiveUI;
using PoetSharp.Desktop.ViewModels;
using ReactiveUI;
using System.Threading.Tasks;

namespace PoetSharp.Desktop.Views;

public partial class WordView : ReactiveUserControl<WordViewModel>
{
    public WordView()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel.ShowDialog.RegisterHandler(DoShowDialogAsync)));
    }

    private async Task DoShowDialogAsync(InteractionContext<DictionaryViewModel, WordViewModel> interaction)
    {
        var dialog = new DictionaryWindow();
        dialog.DataContext = interaction.Input;

        var result = await dialog.ShowDialog<WordViewModel>(App.MainWindow);
        interaction.SetOutput(result);
    }

}