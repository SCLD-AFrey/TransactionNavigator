using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TransactionNavigator.ClientGui.ViewModels;

namespace TransactionNavigator.ClientGui.Views.Controls;

public partial class LoginView : UserControl
{
    public LoginView()
    {
        InitializeComponent();
        DataContext = new LoginViewModel();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}