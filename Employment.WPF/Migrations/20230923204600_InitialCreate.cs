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
                    { new Guid("05242870-9d27-499a-94cc-4889bfabe199"), "mountain@mail.ru", "ООО Гора", "Гора" },
                    { new Guid("3126b9e8-4464-4b04-8d42-a80007967613"), "breeze@mail.ru", "ЗАО Ветерок", "Ветерок" },
                    { new Guid("5592cf0c-c209-4d35-9705-2745a54f66f7"), "wave@mail.ru", "ПАО Волна", "Волна" },
                    { new Guid("6e4737f9-d1c5-407c-a0ea-e7f2208d3418"), "forest@mail.ru", "ПАО Лес", "Лес" },
                    { new Guid("8c35fb04-1849-49db-84af-bccb5fc72358"), "daisy@mail.ru", "ООО Ромашка", "Ромашка" },
                    { new Guid("8c532375-700c-48fd-a6f3-b6296451b5a2"), "firefly@mail.ru", "ООО Светлячок", "Светлячок" },
                    { new Guid("9c90e6da-bbf8-47f1-bb1e-92935304fc41"), "horizon@mail.ru", "ООО Горизонт", "Горизонт" },
                    { new Guid("ab89ca0b-0990-4da4-8c5d-ede3005d23a4"), "valley@mail.ru", "ООО Долина", "Долина" },
                    { new Guid("c834819a-091a-4dfe-b8e8-2fba4700653e"), "sunflower@mail.ru", "ЗАО Подсолнух", "Подсолнух" },
                    { new Guid("e9d9a204-4c5c-41dd-8c52-720d61b6450a"), "sunset@mail.ru", "ПАО Закат", "Закат" }
                });

            migrationBuilder.InsertData(
                table: "Education",
                columns: new[] { "EducationId", "Level" },
                values: new object[,]
                {
                    { 1, "Не имеет значения" },
                    { 2, "Начальное образование" },
                    { 3, "Основное общее образование" },
                    { 4, "Среднее общее образование" },
                    { 5, "Среднее профессиональное образование" },
                    { 6, "Высшее образование" }
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
                    { 901, 5, "Черничка", null },
                    { 902, 1, "Терновка", null },
                    { 903, 4, "Заборье", null },
                    { 904, 1, "Липово", null },
                    { 905, 5, "Степаново", null },
                    { 906, 3, "Березовка", null },
                    { 907, 2, "Каменка", null },
                    { 908, 2, "Вязовка", null },
                    { 909, 4, "Дубровка", null },
                    { 910, 5, "Погорелка", null }
                });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "PhoneId", "EntityType", "ExternalId", "PhoneNumber" },
                values: new object[,]
                {
                    { 845, 0, new Guid("ab89ca0b-0990-4da4-8c5d-ede3005d23a4"), "+79243485806" },
                    { 846, 0, new Guid("ab89ca0b-0990-4da4-8c5d-ede3005d23a4"), "+79431546384" },
                    { 851, 0, new Guid("5592cf0c-c209-4d35-9705-2745a54f66f7"), "+79025682032" },
                    { 852, 0, new Guid("5592cf0c-c209-4d35-9705-2745a54f66f7"), "+79838985139" },
                    { 857, 0, new Guid("05242870-9d27-499a-94cc-4889bfabe199"), "+79386147893" },
                    { 858, 0, new Guid("05242870-9d27-499a-94cc-4889bfabe199"), "+79805421373" },
                    { 863, 0, new Guid("8c532375-700c-48fd-a6f3-b6296451b5a2"), "+79178241147" },
                    { 864, 0, new Guid("8c532375-700c-48fd-a6f3-b6296451b5a2"), "+79489507349" },
                    { 869, 0, new Guid("e9d9a204-4c5c-41dd-8c52-720d61b6450a"), "+79294878228" },
                    { 870, 0, new Guid("e9d9a204-4c5c-41dd-8c52-720d61b6450a"), "+79356214723" },
                    { 875, 0, new Guid("3126b9e8-4464-4b04-8d42-a80007967613"), "+79805929118" },
                    { 876, 0, new Guid("3126b9e8-4464-4b04-8d42-a80007967613"), "+79185501390" },
                    { 881, 0, new Guid("9c90e6da-bbf8-47f1-bb1e-92935304fc41"), "+79375656592" },
                    { 882, 0, new Guid("9c90e6da-bbf8-47f1-bb1e-92935304fc41"), "+79752798646" },
                    { 887, 0, new Guid("6e4737f9-d1c5-407c-a0ea-e7f2208d3418"), "+79047813897" },
                    { 888, 0, new Guid("6e4737f9-d1c5-407c-a0ea-e7f2208d3418"), "+79681487374" },
                    { 893, 0, new Guid("c834819a-091a-4dfe-b8e8-2fba4700653e"), "+79967488457" },
                    { 894, 0, new Guid("c834819a-091a-4dfe-b8e8-2fba4700653e"), "+79977283998" },
                    { 899, 0, new Guid("8c35fb04-1849-49db-84af-bccb5fc72358"), "+79958366415" },
                    { 900, 0, new Guid("8c35fb04-1849-49db-84af-bccb5fc72358"), "+79984446186" }
                });

            migrationBuilder.InsertData(
                table: "Street",
                columns: new[] { "StreetId", "Name", "ShortName", "StreeTypetId" },
                values: new object[,]
                {
                    { 911, "Луговая", null, 5 },
                    { 912, "Садовая", null, 1 },
                    { 913, "Заречная", null, 2 },
                    { 914, "Новая", null, 4 },
                    { 915, "Школьная", null, 5 },
                    { 916, "Центральная", null, 2 },
                    { 917, "Молодежная", null, 2 },
                    { 918, "Советская", null, 1 },
                    { 919, "Мира", null, 5 },
                    { 920, "Ленина", null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Vacancy",
                columns: new[] { "VacancyId", "CloseDate", "CompanyId", "EducationId", "Gender", "LowerAge", "LowerSalary", "Name", "OpenDate", "PositionId", "SocialPackage", "TopAge", "UpperSalary", "WorkBookRegistration" },
                values: new object[,]
                {
                    { 841, new DateTime(2023, 10, 14, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9746), new Guid("ab89ca0b-0990-4da4-8c5d-ede3005d23a4"), 1, "Мужской", 19, 30000.0, "Вакансия 2 в <ООО Долина>", new DateTime(2023, 9, 17, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9746), 9, false, 68, 99000.0, false },
                    { 842, null, new Guid("ab89ca0b-0990-4da4-8c5d-ede3005d23a4"), 5, "Мужской", 23, 33000.0, "Вакансия 1 в <ООО Долина>", new DateTime(2023, 9, 10, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9726), 5, true, 65, 92000.0, false },
                    { 847, new DateTime(2023, 10, 2, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9670), new Guid("5592cf0c-c209-4d35-9705-2745a54f66f7"), 2, "Женский", 22, 45000.0, "Вакансия 2 в <ПАО Волна>", new DateTime(2023, 9, 14, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9670), 4, true, 66, 93000.0, false },
                    { 848, new DateTime(2023, 9, 27, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9650), new Guid("5592cf0c-c209-4d35-9705-2745a54f66f7"), 2, "Мужской", 23, 50000.0, "Вакансия 1 в <ПАО Волна>", new DateTime(2023, 9, 5, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9649), 9, true, 52, 78000.0, true },
                    { 853, new DateTime(2023, 10, 4, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9593), new Guid("05242870-9d27-499a-94cc-4889bfabe199"), 3, "Не указан", 22, 27000.0, "Вакансия 2 в <ООО Гора>", new DateTime(2023, 8, 29, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9593), 1, true, 64, 69000.0, true },
                    { 854, new DateTime(2023, 10, 4, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9571), new Guid("05242870-9d27-499a-94cc-4889bfabe199"), 4, "Мужской", 19, 42000.0, "Вакансия 1 в <ООО Гора>", new DateTime(2023, 9, 13, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9571), 1, false, 66, 95000.0, false },
                    { 859, new DateTime(2023, 10, 4, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9516), new Guid("8c532375-700c-48fd-a6f3-b6296451b5a2"), 4, "Не указан", 19, 27000.0, "Вакансия 2 в <ООО Светлячок>", new DateTime(2023, 9, 5, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9516), 7, true, 55, 69000.0, true },
                    { 860, null, new Guid("8c532375-700c-48fd-a6f3-b6296451b5a2"), 3, "Женский", 20, 27000.0, "Вакансия 1 в <ООО Светлячок>", new DateTime(2023, 9, 20, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9497), 7, true, 65, 94000.0, true },
                    { 865, new DateTime(2023, 10, 22, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9432), new Guid("e9d9a204-4c5c-41dd-8c52-720d61b6450a"), 5, "Не указан", 21, 58000.0, "Вакансия 2 в <ПАО Закат>", new DateTime(2023, 9, 23, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9431), 1, true, 52, 87000.0, false },
                    { 866, new DateTime(2023, 10, 16, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9408), new Guid("e9d9a204-4c5c-41dd-8c52-720d61b6450a"), 4, "Не указан", 18, 41000.0, "Вакансия 1 в <ПАО Закат>", new DateTime(2023, 8, 27, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9408), 2, false, 62, 93000.0, false },
                    { 871, new DateTime(2023, 10, 12, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9351), new Guid("3126b9e8-4464-4b04-8d42-a80007967613"), 1, "Не указан", 22, 30000.0, "Вакансия 2 в <ЗАО Ветерок>", new DateTime(2023, 8, 26, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9350), 8, false, 65, 77000.0, true },
                    { 872, null, new Guid("3126b9e8-4464-4b04-8d42-a80007967613"), 1, "Женский", 21, 39000.0, "Вакансия 1 в <ЗАО Ветерок>", new DateTime(2023, 8, 30, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9326), 9, false, 50, 88000.0, true },
                    { 877, null, new Guid("9c90e6da-bbf8-47f1-bb1e-92935304fc41"), 4, "Женский", 22, 56000.0, "Вакансия 2 в <ООО Горизонт>", new DateTime(2023, 9, 17, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9272), 6, false, 58, 90000.0, true },
                    { 878, null, new Guid("9c90e6da-bbf8-47f1-bb1e-92935304fc41"), 1, "Мужской", 19, 48000.0, "Вакансия 1 в <ООО Горизонт>", new DateTime(2023, 9, 12, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9254), 4, true, 50, 62000.0, false },
                    { 883, null, new Guid("6e4737f9-d1c5-407c-a0ea-e7f2208d3418"), 2, "Женский", 21, 55000.0, "Вакансия 2 в <ПАО Лес>", new DateTime(2023, 9, 4, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9198), 2, false, 58, 68000.0, true },
                    { 884, null, new Guid("6e4737f9-d1c5-407c-a0ea-e7f2208d3418"), 3, "Не указан", 19, 53000.0, "Вакансия 1 в <ПАО Лес>", new DateTime(2023, 9, 5, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9175), 7, true, 64, 90000.0, true },
                    { 889, null, new Guid("c834819a-091a-4dfe-b8e8-2fba4700653e"), 4, "Не указан", 19, 45000.0, "Вакансия 2 в <ЗАО Подсолнух>", new DateTime(2023, 9, 6, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9117), 3, true, 53, 87000.0, true },
                    { 890, new DateTime(2023, 10, 15, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9097), new Guid("c834819a-091a-4dfe-b8e8-2fba4700653e"), 3, "Мужской", 23, 34000.0, "Вакансия 1 в <ЗАО Подсолнух>", new DateTime(2023, 9, 6, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9097), 9, false, 58, 82000.0, false },
                    { 895, new DateTime(2023, 10, 10, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9035), new Guid("8c35fb04-1849-49db-84af-bccb5fc72358"), 2, "Не указан", 22, 44000.0, "Вакансия 2 в <ООО Ромашка>", new DateTime(2023, 9, 10, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(9034), 5, false, 50, 92000.0, false },
                    { 896, new DateTime(2023, 10, 10, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(8995), new Guid("8c35fb04-1849-49db-84af-bccb5fc72358"), 4, "Не указан", 19, 50000.0, "Вакансия 1 в <ООО Ромашка>", new DateTime(2023, 9, 20, 20, 46, 0, 48, DateTimeKind.Utc).AddTicks(8986), 6, true, 53, 69000.0, false }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "Apartment", "CompanyId", "ExternalId", "House", "LocalityId", "StreetId" },
                values: new object[,]
                {
                    { 843, "197", null, new Guid("ab89ca0b-0990-4da4-8c5d-ede3005d23a4"), "33", 906, 917 },
                    { 844, "175", null, new Guid("ab89ca0b-0990-4da4-8c5d-ede3005d23a4"), "20", 910, 919 },
                    { 849, "127", null, new Guid("5592cf0c-c209-4d35-9705-2745a54f66f7"), "52", 910, 918 },
                    { 850, "48", null, new Guid("5592cf0c-c209-4d35-9705-2745a54f66f7"), "13", 904, 918 },
                    { 855, "134", null, new Guid("05242870-9d27-499a-94cc-4889bfabe199"), "12", 905, 915 },
                    { 856, "126", null, new Guid("05242870-9d27-499a-94cc-4889bfabe199"), "52", 904, 913 },
                    { 861, "116", null, new Guid("8c532375-700c-48fd-a6f3-b6296451b5a2"), "21", 901, 915 },
                    { 862, "106", null, new Guid("8c532375-700c-48fd-a6f3-b6296451b5a2"), "32", 905, 912 },
                    { 867, "10", null, new Guid("e9d9a204-4c5c-41dd-8c52-720d61b6450a"), "95", 906, 918 },
                    { 868, "157", null, new Guid("e9d9a204-4c5c-41dd-8c52-720d61b6450a"), "58", 903, 919 },
                    { 873, "36", null, new Guid("3126b9e8-4464-4b04-8d42-a80007967613"), "28", 903, 915 },
                    { 874, "60", null, new Guid("3126b9e8-4464-4b04-8d42-a80007967613"), "18", 906, 915 },
                    { 879, "163", null, new Guid("9c90e6da-bbf8-47f1-bb1e-92935304fc41"), "49", 904, 918 },
                    { 880, "44", null, new Guid("9c90e6da-bbf8-47f1-bb1e-92935304fc41"), "34", 909, 913 },
                    { 885, "78", null, new Guid("6e4737f9-d1c5-407c-a0ea-e7f2208d3418"), "29", 902, 911 },
                    { 886, "22", null, new Guid("6e4737f9-d1c5-407c-a0ea-e7f2208d3418"), "64", 907, 920 },
                    { 891, "186", null, new Guid("c834819a-091a-4dfe-b8e8-2fba4700653e"), "59", 906, 916 },
                    { 892, "40", null, new Guid("c834819a-091a-4dfe-b8e8-2fba4700653e"), "55", 907, 914 },
                    { 897, "195", null, new Guid("8c35fb04-1849-49db-84af-bccb5fc72358"), "59", 902, 917 },
                    { 898, "61", null, new Guid("8c35fb04-1849-49db-84af-bccb5fc72358"), "55", 907, 912 }
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
