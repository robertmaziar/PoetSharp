using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PoetSharp.Desktop.Views;

public partial class SentenceView : UserControl
{
    public SentenceView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}