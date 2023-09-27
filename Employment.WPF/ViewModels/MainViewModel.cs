using Employment.WPF.ViewModels.Math;

namespace Employment.WPF.ViewModels;

public class MainViewModel
{
    public MainMenuViewModel MainMenuViewModel { get; set; }
    public CompaniesViewModel CompaniesViewModel { get; set; }
    public VacancyDtoViewModel VacancyDtoViewModel { get; set; }  
    public EmploymentViewModel EmploymentViewModel { get; set; }
    public ClusterAnalysisViewModel ClusterAnalysisViewModel { get; set; }

    public MainViewModel()
    {
        MainMenuViewModel = new MainMenuViewModel();
        CompaniesViewModel = new CompaniesViewModel();
        VacancyDtoViewModel = new VacancyDtoViewModel();
        EmploymentViewModel = new EmploymentViewModel();
        ClusterAnalysisViewModel = new ClusterAnalysisViewModel();
    }
}
