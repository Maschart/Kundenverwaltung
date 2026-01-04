namespace CustomerManager.App.ViewModels;

public class MainWindowViewModel
{
    public MainViewModel Main { get; }

    public MainWindowViewModel(MainViewModel main) => Main = main;
}