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
                    LowerAge = table.Column<double>(type: "double precision", nullable: true),
                    TopAge = table.Column<double>(type: "double precision", nullable: true),
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
                    { new Guid("08a5b443-5389-4bd6-ae90-b2e743637db3"), "sunflower@mail.ru", "ЗАО Подсолнух", "Подсолнух" },
                    { new Guid("4edbffc5-6fb8-4601-b255-cc753c0f7a35"), "horizon@mail.ru", "ООО Горизонт", "Горизонт" },
                    { new Guid("5447902c-550c-4da8-85b1-d718597e8538"), "daisy@mail.ru", "ООО Ромашка", "Ромашка" },
                    { new Guid("5ce61d94-e1ae-43ed-ad19-57e0092cb0d3"), "firefly@mail.ru", "ООО Светлячок", "Светлячок" },
                    { new Guid("7c784e84-12e4-49f1-929c-0de556a292b4"), "valley@mail.ru", "ООО Долина", "Долина" },
                    { new Guid("a570361e-c8e0-4266-8162-e58c0573aeaf"), "wave@mail.ru", "ПАО Волна", "Волна" },
                    { new Guid("b6fb6c7a-795e-417a-b18d-45d640fb291b"), "mountain@mail.ru", "ООО Гора", "Гора" },
                    { new Guid("e2be54f7-eb05-4526-8312-09d2208d3179"), "forest@mail.ru", "ПАО Лес", "Лес" },
                    { new Guid("e500222b-e06e-4ca2-919a-a435921dc6b0"), "sunset@mail.ru", "ПАО Закат", "Закат" },
                    { new Guid("ec8a261f-6621-4e4a-9847-7a0fc7846244"), "breeze@mail.ru", "ЗАО Ветерок", "Ветерок" }
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
                    { 10, "Владение графическими редакторами (например, CorelDRAW)" }
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
                    { 901, 1, "Черничка", null },
                    { 902, 3, "Терновка", null },
                    { 903, 2, "Заборье", null },
                    { 904, 1, "Липово", null },
                    { 905, 1, "Степаново", null },
                    { 906, 2, "Березовка", null },
                    { 907, 4, "Каменка", null },
                    { 908, 3, "Вязовка", null },
                    { 909, 3, "Дубровка", null },
                    { 910, 1, "Погорелка", null }
                });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "PhoneId", "EntityType", "ExternalId", "PhoneNumber" },
                values: new object[,]
                {
                    { 845, 0, new Guid("7c784e84-12e4-49f1-929c-0de556a292b4"), "+79033875457" },
                    { 846, 0, new Guid("7c784e84-12e4-49f1-929c-0de556a292b4"), "+79766933506" },
                    { 851, 0, new Guid("a570361e-c8e0-4266-8162-e58c0573aeaf"), "+79986462980" },
                    { 852, 0, new Guid("a570361e-c8e0-4266-8162-e58c0573aeaf"), "+79672486984" },
                    { 857, 0, new Guid("b6fb6c7a-795e-417a-b18d-45d640fb291b"), "+79842194493" },
                    { 858, 0, new Guid("b6fb6c7a-795e-417a-b18d-45d640fb291b"), "+79605531356" },
                    { 863, 0, new Guid("5ce61d94-e1ae-43ed-ad19-57e0092cb0d3"), "+79596283747" },
                    { 864, 0, new Guid("5ce61d94-e1ae-43ed-ad19-57e0092cb0d3"), "+79343315574" },
                    { 869, 0, new Guid("e500222b-e06e-4ca2-919a-a435921dc6b0"), "+79611247798" },
                    { 870, 0, new Guid("e500222b-e06e-4ca2-919a-a435921dc6b0"), "+79286107762" },
                    { 875, 0, new Guid("ec8a261f-6621-4e4a-9847-7a0fc7846244"), "+79116408137" },
                    { 876, 0, new Guid("ec8a261f-6621-4e4a-9847-7a0fc7846244"), "+79893718144" },
                    { 881, 0, new Guid("4edbffc5-6fb8-4601-b255-cc753c0f7a35"), "+79677594150" },
                    { 882, 0, new Guid("4edbffc5-6fb8-4601-b255-cc753c0f7a35"), "+79573594996" },
                    { 887, 0, new Guid("e2be54f7-eb05-4526-8312-09d2208d3179"), "+79115721323" },
                    { 888, 0, new Guid("e2be54f7-eb05-4526-8312-09d2208d3179"), "+79488304442" },
                    { 893, 0, new Guid("08a5b443-5389-4bd6-ae90-b2e743637db3"), "+79703061525" },
                    { 894, 0, new Guid("08a5b443-5389-4bd6-ae90-b2e743637db3"), "+79638192485" },
                    { 899, 0, new Guid("5447902c-550c-4da8-85b1-d718597e8538"), "+79617332378" },
                    { 900, 0, new Guid("5447902c-550c-4da8-85b1-d718597e8538"), "+79774639443" }
                });

            migrationBuilder.InsertData(
                table: "Street",
                columns: new[] { "StreetId", "Name", "ShortName", "StreeTypetId" },
                values: new object[,]
                {
                    { 911, "Луговая", null, 3 },
                    { 912, "Садовая", null, 2 },
                    { 913, "Заречная", null, 3 },
                    { 914, "Новая", null, 5 },
                    { 915, "Школьная", null, 2 },
                    { 916, "Центральная", null, 3 },
                    { 917, "Молодежная", null, 4 },
                    { 918, "Советская", null, 3 },
                    { 919, "Мира", null, 4 },
                    { 920, "Ленина", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Vacancy",
                columns: new[] { "VacancyId", "CloseDate", "CompanyId", "EducationId", "Gender", "LowerAge", "LowerSalary", "Name", "OpenDate", "PositionId", "SocialPackage", "TopAge", "UpperSalary", "WorkBookRegistration" },
                values: new object[,]
                {
                    { 841, null, new Guid("7c784e84-12e4-49f1-929c-0de556a292b4"), 2, "Не указан", 19.0, 29000.0, "Вакансия 2 в <ООО Долина>", new DateTime(2023, 9, 5, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(7654), 8, true, 65.0, 77000.0, false },
                    { 842, new DateTime(2023, 10, 7, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(7622), new Guid("7c784e84-12e4-49f1-929c-0de556a292b4"), 4, "Женский", 19.0, 43000.0, "Вакансия 1 в <ООО Долина>", new DateTime(2023, 9, 13, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(7621), 7, true, 50.0, 83000.0, false },
                    { 847, new DateTime(2023, 10, 4, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(7547), new Guid("a570361e-c8e0-4266-8162-e58c0573aeaf"), 4, "Не указан", 20.0, 49000.0, "Вакансия 2 в <ПАО Волна>", new DateTime(2023, 8, 24, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(7546), 5, true, 56.0, 71000.0, false },
                    { 848, new DateTime(2023, 9, 20, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(7517), new Guid("a570361e-c8e0-4266-8162-e58c0573aeaf"), 1, "Мужской", 22.0, 33000.0, "Вакансия 1 в <ПАО Волна>", new DateTime(2023, 8, 22, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(7517), 6, true, 58.0, 92000.0, false },
                    { 853, null, new Guid("b6fb6c7a-795e-417a-b18d-45d640fb291b"), 2, "Мужской", 20.0, 35000.0, "Вакансия 2 в <ООО Гора>", new DateTime(2023, 8, 29, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(7443), 9, true, 57.0, 66000.0, false },
                    { 854, null, new Guid("b6fb6c7a-795e-417a-b18d-45d640fb291b"), 4, "Не указан", 21.0, 46000.0, "Вакансия 1 в <ООО Гора>", new DateTime(2023, 8, 31, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(7411), 2, false, 56.0, 76000.0, true },
                    { 859, new DateTime(2023, 10, 5, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(7335), new Guid("5ce61d94-e1ae-43ed-ad19-57e0092cb0d3"), 2, "Не указан", 19.0, 42000.0, "Вакансия 2 в <ООО Светлячок>", new DateTime(2023, 8, 22, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(7335), 5, false, 65.0, 88000.0, true },
                    { 860, null, new Guid("5ce61d94-e1ae-43ed-ad19-57e0092cb0d3"), 1, "Женский", 22.0, 58000.0, "Вакансия 1 в <ООО Светлячок>", new DateTime(2023, 9, 14, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(7307), 3, false, 58.0, 61000.0, true },
                    { 865, new DateTime(2023, 9, 30, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(7230), new Guid("e500222b-e06e-4ca2-919a-a435921dc6b0"), 3, "Мужской", 20.0, 59000.0, "Вакансия 2 в <ПАО Закат>", new DateTime(2023, 9, 13, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(7229), 2, false, 55.0, 80000.0, true },
                    { 866, null, new Guid("e500222b-e06e-4ca2-919a-a435921dc6b0"), 2, "Мужской", 20.0, 42000.0, "Вакансия 1 в <ПАО Закат>", new DateTime(2023, 8, 30, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(7197), 1, false, 60.0, 75000.0, false },
                    { 871, null, new Guid("ec8a261f-6621-4e4a-9847-7a0fc7846244"), 2, "Мужской", 21.0, 53000.0, "Вакансия 2 в <ЗАО Ветерок>", new DateTime(2023, 8, 24, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(7119), 9, true, 65.0, 75000.0, false },
                    { 872, null, new Guid("ec8a261f-6621-4e4a-9847-7a0fc7846244"), 2, "Не указан", 19.0, 41000.0, "Вакансия 1 в <ЗАО Ветерок>", new DateTime(2023, 9, 17, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(7088), 1, false, 62.0, 92000.0, false },
                    { 877, null, new Guid("4edbffc5-6fb8-4601-b255-cc753c0f7a35"), 1, "Женский", 18.0, 26000.0, "Вакансия 2 в <ООО Горизонт>", new DateTime(2023, 9, 12, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(7017), 2, false, 58.0, 65000.0, true },
                    { 878, null, new Guid("4edbffc5-6fb8-4601-b255-cc753c0f7a35"), 1, "Мужской", 19.0, 40000.0, "Вакансия 1 в <ООО Горизонт>", new DateTime(2023, 8, 21, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(6983), 3, true, 52.0, 76000.0, true },
                    { 883, null, new Guid("e2be54f7-eb05-4526-8312-09d2208d3179"), 1, "Не указан", 19.0, 47000.0, "Вакансия 2 в <ПАО Лес>", new DateTime(2023, 9, 12, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(6910), 2, false, 61.0, 73000.0, false },
                    { 884, new DateTime(2023, 9, 21, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(6878), new Guid("e2be54f7-eb05-4526-8312-09d2208d3179"), 4, "Не указан", 22.0, 29000.0, "Вакансия 1 в <ПАО Лес>", new DateTime(2023, 9, 15, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(6878), 9, false, 60.0, 91000.0, false },
                    { 889, new DateTime(2023, 9, 21, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(6777), new Guid("08a5b443-5389-4bd6-ae90-b2e743637db3"), 2, "Женский", 20.0, 30000.0, "Вакансия 2 в <ЗАО Подсолнух>", new DateTime(2023, 9, 16, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(6777), 6, true, 57.0, 95000.0, false },
                    { 890, new DateTime(2023, 9, 27, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(6747), new Guid("08a5b443-5389-4bd6-ae90-b2e743637db3"), 1, "Женский", 21.0, 41000.0, "Вакансия 1 в <ЗАО Подсолнух>", new DateTime(2023, 9, 8, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(6746), 2, false, 56.0, 91000.0, false },
                    { 895, new DateTime(2023, 9, 21, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(6663), new Guid("5447902c-550c-4da8-85b1-d718597e8538"), 2, "Мужской", 18.0, 25000.0, "Вакансия 2 в <ООО Ромашка>", new DateTime(2023, 9, 16, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(6661), 5, true, 54.0, 62000.0, false },
                    { 896, null, new Guid("5447902c-550c-4da8-85b1-d718597e8538"), 2, "Мужской", 23.0, 32000.0, "Вакансия 1 в <ООО Ромашка>", new DateTime(2023, 9, 12, 19, 44, 44, 369, DateTimeKind.Utc).AddTicks(6606), 4, true, 69.0, 64000.0, true }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "Apartment", "CompanyId", "ExternalId", "House", "LocalityId", "StreetId" },
                values: new object[,]
                {
                    { 843, "44", null, new Guid("7c784e84-12e4-49f1-929c-0de556a292b4"), "98", 908, 915 },
                    { 844, "125", null, new Guid("7c784e84-12e4-49f1-929c-0de556a292b4"), "94", 906, 915 },
                    { 849, "20", null, new Guid("a570361e-c8e0-4266-8162-e58c0573aeaf"), "77", 909, 913 },
                    { 850, "15", null, new Guid("a570361e-c8e0-4266-8162-e58c0573aeaf"), "37", 903, 912 },
                    { 855, "23", null, new Guid("b6fb6c7a-795e-417a-b18d-45d640fb291b"), "29", 909, 911 },
                    { 856, "59", null, new Guid("b6fb6c7a-795e-417a-b18d-45d640fb291b"), "5", 906, 919 },
                    { 861, "34", null, new Guid("5ce61d94-e1ae-43ed-ad19-57e0092cb0d3"), "24", 901, 911 },
                    { 862, "58", null, new Guid("5ce61d94-e1ae-43ed-ad19-57e0092cb0d3"), "72", 910, 916 },
                    { 867, "99", null, new Guid("e500222b-e06e-4ca2-919a-a435921dc6b0"), "89", 908, 912 },
                    { 868, "123", null, new Guid("e500222b-e06e-4ca2-919a-a435921dc6b0"), "69", 904, 916 },
                    { 873, "171", null, new Guid("ec8a261f-6621-4e4a-9847-7a0fc7846244"), "58", 910, 911 },
                    { 874, "86", null, new Guid("ec8a261f-6621-4e4a-9847-7a0fc7846244"), "66", 906, 920 },
                    { 879, "20", null, new Guid("4edbffc5-6fb8-4601-b255-cc753c0f7a35"), "91", 907, 915 },
                    { 880, "107", null, new Guid("4edbffc5-6fb8-4601-b255-cc753c0f7a35"), "22", 905, 920 },
                    { 885, "55", null, new Guid("e2be54f7-eb05-4526-8312-09d2208d3179"), "83", 908, 913 },
                    { 886, "129", null, new Guid("e2be54f7-eb05-4526-8312-09d2208d3179"), "80", 903, 911 },
                    { 891, "65", null, new Guid("08a5b443-5389-4bd6-ae90-b2e743637db3"), "29", 909, 920 },
                    { 892, "197", null, new Guid("08a5b443-5389-4bd6-ae90-b2e743637db3"), "33", 910, 911 },
                    { 897, "144", null, new Guid("5447902c-550c-4da8-85b1-d718597e8538"), "3", 901, 920 },
                    { 898, "129", null, new Guid("5447902c-550c-4da8-85b1-d718597e8538"), "9", 908, 913 }
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
