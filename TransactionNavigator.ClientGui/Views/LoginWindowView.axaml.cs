using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TransactionNavigator.ClientGui.ViewModels;

namespace TransactionNavigator.ClientGui.Views;

public partial class LoginWindowView : Window
{
    public LoginWindowView()
    {
        InitializeComponent();
        DataContext = new LoginWindowViewModel();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}