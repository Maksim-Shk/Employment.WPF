namespace Employment.WPF.ViewModels;

public class MainViewModel
{
    public MainMenuViewModel MainMenuViewModel { get; set; }

    public MainViewModel()
    {
        MainMenuViewModel = new MainMenuViewModel();
    }
}
