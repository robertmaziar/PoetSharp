using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PoetSharp.Desktop.Views;

public partial class HighlightedWordView : UserControl
{
    public HighlightedWordView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}