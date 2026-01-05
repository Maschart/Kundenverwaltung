using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CustomerManager.Core.Models;
using CustomerManager.Core.Services;
using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;



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


        if (string.IsNullOrWhiteSpace(Name) ||
            string.IsNullOrWhiteSpace(Email) ||
            string.IsNullOrWhiteSpace(Phone))
        {
            Error = "Bitte Name, Email und Telefon ausfüllen.";
            return;
        }


        if (NameHasDigitRegex.IsMatch(Name))
        {
            Error = "Name darf keine Zahlen enthalten.";
            return;
        }


        if (!EmailRegex.IsMatch(Email.Trim()))
        {
            Error = "Bitte eine gültige Email eingeben (z.B. name@mail.de).";
            return;
        }


        if (!PhoneRegex.IsMatch(Phone.Trim()))
        {
            Error = "Telefon darf nur Zahlen und Zeichen wie + - ( ) enthalten.";
            return;
        }

        var hasDup = await _repo.ExistsDuplicateAsync(_editId, Name, Email, Phone);
        if (hasDup)
        {
            Error = "Diesen Kunden (Name+Email+Telefon) gibt es bereits.";
            return;
        }


        try
        {
            var entity = new Customer
            {
                Id = _editId ?? 0,
                Name = Name.Trim(),
                Email = string.IsNullOrWhiteSpace(Email) ? null : Email.Trim(),
                Phone = string.IsNullOrWhiteSpace(Phone) ? null : Phone.Trim(),
            };

            if (_editId == null)
                await _repo.AddAsync(entity);
            else
                await _repo.UpdateAsync(entity);

            var listVm = new CustomersViewModel(_nav, _repo);
            _nav.Navigate(listVm);
            await listVm.LoadAsync();
        }
        catch (Exception ex)
        {
            Error = "Fehler beim Speichern: " + ex.Message;
            
        }
    }
    private static readonly Regex EmailRegex =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    private static readonly Regex PhoneRegex =
        new(@"^[0-9+\-()\s]*$", RegexOptions.Compiled);

    private static readonly Regex NameHasDigitRegex =
        new(@"\d", RegexOptions.Compiled);


    [RelayCommand]
    private void Cancel() => _nav.Navigate(new CustomersViewModel(_nav, _repo));
}