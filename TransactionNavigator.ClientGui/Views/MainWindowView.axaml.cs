using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TransactionNavigator.ClientGui.ViewModels;

namespace TransactionNavigator.ClientGui.Views;

public partial class MainWindowView : Window
{
    public MainWindowView()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}