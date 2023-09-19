using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Employment.WPF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ShortName = table.Column<string>(type: "character varying(63)", maxLength: 63, nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Level = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.EducationId);
                });

            migrationBuilder.CreateTable(
                name: "LocalityType",
                columns: table => new
                {
                    LocalityTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ShortName = table.Column<string>(type: "character varying(63)", maxLength: 63, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalityType", x => x.LocalityTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "Responsibility",
                columns: table => new
                {
                    ResponsibilityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibility", x => x.ResponsibilityId);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "StreetType",
                columns: table => new
                {
                    StreetTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ShortName = table.Column<string>(type: "character varying(63)", maxLength: 63, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StreetType", x => x.StreetTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    PhoneId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    EntityType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.PhoneId);
                    table.ForeignKey(
                        name: "FK_Phone_Company_ExternalId",
                        column: x => x.ExternalId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locality",
                columns: table => new
                {
                    LocalityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ShortName = table.Column<string>(type: "character varying(63)", maxLength: 63, nullable: true),
                    LocalityTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locality", x => x.LocalityId);
                    table.ForeignKey(
                        name: "FK_Locality_LocalityType_LocalityTypeId",
                        column: x => x.LocalityTypeId,
                        principalTable: "LocalityType",
                        principalColumn: "LocalityTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacancy",
                columns: table => new
                {
                    VacancyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    WorkBookRegistration = table.Column<bool>(type: "boolean", nullable: false),
                    SocialPackage = table.Column<bool>(type: "boolean", nullable: false),
                    OpenDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    LowerAge = table.Column<int>(type: "integer", nullable: true),
                    TopAge = table.Column<int>(type: "integer", nullable: true),
                    LowerSalary = table.Column<double>(type: "double precision", nullable: true),
                    UpperSalary = table.Column<double>(type: "double precision", nullable: true),
                    EducationId = table.Column<int>(type: "integer", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancy", x => x.VacancyId);
                    table.ForeignKey(
                        name: "FK_Vacancy_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vacancy_Education_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Education",
                        principalColumn: "EducationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vacancy_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Street",
                columns: table => new
                {
                    StreetId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ShortName = table.Column<string>(type: "character varying(63)", maxLength: 63, nullable: true),
                    StreeTypetId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Street", x => x.StreetId);
                    table.ForeignKey(
                        name: "FK_Street_StreetType_StreeTypetId",
                        column: x => x.StreeTypetId,
                        principalTable: "StreetType",
                        principalColumn: "StreetTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacancyResponsibility",
                columns: table => new
                {
                    ResponsibilityId = table.Column<int>(type: "integer", nullable: false),
                    VacancyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyResponsibility", x => new { x.VacancyId, x.ResponsibilityId });
                    table.ForeignKey(
                        name: "FK_VacancyResponsibility_Responsibility_ResponsibilityId",
                        column: x => x.ResponsibilityId,
                        principalTable: "Responsibility",
                        principalColumn: "ResponsibilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancyResponsibility_Vacancy_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancy",
                        principalColumn: "VacancyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacancySkill",
                columns: table => new
                {
                    VacancyId = table.Column<int>(type: "integer", nullable: false),
                    SkillId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancySkill", x => new { x.VacancyId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_VacancySkill_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacancySkill_Vacancy_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "Vacancy",
                        principalColumn: "VacancyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    House = table.Column<string>(type: "text", nullable: true),
                    Apartment = table.Column<string>(type: "text", nullable: true),
                    LocalityId = table.Column<int>(type: "integer", nullable: false),
                    StreetId = table.Column<int>(type: "integer", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_Address_Company_ExternalId",
                        column: x => x.ExternalId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Locality_LocalityId",
                        column: x => x.LocalityId,
                        principalTable: "Locality",
                        principalColumn: "LocalityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_Street_StreetId",
                        column: x => x.StreetId,
                        principalTable: "Street",
                        principalColumn: "StreetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "CompanyId", "Email", "Name", "ShortName" },
                values: new object[,]
                {
                    { new Guid("082beb66-8c05-4a29-a0b6-e281f8ea86c4"), "breeze@mail.ru", "ЗАО Ветерок", "Ветерок" },
                    { new Guid("39fa266f-6e3a-4726-9f1e-1fe1ef0ae497"), "forest@mail.ru", "ПАО Лес", "Лес" },
                    { new Guid("4bb755a6-b4af-4d4d-adc6-5d4f13185b62"), "mountain@mail.ru", "ООО Гора", "Гора" },
                    { new Guid("506d8596-eb92-4b8a-b284-5b9374a0fa87"), "daisy@mail.ru", "ООО Ромашка", "Ромашка" },
                    { new Guid("5528b2d7-5c75-402b-9e0d-a9c33cf8d9a3"), "valley@mail.ru", "ООО Долина", "Долина" },
                    { new Guid("5cf3e6d7-8746-4a5d-b2f6-4dfcf1624d8f"), "sunset@mail.ru", "ПАО Закат", "Закат" },
                    { new Guid("5d30fe41-3b22-4acd-9591-ec0c2c9d69bb"), "wave@mail.ru", "ПАО Волна", "Волна" },
                    { new Guid("9992dad4-ccb8-4a0c-abcc-878d498e4899"), "horizon@mail.ru", "ООО Горизонт", "Горизонт" },
                    { new Guid("c4c03fc3-cc30-4564-b30d-317f4fb80768"), "firefly@mail.ru", "ООО Светлячок", "Светлячок" },
                    { new Guid("d918fe9c-e16d-4724-b24b-48662dfc21e6"), "sunflower@mail.ru", "ЗАО Подсолнух", "Подсолнух" }
                });

            migrationBuilder.InsertData(
                table: "Education",
                columns: new[] { "EducationId", "Level" },
                values: new object[,]
                {
                    { 1, "Начальное образование" },
                    { 2, "Основное общее образование" },
                    { 3, "Среднее общее образование" },
                    { 4, "Среднее профессиональное образование" },
                    { 5, "Высшее образование" }
                });

            migrationBuilder.InsertData(
                table: "LocalityType",
                columns: new[] { "LocalityTypeId", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "Город", "г." },
                    { 2, "Поселок", "п." },
                    { 3, "Деревня", "д." },
                    { 4, "Хутор", "х." },
                    { 5, "Село", "с." }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "PositionId", "Title" },
                values: new object[,]
                {
                    { 1, "Программист" },
                    { 2, "Дизайнер" },
                    { 3, "Менеджер проекта" },
                    { 4, "Аналитик" },
                    { 5, "Тестировщик" },
                    { 6, "Системный администратор" },
                    { 7, "Сетевой инженер" },
                    { 8, "Директор по IT" },
                    { 9, "HR-специалист" },
                    { 10, "Бухгалтер" }
                });

            migrationBuilder.InsertData(
                table: "Responsibility",
                columns: new[] { "ResponsibilityId", "Name" },
                values: new object[,]
                {
                    { 1, "Заключение договоров" },
                    { 2, "Распространение агитационного материала" },
                    { 3, "Работа с клиентами" },
                    { 4, "Ведение переговоров" },
                    { 5, "Организация и проведение презентаций" },
                    { 6, "Мониторинг рынка и конкурентов" },
                    { 7, "Планирование и оценка бюджета" },
                    { 8, "Подготовка отчетности" },
                    { 9, "Участие в выставках и конференциях" },
                    { 10, "Поддержка продуктов компании" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "SkillId", "Name" },
                values: new object[,]
                {
                    { 1, "Знание электронного документооборота" },
                    { 2, "Владение Microsoft Office" },
                    { 3, "Опыт работы с 1C" },
                    { 4, "Владение Adobe Photoshop" },
                    { 5, "Знание системы контроля версий Git" },
                    { 6, "Опыт работы с CRM-системами" },
                    { 7, "Опыт работы с ERP-системами" },
                    { 8, "Владение языками программирования (например, Python, C#)" },
                    { 9, "Знание баз данных (SQL)" },
                    { 10, "Коммуникабельность" }
                });

            migrationBuilder.InsertData(
                table: "StreetType",
                columns: new[] { "StreetTypeId", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "Улица", "ул." },
                    { 2, "Проспект", "пр." },
                    { 3, "Бульвар", "бул." },
                    { 4, "Переулок", "пер." },
                    { 5, "Проезд", "пр-д" }
                });

            migrationBuilder.InsertData(
                table: "Locality",
                columns: new[] { "LocalityId", "LocalityTypeId", "Name", "ShortName" },
                values: new object[,]
                {
                    { 901, 2, "Черничка", null },
                    { 902, 3, "Терновка", null },
                    { 903, 5, "Заборье", null },
                    { 904, 3, "Липово", null },
                    { 905, 4, "Степаново", null },
                    { 906, 3, "Березовка", null },
                    { 907, 3, "Каменка", null },
                    { 908, 5, "Вязовка", null },
                    { 909, 2, "Дубровка", null },
                    { 910, 1, "Погорелка", null }
                });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "PhoneId", "EntityType", "ExternalId", "PhoneNumber" },
                values: new object[,]
                {
                    { 845, 0, new Guid("5528b2d7-5c75-402b-9e0d-a9c33cf8d9a3"), "+79568635911" },
                    { 846, 0, new Guid("5528b2d7-5c75-402b-9e0d-a9c33cf8d9a3"), "+79511609875" },
                    { 851, 0, new Guid("5d30fe41-3b22-4acd-9591-ec0c2c9d69bb"), "+79058337811" },
                    { 852, 0, new Guid("5d30fe41-3b22-4acd-9591-ec0c2c9d69bb"), "+79858405919" },
                    { 857, 0, new Guid("4bb755a6-b4af-4d4d-adc6-5d4f13185b62"), "+79021822616" },
                    { 858, 0, new Guid("4bb755a6-b4af-4d4d-adc6-5d4f13185b62"), "+79729787753" },
                    { 863, 0, new Guid("c4c03fc3-cc30-4564-b30d-317f4fb80768"), "+79822215961" },
                    { 864, 0, new Guid("c4c03fc3-cc30-4564-b30d-317f4fb80768"), "+79199199216" },
                    { 869, 0, new Guid("5cf3e6d7-8746-4a5d-b2f6-4dfcf1624d8f"), "+79187861486" },
                    { 870, 0, new Guid("5cf3e6d7-8746-4a5d-b2f6-4dfcf1624d8f"), "+79955531928" },
                    { 875, 0, new Guid("082beb66-8c05-4a29-a0b6-e281f8ea86c4"), "+79317913802" },
                    { 876, 0, new Guid("082beb66-8c05-4a29-a0b6-e281f8ea86c4"), "+79622518617" },
                    { 881, 0, new Guid("9992dad4-ccb8-4a0c-abcc-878d498e4899"), "+79932491079" },
                    { 882, 0, new Guid("9992dad4-ccb8-4a0c-abcc-878d498e4899"), "+79013996260" },
                    { 887, 0, new Guid("39fa266f-6e3a-4726-9f1e-1fe1ef0ae497"), "+79004126845" },
                    { 888, 0, new Guid("39fa266f-6e3a-4726-9f1e-1fe1ef0ae497"), "+79199121450" },
                    { 893, 0, new Guid("d918fe9c-e16d-4724-b24b-48662dfc21e6"), "+79509139642" },
                    { 894, 0, new Guid("d918fe9c-e16d-4724-b24b-48662dfc21e6"), "+79085281476" },
                    { 899, 0, new Guid("506d8596-eb92-4b8a-b284-5b9374a0fa87"), "+79846523015" },
                    { 900, 0, new Guid("506d8596-eb92-4b8a-b284-5b9374a0fa87"), "+79712947192" }
                });

            migrationBuilder.InsertData(
                table: "Street",
                columns: new[] { "StreetId", "Name", "ShortName", "StreeTypetId" },
                values: new object[,]
                {
                    { 911, "Луговая", null, 3 },
                    { 912, "Садовая", null, 1 },
                    { 913, "Заречная", null, 2 },
                    { 914, "Новая", null, 1 },
                    { 915, "Школьная", null, 4 },
                    { 916, "Центральная", null, 5 },
                    { 917, "Молодежная", null, 1 },
                    { 918, "Советская", null, 3 },
                    { 919, "Мира", null, 2 },
                    { 920, "Ленина", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Vacancy",
                columns: new[] { "VacancyId", "CloseDate", "CompanyId", "EducationId", "Gender", "LowerAge", "LowerSalary", "Name", "OpenDate", "PositionId", "SocialPackage", "TopAge", "UpperSalary", "WorkBookRegistration" },
                values: new object[,]
                {
                    { 841, new DateTime(2023, 10, 16, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(889), new Guid("5528b2d7-5c75-402b-9e0d-a9c33cf8d9a3"), 3, "Не указан", 22, 33000.0, "Вакансия 2 в <ООО Долина>", new DateTime(2023, 9, 8, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(889), 4, true, 53, 78000.0, true },
                    { 842, new DateTime(2023, 9, 21, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(862), new Guid("5528b2d7-5c75-402b-9e0d-a9c33cf8d9a3"), 2, "Женский", 23, 40000.0, "Вакансия 1 в <ООО Долина>", new DateTime(2023, 8, 30, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(861), 1, false, 66, 84000.0, false },
                    { 847, null, new Guid("5d30fe41-3b22-4acd-9591-ec0c2c9d69bb"), 4, "Женский", 18, 59000.0, "Вакансия 2 в <ПАО Волна>", new DateTime(2023, 8, 26, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(784), 4, true, 64, 71000.0, true },
                    { 848, new DateTime(2023, 9, 27, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(750), new Guid("5d30fe41-3b22-4acd-9591-ec0c2c9d69bb"), 3, "Не указан", 23, 58000.0, "Вакансия 1 в <ПАО Волна>", new DateTime(2023, 8, 24, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(750), 8, false, 56, 64000.0, false },
                    { 853, null, new Guid("4bb755a6-b4af-4d4d-adc6-5d4f13185b62"), 3, "Женский", 22, 56000.0, "Вакансия 2 в <ООО Гора>", new DateTime(2023, 9, 9, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(631), 5, false, 55, 95000.0, false },
                    { 854, new DateTime(2023, 9, 24, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(551), new Guid("4bb755a6-b4af-4d4d-adc6-5d4f13185b62"), 4, "Не указан", 18, 43000.0, "Вакансия 1 в <ООО Гора>", new DateTime(2023, 8, 31, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(550), 7, true, 63, 90000.0, true },
                    { 859, new DateTime(2023, 9, 27, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(474), new Guid("c4c03fc3-cc30-4564-b30d-317f4fb80768"), 3, "Мужской", 23, 38000.0, "Вакансия 2 в <ООО Светлячок>", new DateTime(2023, 8, 29, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(473), 2, false, 52, 96000.0, false },
                    { 860, null, new Guid("c4c03fc3-cc30-4564-b30d-317f4fb80768"), 2, "Не указан", 20, 58000.0, "Вакансия 1 в <ООО Светлячок>", new DateTime(2023, 9, 6, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(443), 5, false, 56, 61000.0, false },
                    { 865, null, new Guid("5cf3e6d7-8746-4a5d-b2f6-4dfcf1624d8f"), 4, "Не указан", 18, 50000.0, "Вакансия 2 в <ПАО Закат>", new DateTime(2023, 8, 22, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(371), 3, false, 68, 92000.0, true },
                    { 866, null, new Guid("5cf3e6d7-8746-4a5d-b2f6-4dfcf1624d8f"), 4, "Не указан", 18, 25000.0, "Вакансия 1 в <ПАО Закат>", new DateTime(2023, 9, 17, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(339), 5, false, 53, 84000.0, false },
                    { 871, new DateTime(2023, 9, 24, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(264), new Guid("082beb66-8c05-4a29-a0b6-e281f8ea86c4"), 4, "Не указан", 19, 34000.0, "Вакансия 2 в <ЗАО Ветерок>", new DateTime(2023, 9, 3, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(263), 8, false, 62, 62000.0, true },
                    { 872, new DateTime(2023, 10, 17, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(235), new Guid("082beb66-8c05-4a29-a0b6-e281f8ea86c4"), 3, "Мужской", 20, 36000.0, "Вакансия 1 в <ЗАО Ветерок>", new DateTime(2023, 8, 29, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(235), 5, false, 56, 89000.0, false },
                    { 877, new DateTime(2023, 9, 21, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(158), new Guid("9992dad4-ccb8-4a0c-abcc-878d498e4899"), 3, "Не указан", 23, 29000.0, "Вакансия 2 в <ООО Горизонт>", new DateTime(2023, 9, 8, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(157), 2, true, 68, 91000.0, true },
                    { 878, null, new Guid("9992dad4-ccb8-4a0c-abcc-878d498e4899"), 4, "Не указан", 23, 44000.0, "Вакансия 1 в <ООО Горизонт>", new DateTime(2023, 9, 3, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(127), 8, false, 51, 66000.0, false },
                    { 883, new DateTime(2023, 9, 29, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(53), new Guid("39fa266f-6e3a-4726-9f1e-1fe1ef0ae497"), 1, "Не указан", 18, 40000.0, "Вакансия 2 в <ПАО Лес>", new DateTime(2023, 8, 23, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(53), 8, false, 54, 86000.0, false },
                    { 884, null, new Guid("39fa266f-6e3a-4726-9f1e-1fe1ef0ae497"), 4, "Женский", 20, 32000.0, "Вакансия 1 в <ПАО Лес>", new DateTime(2023, 8, 29, 9, 9, 24, 897, DateTimeKind.Utc).AddTicks(27), 3, true, 55, 78000.0, true },
                    { 889, null, new Guid("d918fe9c-e16d-4724-b24b-48662dfc21e6"), 1, "Не указан", 19, 32000.0, "Вакансия 2 в <ЗАО Подсолнух>", new DateTime(2023, 9, 12, 9, 9, 24, 896, DateTimeKind.Utc).AddTicks(9946), 7, false, 66, 68000.0, true },
                    { 890, null, new Guid("d918fe9c-e16d-4724-b24b-48662dfc21e6"), 2, "Не указан", 21, 44000.0, "Вакансия 1 в <ЗАО Подсолнух>", new DateTime(2023, 9, 16, 9, 9, 24, 896, DateTimeKind.Utc).AddTicks(9915), 7, false, 60, 88000.0, true },
                    { 895, new DateTime(2023, 9, 27, 9, 9, 24, 896, DateTimeKind.Utc).AddTicks(9826), new Guid("506d8596-eb92-4b8a-b284-5b9374a0fa87"), 4, "Не указан", 20, 39000.0, "Вакансия 2 в <ООО Ромашка>", new DateTime(2023, 9, 12, 9, 9, 24, 896, DateTimeKind.Utc).AddTicks(9825), 1, false, 57, 85000.0, true },
                    { 896, null, new Guid("506d8596-eb92-4b8a-b284-5b9374a0fa87"), 1, "Не указан", 18, 58000.0, "Вакансия 1 в <ООО Ромашка>", new DateTime(2023, 9, 3, 9, 9, 24, 896, DateTimeKind.Utc).AddTicks(9763), 3, false, 65, 94000.0, false }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "Apartment", "CompanyId", "ExternalId", "House", "LocalityId", "StreetId" },
                values: new object[,]
                {
                    { 843, "28", null, new Guid("5528b2d7-5c75-402b-9e0d-a9c33cf8d9a3"), "92", 901, 920 },
                    { 844, "60", null, new Guid("5528b2d7-5c75-402b-9e0d-a9c33cf8d9a3"), "85", 908, 914 },
                    { 849, "42", null, new Guid("5d30fe41-3b22-4acd-9591-ec0c2c9d69bb"), "59", 909, 917 },
                    { 850, "75", null, new Guid("5d30fe41-3b22-4acd-9591-ec0c2c9d69bb"), "11", 910, 917 },
                    { 855, "73", null, new Guid("4bb755a6-b4af-4d4d-adc6-5d4f13185b62"), "24", 902, 915 },
                    { 856, "145", null, new Guid("4bb755a6-b4af-4d4d-adc6-5d4f13185b62"), "57", 907, 919 },
                    { 861, "161", null, new Guid("c4c03fc3-cc30-4564-b30d-317f4fb80768"), "28", 906, 916 },
                    { 862, "107", null, new Guid("c4c03fc3-cc30-4564-b30d-317f4fb80768"), "80", 905, 917 },
                    { 867, "125", null, new Guid("5cf3e6d7-8746-4a5d-b2f6-4dfcf1624d8f"), "34", 904, 914 },
                    { 868, "149", null, new Guid("5cf3e6d7-8746-4a5d-b2f6-4dfcf1624d8f"), "75", 908, 920 },
                    { 873, "100", null, new Guid("082beb66-8c05-4a29-a0b6-e281f8ea86c4"), "27", 910, 913 },
                    { 874, "42", null, new Guid("082beb66-8c05-4a29-a0b6-e281f8ea86c4"), "56", 907, 913 },
                    { 879, "10", null, new Guid("9992dad4-ccb8-4a0c-abcc-878d498e4899"), "62", 905, 917 },
                    { 880, "186", null, new Guid("9992dad4-ccb8-4a0c-abcc-878d498e4899"), "27", 906, 911 },
                    { 885, "182", null, new Guid("39fa266f-6e3a-4726-9f1e-1fe1ef0ae497"), "82", 904, 919 },
                    { 886, "197", null, new Guid("39fa266f-6e3a-4726-9f1e-1fe1ef0ae497"), "51", 902, 916 },
                    { 891, "186", null, new Guid("d918fe9c-e16d-4724-b24b-48662dfc21e6"), "62", 907, 911 },
                    { 892, "188", null, new Guid("d918fe9c-e16d-4724-b24b-48662dfc21e6"), "38", 907, 918 },
                    { 897, "11", null, new Guid("506d8596-eb92-4b8a-b284-5b9374a0fa87"), "43", 902, 913 },
                    { 898, "146", null, new Guid("506d8596-eb92-4b8a-b284-5b9374a0fa87"), "28", 901, 912 }
                });

            migrationBuilder.InsertData(
                table: "VacancyResponsibility",
                columns: new[] { "ResponsibilityId", "VacancyId" },
                values: new object[,]
                {
                    { 1, 841 },
                    { 2, 841 },
                    { 3, 841 },
                    { 4, 841 },
                    { 5, 841 },
                    { 6, 841 },
                    { 7, 841 },
                    { 8, 841 },
                    { 9, 841 },
                    { 10, 841 },
                    { 1, 842 },
                    { 2, 842 },
                    { 3, 842 },
                    { 4, 842 },
                    { 5, 842 },
                    { 6, 842 },
                    { 7, 842 },
                    { 8, 842 },
                    { 9, 842 },
                    { 10, 842 },
                    { 1, 847 },
                    { 2, 847 },
                    { 3, 847 },
                    { 4, 847 },
                    { 5, 847 },
                    { 6, 847 },
                    { 7, 847 },
                    { 8, 847 },
                    { 9, 847 },
                    { 10, 847 },
                    { 1, 848 },
                    { 2, 848 },
                    { 3, 848 },
                    { 4, 848 },
                    { 5, 848 },
                    { 6, 848 },
                    { 7, 848 },
                    { 8, 848 },
                    { 9, 848 },
                    { 10, 848 },
                    { 1, 853 },
                    { 2, 853 },
                    { 3, 853 },
                    { 4, 853 },
                    { 5, 853 },
                    { 6, 853 },
                    { 7, 853 },
                    { 8, 853 },
                    { 9, 853 },
                    { 10, 853 },
                    { 1, 854 },
                    { 2, 854 },
                    { 3, 854 },
                    { 4, 854 },
                    { 5, 854 },
                    { 6, 854 },
                    { 7, 854 },
                    { 8, 854 },
                    { 9, 854 },
                    { 10, 854 },
                    { 1, 859 },
                    { 2, 859 },
                    { 3, 859 },
                    { 4, 859 },
                    { 5, 859 },
                    { 6, 859 },
                    { 7, 859 },
                    { 8, 859 },
                    { 9, 859 },
                    { 10, 859 },
                    { 1, 860 },
                    { 2, 860 },
                    { 3, 860 },
                    { 4, 860 },
                    { 5, 860 },
                    { 6, 860 },
                    { 7, 860 },
                    { 8, 860 },
                    { 9, 860 },
                    { 10, 860 },
                    { 1, 865 },
                    { 2, 865 },
                    { 3, 865 },
                    { 4, 865 },
                    { 5, 865 },
                    { 6, 865 },
                    { 7, 865 },
                    { 8, 865 },
                    { 9, 865 },
                    { 10, 865 },
                    { 1, 866 },
                    { 2, 866 },
                    { 3, 866 },
                    { 4, 866 },
                    { 5, 866 },
                    { 6, 866 },
                    { 7, 866 },
                    { 8, 866 },
                    { 9, 866 },
                    { 10, 866 },
                    { 1, 871 },
                    { 2, 871 },
                    { 3, 871 },
                    { 4, 871 },
                    { 5, 871 },
                    { 6, 871 },
                    { 7, 871 },
                    { 8, 871 },
                    { 9, 871 },
                    { 10, 871 },
                    { 1, 872 },
                    { 2, 872 },
                    { 3, 872 },
                    { 4, 872 },
                    { 5, 872 },
                    { 6, 872 },
                    { 7, 872 },
                    { 8, 872 },
                    { 9, 872 },
                    { 10, 872 },
                    { 1, 877 },
                    { 2, 877 },
                    { 3, 877 },
                    { 4, 877 },
                    { 5, 877 },
                    { 6, 877 },
                    { 7, 877 },
                    { 8, 877 },
                    { 9, 877 },
                    { 10, 877 },
                    { 1, 878 },
                    { 2, 878 },
                    { 3, 878 },
                    { 4, 878 },
                    { 5, 878 },
                    { 6, 878 },
                    { 7, 878 },
                    { 8, 878 },
                    { 9, 878 },
                    { 10, 878 },
                    { 1, 883 },
                    { 2, 883 },
                    { 3, 883 },
                    { 4, 883 },
                    { 5, 883 },
                    { 6, 883 },
                    { 7, 883 },
                    { 8, 883 },
                    { 9, 883 },
                    { 10, 883 },
                    { 1, 884 },
                    { 2, 884 },
                    { 3, 884 },
                    { 4, 884 },
                    { 5, 884 },
                    { 6, 884 },
                    { 7, 884 },
                    { 8, 884 },
                    { 9, 884 },
                    { 10, 884 },
                    { 1, 889 },
                    { 2, 889 },
                    { 3, 889 },
                    { 4, 889 },
                    { 5, 889 },
                    { 6, 889 },
                    { 7, 889 },
                    { 8, 889 },
                    { 9, 889 },
                    { 10, 889 },
                    { 1, 890 },
                    { 2, 890 },
                    { 3, 890 },
                    { 4, 890 },
                    { 5, 890 },
                    { 6, 890 },
                    { 7, 890 },
                    { 8, 890 },
                    { 9, 890 },
                    { 10, 890 },
                    { 1, 895 },
                    { 2, 895 },
                    { 3, 895 },
                    { 4, 895 },
                    { 5, 895 },
                    { 6, 895 },
                    { 7, 895 },
                    { 8, 895 },
                    { 9, 895 },
                    { 10, 895 },
                    { 1, 896 },
                    { 2, 896 },
                    { 3, 896 },
                    { 4, 896 },
                    { 5, 896 },
                    { 6, 896 },
                    { 7, 896 },
                    { 8, 896 },
                    { 9, 896 },
                    { 10, 896 }
                });

            migrationBuilder.InsertData(
                table: "VacancySkill",
                columns: new[] { "SkillId", "VacancyId" },
                values: new object[,]
                {
                    { 1, 841 },
                    { 2, 841 },
                    { 3, 841 },
                    { 4, 841 },
                    { 5, 841 },
                    { 6, 841 },
                    { 7, 841 },
                    { 8, 841 },
                    { 9, 841 },
                    { 10, 841 },
                    { 1, 842 },
                    { 2, 842 },
                    { 3, 842 },
                    { 4, 842 },
                    { 5, 842 },
                    { 6, 842 },
                    { 7, 842 },
                    { 8, 842 },
                    { 9, 842 },
                    { 10, 842 },
                    { 1, 847 },
                    { 2, 847 },
                    { 3, 847 },
                    { 4, 847 },
                    { 5, 847 },
                    { 6, 847 },
                    { 7, 847 },
                    { 8, 847 },
                    { 9, 847 },
                    { 10, 847 },
                    { 1, 848 },
                    { 2, 848 },
                    { 3, 848 },
                    { 4, 848 },
                    { 5, 848 },
                    { 6, 848 },
                    { 7, 848 },
                    { 8, 848 },
                    { 9, 848 },
                    { 10, 848 },
                    { 1, 853 },
                    { 2, 853 },
                    { 3, 853 },
                    { 4, 853 },
                    { 5, 853 },
                    { 6, 853 },
                    { 7, 853 },
                    { 8, 853 },
                    { 9, 853 },
                    { 10, 853 },
                    { 1, 854 },
                    { 2, 854 },
                    { 3, 854 },
                    { 4, 854 },
                    { 5, 854 },
                    { 6, 854 },
                    { 7, 854 },
                    { 8, 854 },
                    { 9, 854 },
                    { 10, 854 },
                    { 1, 859 },
                    { 2, 859 },
                    { 3, 859 },
                    { 4, 859 },
                    { 5, 859 },
                    { 6, 859 },
                    { 7, 859 },
                    { 8, 859 },
                    { 9, 859 },
                    { 10, 859 },
                    { 1, 860 },
                    { 2, 860 },
                    { 3, 860 },
                    { 4, 860 },
                    { 5, 860 },
                    { 6, 860 },
                    { 7, 860 },
                    { 8, 860 },
                    { 9, 860 },
                    { 10, 860 },
                    { 1, 865 },
                    { 2, 865 },
                    { 3, 865 },
                    { 4, 865 },
                    { 5, 865 },
                    { 6, 865 },
                    { 7, 865 },
                    { 8, 865 },
                    { 9, 865 },
                    { 10, 865 },
                    { 1, 866 },
                    { 2, 866 },
                    { 3, 866 },
                    { 4, 866 },
                    { 5, 866 },
                    { 6, 866 },
                    { 7, 866 },
                    { 8, 866 },
                    { 9, 866 },
                    { 10, 866 },
                    { 1, 871 },
                    { 2, 871 },
                    { 3, 871 },
                    { 4, 871 },
                    { 5, 871 },
                    { 6, 871 },
                    { 7, 871 },
                    { 8, 871 },
                    { 9, 871 },
                    { 10, 871 },
                    { 1, 872 },
                    { 2, 872 },
                    { 3, 872 },
                    { 4, 872 },
                    { 5, 872 },
                    { 6, 872 },
                    { 7, 872 },
                    { 8, 872 },
                    { 9, 872 },
                    { 10, 872 },
                    { 1, 877 },
                    { 2, 877 },
                    { 3, 877 },
                    { 4, 877 },
                    { 5, 877 },
                    { 6, 877 },
                    { 7, 877 },
                    { 8, 877 },
                    { 9, 877 },
                    { 10, 877 },
                    { 1, 878 },
                    { 2, 878 },
                    { 3, 878 },
                    { 4, 878 },
                    { 5, 878 },
                    { 6, 878 },
                    { 7, 878 },
                    { 8, 878 },
                    { 9, 878 },
                    { 10, 878 },
                    { 1, 883 },
                    { 2, 883 },
                    { 3, 883 },
                    { 4, 883 },
                    { 5, 883 },
                    { 6, 883 },
                    { 7, 883 },
                    { 8, 883 },
                    { 9, 883 },
                    { 10, 883 },
                    { 1, 884 },
                    { 2, 884 },
                    { 3, 884 },
                    { 4, 884 },
                    { 5, 884 },
                    { 6, 884 },
                    { 7, 884 },
                    { 8, 884 },
                    { 9, 884 },
                    { 10, 884 },
                    { 1, 889 },
                    { 2, 889 },
                    { 3, 889 },
                    { 4, 889 },
                    { 5, 889 },
                    { 6, 889 },
                    { 7, 889 },
                    { 8, 889 },
                    { 9, 889 },
                    { 10, 889 },
                    { 1, 890 },
                    { 2, 890 },
                    { 3, 890 },
                    { 4, 890 },
                    { 5, 890 },
                    { 6, 890 },
                    { 7, 890 },
                    { 8, 890 },
                    { 9, 890 },
                    { 10, 890 },
                    { 1, 895 },
                    { 2, 895 },
                    { 3, 895 },
                    { 4, 895 },
                    { 5, 895 },
                    { 6, 895 },
                    { 7, 895 },
                    { 8, 895 },
                    { 9, 895 },
                    { 10, 895 },
                    { 1, 896 },
                    { 2, 896 },
                    { 3, 896 },
                    { 4, 896 },
                    { 5, 896 },
                    { 6, 896 },
                    { 7, 896 },
                    { 8, 896 },
                    { 9, 896 },
                    { 10, 896 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CompanyId",
                table: "Address",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ExternalId",
                table: "Address",
                column: "ExternalId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_LocalityId",
                table: "Address",
                column: "LocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StreetId",
                table: "Address",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_Locality_LocalityTypeId",
                table: "Locality",
                column: "LocalityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Phone_ExternalId",
                table: "Phone",
                column: "ExternalId");

            migrationBuilder.CreateIndex(
                name: "IX_Street_StreeTypetId",
                table: "Street",
                column: "StreeTypetId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_CompanyId",
                table: "Vacancy",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_EducationId",
                table: "Vacancy",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacancy_PositionId",
                table: "Vacancy",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyResponsibility_ResponsibilityId",
                table: "VacancyResponsibility",
                column: "ResponsibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancySkill_SkillId",
                table: "VacancySkill",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "VacancyResponsibility");

            migrationBuilder.DropTable(
                name: "VacancySkill");

            migrationBuilder.DropTable(
                name: "Locality");

            migrationBuilder.DropTable(
                name: "Street");

            migrationBuilder.DropTable(
                name: "Responsibility");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "Vacancy");

            migrationBuilder.DropTable(
                name: "LocalityType");

            migrationBuilder.DropTable(
                name: "StreetType");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
