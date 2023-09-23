namespace Employment.WPF.ViewModels;

public class MainViewModel
{
    public MainMenuViewModel MainMenuViewModel { get; set; }
    public CompaniesViewModel CompaniesViewModel { get; set; }
    public VacancyViewModel VacancyViewModel { get; set; }  
    public EmploymentViewModel EmploymentViewModel { get; set; }

    public MainViewModel()
    {
        MainMenuViewModel = new MainMenuViewModel();
        CompaniesViewModel = new CompaniesViewModel();
        VacancyViewModel = new VacancyViewModel();
        EmploymentViewModel = new EmploymentViewModel();
    }
}
