using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using CustomerManager.Core.Models;
using CustomerManager.Core.Services;



namespace CustomerManager.App.ViewModels;

public partial class CustomersViewModel : ViewModelBase
{
    private readonly MainViewModel _nav;
    private readonly CustomerRepository _repo;

    public ObservableCollection<Customer> Items { get; } = new();

    [ObservableProperty] private Customer? _selected;
    [ObservableProperty] private string _search = "";

    public CustomersViewModel(MainViewModel nav, CustomerRepository repo)
    {
        _nav = nav;
        _repo = repo;
        _ = LoadAsync();
    }

   
    [RelayCommand]
    public async Task LoadAsync()
    {
        Items.Clear();
        var all = await _repo.GetAllAsync();

        var filtered = all.Where(c =>
            string.IsNullOrWhiteSpace(Search) ||
            c.Name.Contains(Search, StringComparison.OrdinalIgnoreCase) ||
            (c.Email ?? "").Contains(Search, StringComparison.OrdinalIgnoreCase) ||
            (c.Phone ?? "").Contains(Search, StringComparison.OrdinalIgnoreCase));

        foreach (var c in filtered) Items.Add(c);
    }

    [RelayCommand]
    private void New()
    {
        _nav.Navigate(new CustomerEditViewModel(_nav, _repo, null));
    }

    [RelayCommand]
    private void EditSelected()
    {
        if (Selected == null) return;
        _nav.Navigate(new CustomerEditViewModel(_nav, _repo, Selected.Id));
    }

    [RelayCommand]
    private async Task DeleteSelectedAsync()
    {
        if (Selected == null) return;
        await _repo.DeleteAsync(Selected.Id);
        await LoadAsync();
    }

    partial void OnSearchChanged(string value) => _ = LoadAsync();
}