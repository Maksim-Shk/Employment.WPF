using Employment.WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Employment.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Автоматизированная информационная система «Трудоустройство»\r\n Описание предметной области.\r\n Организация (Код, Название, Краткое название Адрес, Контактные телефоны, электронный адрес) предоставляет услуги по трудоустройству.\r\n Организацией ведется банк данных о существующих вакансиях. \r\n По каждой вакансии поддерживается следующая информация: \r\n - предприятие (Код, Название, Краткое название Адрес, Контактные телефоны, электронный адрес); \r\n - название вакансии (должность); \r\n - требования к соискателю: \r\n пол, возраст (Верхняя граница, Нижняя граница), \r\n образование (высшее, среднее, не имеет значение и т.п.), \r\n знание определенных видов деятельности (выбор из перечня \r\n - знание электронного документооборота, определенных прикладных программ и т.п.), \r\n коммуникабельность (да, нет);\r\n - обязанности (выбор из перечня – заключение договоров, распространение агитационного материала, работа с клиентами и т.п.);\r\n - предполагаемая оплата (Нижняя граница, Верхняя граница), единицы измерения оплаты - рубли; \r\n - оформление трудовой книжки (да, нет); \r\n - наличие социального пакета (да, нет); \r\n - срок начала открытия вакансии; \r\n - срок закрытия вакансии (вакансия занята)\r\n \r\n . Необходимо осуществлять следующую обработку данных: \r\n - на заданную дату список предприятий, имеющих вакансии по заданной должности; \r\n - название должности, на которую за заданный период было предложено максимальное количество вакансий; \r\n - на заданную дату список предприятий, предлагающих вакансии, не требующих образования.\r\n", "Справка");
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            var companiesWithVacanciesView = new CompaniesWithVacanciesView();
            companiesWithVacanciesView.Show();

        }
    }
}
