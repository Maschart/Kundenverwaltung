using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CustomerManager.App.ViewModels;
using CustomerManager.App.Views;
using CustomerManager.Core.Data;
using CustomerManager.Core.Services;

namespace CustomerManager.App;


public partial class App : Application
{
    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // DB im Arbeitsverzeichnis (einfach für Abgabe)
            var options = DbFactory.CreateOptions("customermanager.db");
            var repo = new CustomerRepository(options);

            var mainVm = new MainViewModel(repo);
            var windowVm = new MainWindowViewModel(mainVm);

            desktop.MainWindow = new MainWindow
            {
                DataContext = windowVm
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}