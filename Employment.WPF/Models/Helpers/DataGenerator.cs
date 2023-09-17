using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.WPF.Models.Helpers
{
    public static class DataGenerator
    {
        private static Random _random = new Random();
        private static int _entityIdCounter { get; set; } = 1000;
        public static List<Company> GenerateCompanies()
        {
            var companyData = new (string RussianName, string EnglishName)[]
            {
                ("ООО Ромашка", "LLC Daisy"),
                ("ЗАО Подсолнух", "JSC Sunflower"),
                ("ПАО Лес", "PJSC Forest"),
                ("ООО Горизонт", "LLC Horizon"),
                ("ЗАО Ветерок", "JSC Breeze"),
                ("ПАО Закат", "PJSC Sunset"),
                ("ООО Светлячок", "LLC Firefly"),
                ("ООО Гора", "LLC Mountain"),
                ("ПАО Волна", "PJSC Wave"),
                ("ООО Долина", "LLC Valley")
            };

            var companies = companyData.Select(data =>
            {
                // Преобразование названия компании в короткое имя (ShortName) и Email
                var shortName = data.RussianName.Split(' ')[1]; // Берем второе слово из названия как короткое имя
                var email = $"{data.EnglishName.Split(' ')[1].ToLower()}@mail.ru"; // Используем английскую версию для Email

                return new Company
                {
                    CompanyId = Guid.NewGuid(),
                    Name = data.RussianName,
                    ShortName = shortName,
                    Email = email,
                    // Addresses = GenerateAddressForCompany(),
                    // Phones = GeneratePhonesForCompany(),
                    // Vacancies = GenerateVacanciesForCompany(2, data.RussianName)
                };
            }).ToList();

            foreach (var company in companies)
            {
                // company.Vacancies = GenerateVacanciesForCompany(company.Name, 2);
                //  company.Addresses = GenerateAddressesForCompany(company.CompanyId, 2);
                // company.Phones = GeneratePhonesForCompany(company.CompanyId, 2);
            }

            return companies;
        }

        private static int _vacancyIdCounter { get; set; } = -1;
        public static List<Vacancy> GenerateVacanciesForCompany(string companyName, Guid companyId, int count)
        {
            var vacancies = new List<Vacancy>();
            var responsibilities = GenerateResponsibilities();

            for (int i = 0; i < count; i++)
            {
                List<Responsibility> randomResponsibilities = responsibilities.OrderBy(x => _random.Next()).Take(_random.Next(2, 6)).ToList();

                vacancies.Add(new Vacancy
                {
                    CompanyId = companyId,
                    VacancyId = _entityIdCounter--,
                    Name = $"Вакансия {i + 1} в <{companyName}>",
                    WorkBookRegistration = _random.Next(0, 2) == 0,
                    SocialPackage = _random.Next(0, 2) == 0,
                    OpenDate = DateTime.UtcNow.AddDays(-_random.Next(0, 30)),
                    CloseDate = _random.Next(0, 2) == 0 ? (DateTime?)null : DateTime.UtcNow.AddDays(_random.Next(1, 30)),
                    Gender = _random.Next(0, 3) == 0 ? "Мужской" : (_random.Next(0, 3) == 1 ? "Женский" : "Не указан"),
                    LowerAge = _random.Next(18, 24),
                    TopAge = _random.Next(50, 70),
                    LowerSalary = _random.Next(25, 60) * 1000,
                    UpperSalary = _random.Next(61, 100) * 1000,
                    EducationId = _random.Next(1, 5),
                    PositionId = _random.Next(1,10),
                    Responsibilities = randomResponsibilities
                });
            }

            return vacancies;
        }

        private static int _phoneIdCounter { get; set; } = -1;
        public static List<Phone> GeneratePhonesForCompany(Guid companyId, int count)
        {
            var phones = new List<Phone>();

            for (int i = 0; i < count; i++)
            {
                phones.Add(new Phone
                {
                    PhoneId = _entityIdCounter--,
                    PhoneNumber = $"+7{_random.Next(900, 999)}{_random.Next(100, 999)}{_random.Next(1000, 9999)}",
                    ExternalId = companyId
                });
            }

            return phones;
        }

        private static int _addressIdCounter { get; set; } = -1;
        public static List<Address> GenerateAddressesForCompany(Guid companyId, int count,
            List<Street> streets, List<StreetType> streetsTypes, List<LocalityType> localityTypes, List<Locality> localities)
        {
            //var streetsTypes = GenerateStreetTypes();
            //var streets = GenerateStreets(streetsTypes);
            //
            //var localityTypes = GenerateLocalityTypes();
            //var localities = GenerateLocalities(localityTypes);

            var addresses = new List<Address>();

            for (int i = 0; i < count; i++)
            {
                addresses.Add(new Address
                {
                    AddressId = _entityIdCounter--,
                    House = _random.Next(1, 100).ToString(),
                    Apartment = _random.Next(1, 200).ToString(),
                    StreetId = streets[_random.Next(streets.Count)].StreetId,
                    LocalityId = localities[_random.Next(localities.Count)].LocalityId,
                    ExternalId = companyId
                });
            }

            return addresses;
        }

        private static int _streetIdCounter { get; set; } = -1;
        public static List<Street> GenerateStreets(List<StreetType> streetTypes)
        {
            var streetNames = new[]
            {
                "Ленина", "Мира", "Советская", "Молодежная", "Центральная",
                "Школьная", "Новая", "Заречная", "Садовая", "Луговая"
            };

            var streets = new List<Street>();
            foreach (var name in streetNames)
            {
                streets.Add(new Street
                {
                    StreetId = _entityIdCounter--,
                    Name = name,
                    StreeTypetId = streetTypes[_random.Next(streetTypes.Count)].StreetTypeId
                });
            }
            return streets;
        }

        private static int _streetTypeIdCounter { get; set; } = -1;
        public static List<StreetType> GenerateStreetTypes()
        {
            return new List<StreetType>
            {
                new StreetType { StreetTypeId = 1, Name = "Улица", ShortName = "ул." },
                new StreetType { StreetTypeId = 2, Name = "Проспект", ShortName = "пр." },
                new StreetType { StreetTypeId = 3, Name = "Бульвар", ShortName = "бул." },
                new StreetType { StreetTypeId = 4, Name = "Переулок", ShortName = "пер." },
                new StreetType { StreetTypeId = 5, Name = "Проезд", ShortName = "пр-д" }
            };
        }

        public static List<Locality> GenerateLocalities(List<LocalityType> localityTypes)
        {
            var localityNames = new[]
            {
                "Погорелка", "Дубровка",
                "Вязовка", "Каменка",
                "Березовка", "Степаново",
                "Липово", "Заборье",
                "Терновка", "Черничка"
            };

            var localities = new List<Locality>();
            int idCounter = -1;  // Начните с отрицательного значения
            foreach (var name in localityNames)
            {
                localities.Add(new Locality
                {
                    LocalityId = _entityIdCounter--,  // Уменьшайте значение на каждой итерации
                    Name = name,
                    LocalityTypeId = localityTypes[_random.Next(localityTypes.Count)].LocalityTypeId
                });
            }
            return localities;
        }

        public static List<Position> GeneratePositions()
        {

            return new List<Position>
                {
                    new Position { PositionId = 1, Title = "Программист" },
                    new Position { PositionId = 2, Title = "Дизайнер" },
                    new Position { PositionId = 3, Title = "Менеджер проекта" },
                    new Position { PositionId = 4, Title = "Аналитик" },
                    new Position { PositionId = 5, Title = "Тестировщик" },
                    new Position { PositionId = 6, Title = "Системный администратор" },
                    new Position { PositionId = 7, Title = "Сетевой инженер" },
                    new Position { PositionId = 8, Title = "Директор по IT" },
                    new Position { PositionId = 9, Title = "HR-специалист" },
                    new Position { PositionId = 10, Title = "Бухгалтер" }
                };
        }

        public static List<LocalityType> GenerateLocalityTypes()
        {
            return new List<LocalityType>
                {
                    new LocalityType { LocalityTypeId = 1, Name = "Город", ShortName = "г." },
                    new LocalityType { LocalityTypeId = 2, Name = "Поселок", ShortName = "п." },
                    new LocalityType { LocalityTypeId = 3, Name = "Деревня", ShortName = "д." },
                    new LocalityType { LocalityTypeId = 4, Name = "Хутор", ShortName = "х." },
                    new LocalityType { LocalityTypeId = 5, Name = "Село", ShortName = "с." }
                };
        }

        public static List<Education> GenerateEducations()
        {
            return new List<Education>
                {
                    new Education { EducationId = 1, Level = "Начальное образование" },
                    new Education { EducationId = 2, Level = "Основное общее образование"  },
                    new Education { EducationId = 3, Level = "Среднее общее образование" },
                    new Education { EducationId = 4, Level = "Среднее профессиональное образование" },
                    new Education { EducationId = 5, Level = "Высшее образование" }
                };
        }

        public static List<Responsibility> GenerateResponsibilities()
        {
            return new List<Responsibility>
                {
                    new Responsibility { ResponsibilityId = 1, Name = "Заключение договоров" },
                    new Responsibility { ResponsibilityId = 2, Name = "Распространение агитационного материала" },
                    new Responsibility { ResponsibilityId = 3, Name = "Работа с клиентами" },
                    new Responsibility { ResponsibilityId = 4, Name = "Ведение переговоров" },
                    new Responsibility { ResponsibilityId = 5, Name = "Организация и проведение презентаций" },
                    new Responsibility { ResponsibilityId = 6, Name = "Мониторинг рынка и конкурентов" },
                    new Responsibility { ResponsibilityId = 7, Name = "Планирование и оценка бюджета" },
                    new Responsibility { ResponsibilityId = 8, Name = "Подготовка отчетности" },
                    new Responsibility { ResponsibilityId = 9, Name = "Участие в выставках и конференциях" },
                    new Responsibility { ResponsibilityId = 10, Name = "Поддержка продуктов компании" }
                };
        }

    }
}

