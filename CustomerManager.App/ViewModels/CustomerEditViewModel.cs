using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CustomerManager.Core.Models;
using CustomerManager.Core.Services;
using System;
using System.Threading.Tasks;


namespace CustomerManager.App.ViewModels;

public partial class CustomerEditViewModel : ViewModelBase
{
    private readonly MainViewModel _nav;
    private readonly CustomerRepository _repo;
    private readonly int? _editId;

    [ObservableProperty] private string _name = "";
    [ObservableProperty] private string? _email;
    [ObservableProperty] private string? _phone;
    [ObservableProperty] private string? _error;

    public CustomerEditViewModel(MainViewModel nav, CustomerRepository repo, int? customerId)
    {
        _nav = nav;
        _repo = repo;
        _editId = customerId;

        _ = LoadIfEditAsync();
    }

    private async Task LoadIfEditAsync()
    {
        if (_editId == null) return;
        var c = await _repo.GetByIdAsync(_editId.Value);
        if (c == null) return;

        Name = c.Name;
        Email = c.Email;
        Phone = c.Phone;
    }

    [RelayCommand]
    private async Task SaveAsync()
    {
        Error = null;

        if (string.IsNullOrWhiteSpace(Name))
        {
            Error = "Name darf nicht leer sein.";
            return;
        }

        var entity = new Customer
        {
            Id = _editId ?? 0,
            Name = Name.Trim(),
            Email = string.IsNullOrWhiteSpace(Email) ? null : Email.Trim(),
            Phone = string.IsNullOrWhiteSpace(Phone) ? null : Phone.Trim(),
        };

        if (_editId == null) await _repo.AddAsync(entity);
        else await _repo.UpdateAsync(entity);

        _nav.Navigate(new CustomersViewModel(_nav, _repo));
    }

    [RelayCommand]
    private void Cancel() => _nav.Navigate(new CustomersViewModel(_nav, _repo));
}