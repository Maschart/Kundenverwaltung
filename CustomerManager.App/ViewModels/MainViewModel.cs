using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CustomerManager.Core.Services;

namespace CustomerManager.App.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly CustomerRepository _repo;

    [ObservableProperty]
    private ViewModelBase _currentView;

    public MainViewModel(CustomerRepository repo)
    {
        _repo = repo;
        _currentView = new CustomersViewModel(this, _repo);

        _ = _repo.EnsureCreatedAsync();
    }

    public void Navigate(ViewModelBase vm) => CurrentView = vm;

    [RelayCommand]
    private void GoCustomers() => Navigate(new CustomersViewModel(this, _repo));
}