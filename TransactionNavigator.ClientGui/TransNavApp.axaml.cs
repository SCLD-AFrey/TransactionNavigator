using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Shapes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using TransactionNavigator.ClientGui.Models.Data;
using TransactionNavigator.ClientGui.Models.DataStructures;
using TransactionNavigator.ClientGui.Services;
using TransactionNavigator.ClientGui.Services.Database;
using TransactionNavigator.ClientGui.Services.Infrastructure;
using TransactionNavigator.ClientGui.ViewModels;
using TransactionNavigator.ClientGui.Views;

namespace TransactionNavigator.ClientGui;

public partial class TransNavApp : Application
{
    private readonly IHost m_appHost;

    public static int CurrentUserId { get; set; } = 0;

    public TransNavApp()
    {
        m_appHost = Host.CreateDefaultBuilder()
            .ConfigureLogging(p_options =>
            {
                p_options.AddDebug();
                p_options.AddSerilog();
            })
            .ConfigureServices(ConfigureServices).Build();
    }

    private void ConfigureServices(IServiceCollection p_services)
    {
        p_services.AddSingleton<CommonDirectories>();
        p_services.AddSingleton<CommonFiles>();
        
        p_services.AddSingleton<CommonData>();
        
        p_services.AddSingleton<Navigation>();
        
        p_services.AddSingleton<MainWindowViewModel>();
        p_services.AddSingleton<MainWindowView>();
        
        p_services.AddSingleton<LoginWindowViewModel>();
        p_services.AddSingleton<LoginWindowView>();
        
        p_services.AddSingleton<HomeViewModel>();
        p_services.AddSingleton<HomeView>();
        
        p_services.AddSingleton<SettingsViewModel>();
        p_services.AddSingleton<SettingsView>();



    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override async void OnFrameworkInitializationCompleted()
    {
        
        var logLevel = LogEventLevel.Debug;

        var filesService = m_appHost.Services.GetRequiredService<CommonFiles>();
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Is(logLevel)
            .WriteTo.Sink(new CollectionSink())
            .WriteTo.File(new JsonFormatter(), filesService.ClientLogsPath)
            .CreateLogger();
        
        var dataService = m_appHost.Services.GetRequiredService<CommonData>();
        CommonData.InitData();

        await m_appHost.StartAsync();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            if (CurrentUserId == 0)
            {
                desktop.MainWindow = new LoginWindowView()
                {
                    DataContext = new LoginWindowViewModel(),
                };
            }
            else
            {
                desktop.MainWindow = new MainWindowView()
                {
                    DataContext = new MainWindowViewModel(),
                };
            }
        }

        base.OnFrameworkInitializationCompleted();
    }
}