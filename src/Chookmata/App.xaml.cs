using System.Configuration;
using System.Data;
using System.Windows;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Chookmata.view;
using Chookmata.viewModel;

namespace Chookmata;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private static IServiceProvider _services { get; set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        _services = serviceCollection.BuildServiceProvider();


        var mainWindow = _services.GetService<MainWindow>();

        Application.Current.MainWindow = mainWindow;
        mainWindow.Show();

    }
    protected override void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<AuthWindow>();
        services.AddTransient<OverlayWindow>();
        services.AddTransient<MainWindow>();
        services.AddSingleton<MainViewModel>();
    }
}

