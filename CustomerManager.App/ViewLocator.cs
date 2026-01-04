using Avalonia.Controls;
using Avalonia.Controls.Templates;
using CustomerManager.App.ViewModels;
using CustomerManager.App.Views;

namespace CustomerManager.App;

public class ViewLocator : IDataTemplate
{
    public Control Build(object? data) => data switch
    {
        MainViewModel => new MainView(),
        CustomersViewModel => new CustomersView(),
        CustomerEditViewModel => new CustomerEditView(),
        _ => new TextBlock { Text = "View not found." }
    };

    public bool Match(object? data) => data is ViewModelBase;
}