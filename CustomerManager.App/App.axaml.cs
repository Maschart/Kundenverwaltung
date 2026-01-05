using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CustomerManager.App.ViewModels;
using CustomerManager.App.Views;
using CustomerManager.Core.Data;
using CustomerManager.Core.Services;
using System;
using System.IO;


namespace CustomerManager.App;


public partial class App : Application
{
    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // DB im Arbeitsverzeichnis (einfach für Abgabe)
            var baseDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var folder = Path.Combine(baseDir, "CustomerManager");
            Directory.CreateDirectory(folder);

            var dbPath = Path.Combine(folder, "customermanager.db");

            var options = DbFactory.CreateOptions(dbPath);
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