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
                company.Vacancies = GenerateVacanciesForCompany(company.Name, 2);
                company.Addresses = GenerateAddressesForCompany(company.CompanyId, 2);
                company.Phones = GeneratePhonesForCompany(company.CompanyId, 2);
            }

            return companies;
        }

        public static List<Vacancy> GenerateVacanciesForCompany(string companyName,int count)
        {
            var vacancies = new List<Vacancy>();

            for (int i = 0; i < count; i++)
            {
                vacancies.Add(new Vacancy
                {
                    Name = $"Вакансия {i + 1} в <{companyName}>",
                    WorkBookRegistration = _random.Next(0, 2) == 0,
                    SocialPackage = _random.Next(0, 2) == 0,
                    OpenDate = DateTime.Now.AddDays(-_random.Next(0, 30)),
                    CloseDate = _random.Next(0, 2) == 0 ? (DateTime?)null : DateTime.Now.AddDays(_random.Next(1, 30)),
                    Gender = _random.Next(0, 3) == 0 ? "Мужской" : (_random.Next(0, 3) == 1 ? "Женский" : "Не указан"),
                    LowerAge = _random.Next(18, 24),
                    TopAge = _random.Next(50, 70),
                    LowerSalary = _random.Next(25, 60) * 1000,
                    UpperSalary = _random.Next(61, 100) * 1000
                });
            }

            return vacancies;
        }

        public static List<Phone> GeneratePhonesForCompany(Guid companyId, int count)
        {
            var phones = new List<Phone>();

            for (int i = 0; i < count; i++)
            {
                phones.Add(new Phone
                {
                    PhoneNumber = $"+7{_random.Next(900, 999)}{_random.Next(100, 999)}{_random.Next(1000, 9999)}",
                    ExternalId = companyId
                });
            }

            return phones;
        }

        public static List<Address> GenerateAddressesForCompany(Guid companyId, int count)
        {
            var streetsTypes = GenerateStreetTypes();
            var streets = GenerateStreets(streetsTypes);

            var localityTypes = GenerateLocalityTypes();
            var localities = GenerateLocalities(localityTypes);

            var addresses = new List<Address>();
            int addressId = -1; // начнем с -1 и будем уменьшать на единицу

            for (int i = 0; i < count; i++)
            {
                addresses.Add(new Address
                {
                    AddressId = addressId--, // присвоим значение и уменьшим на 1
                    House = _random.Next(1, 100).ToString(),
                    Apartment = _random.Next(1, 200).ToString(),
                    StreetId = streets[_random.Next(streets.Count)].StreetId,
                    LocalityId = localities[_random.Next(localities.Count)].LocalityId,
                    ExternalId = companyId
                });
            }

            return addresses;
        }

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
                    Name = name,
                    StreeTypetId = streetTypes[_random.Next(streetTypes.Count)].StreetId
                });
            }
            return streets;
        }

        public static List<StreetType> GenerateStreetTypes()
        {
            return new List<StreetType>
            {
                new StreetType { Name = "Улица", ShortName = "ул." },
                new StreetType { Name = "Проспект", ShortName = "пр." },
                new StreetType { Name = "Бульвар", ShortName = "бул." },
                new StreetType { Name = "Переулок", ShortName = "пер." },
                new StreetType { Name = "Проезд", ShortName = "пр-д" }
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
            foreach (var name in localityNames)
            {
                localities.Add(new Locality
                {
                    Name = name,
                    LocalityTypeId = localityTypes[_random.Next(localityTypes.Count)].LocalityTypeId
                });
            }
            return localities;
        }

        public static List<LocalityType> GenerateLocalityTypes()
        {
            return new List<LocalityType>
            {
                new LocalityType { Name = "Город", ShortName = "г." },
                new LocalityType { Name = "Поселок", ShortName = "п." },
                new LocalityType { Name = "Деревня", ShortName = "д." },
                new LocalityType { Name = "Хутор", ShortName = "х." },
                new LocalityType { Name = "Село", ShortName = "с." }
            };
        }
    }
}

