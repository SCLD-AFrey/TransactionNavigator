using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TransactionNavigator.ClientGui.ViewModels;

namespace TransactionNavigator.ClientGui.Views;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
        DataContext = new HomeViewModel();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}