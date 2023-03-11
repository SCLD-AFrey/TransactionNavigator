using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TransactionNavigator.ClientGui.ViewModels;

namespace TransactionNavigator.ClientGui.Views;

public partial class SettingsView : UserControl
{
    public SettingsView()
    {
        InitializeComponent();
        DataContext = new SettingsViewModel();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}