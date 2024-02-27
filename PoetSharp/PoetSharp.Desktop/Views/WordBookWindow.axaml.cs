using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using PoetSharp.Desktop.ViewModels;
using ReactiveUI;

namespace PoetSharp.Desktop.Views;

public partial class WordBookWindow : ReactiveWindow<WordBookViewModel>
{
    public WordBookWindow()
    {
        InitializeComponent();

        //this.WhenActivated(d => d(ViewModel.BuyMusicCommand.Subscribe(Close)));
    }
}