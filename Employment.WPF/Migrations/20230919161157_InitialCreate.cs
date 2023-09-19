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
                    { new Guid("0bca6cff-2ded-409d-bcc4-fd4078425077"), "firefly@mail.ru", "ООО Светлячок", "Светлячок" },
                    { new Guid("236bb49e-8d2e-4e21-889f-aa46078486ca"), "mountain@mail.ru", "ООО Гора", "Гора" },
                    { new Guid("35e32042-8241-4e07-adde-3f6d3d2775c1"), "daisy@mail.ru", "ООО Ромашка", "Ромашка" },
                    { new Guid("4d1b4cda-3629-4484-bd81-ba7e60b2992a"), "breeze@mail.ru", "ЗАО Ветерок", "Ветерок" },
                    { new Guid("5d6d809d-7241-44f4-bc57-c580218709ed"), "sunset@mail.ru", "ПАО Закат", "Закат" },
                    { new Guid("68b3a388-7379-43bf-b63f-f637a9b282a9"), "wave@mail.ru", "ПАО Волна", "Волна" },
                    { new Guid("94e350e9-a096-4e9c-8ec3-1b121b3de22b"), "valley@mail.ru", "ООО Долина", "Долина" },
                    { new Guid("b09102d8-6e3a-4feb-b8dd-231c436a16f1"), "sunflower@mail.ru", "ЗАО Подсолнух", "Подсолнух" },
                    { new Guid("bd9193c0-3453-4255-84c1-6c3b857b7dcb"), "horizon@mail.ru", "ООО Горизонт", "Горизонт" },
                    { new Guid("e64606e5-8f5f-4cad-a01c-083ffe93a415"), "forest@mail.ru", "ПАО Лес", "Лес" }
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
                    { 901, 4, "Черничка", null },
                    { 902, 1, "Терновка", null },
                    { 903, 1, "Заборье", null },
                    { 904, 4, "Липово", null },
                    { 905, 5, "Степаново", null },
                    { 906, 4, "Березовка", null },
                    { 907, 4, "Каменка", null },
                    { 908, 4, "Вязовка", null },
                    { 909, 4, "Дубровка", null },
                    { 910, 5, "Погорелка", null }
                });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "PhoneId", "EntityType", "ExternalId", "PhoneNumber" },
                values: new object[,]
                {
                    { 845, 0, new Guid("94e350e9-a096-4e9c-8ec3-1b121b3de22b"), "+79062889652" },
                    { 846, 0, new Guid("94e350e9-a096-4e9c-8ec3-1b121b3de22b"), "+79367347366" },
                    { 851, 0, new Guid("68b3a388-7379-43bf-b63f-f637a9b282a9"), "+79911357505" },
                    { 852, 0, new Guid("68b3a388-7379-43bf-b63f-f637a9b282a9"), "+79768167046" },
                    { 857, 0, new Guid("236bb49e-8d2e-4e21-889f-aa46078486ca"), "+79387585177" },
                    { 858, 0, new Guid("236bb49e-8d2e-4e21-889f-aa46078486ca"), "+79698662863" },
                    { 863, 0, new Guid("0bca6cff-2ded-409d-bcc4-fd4078425077"), "+79952371425" },
                    { 864, 0, new Guid("0bca6cff-2ded-409d-bcc4-fd4078425077"), "+79692763457" },
                    { 869, 0, new Guid("5d6d809d-7241-44f4-bc57-c580218709ed"), "+79593448036" },
                    { 870, 0, new Guid("5d6d809d-7241-44f4-bc57-c580218709ed"), "+79079796476" },
                    { 875, 0, new Guid("4d1b4cda-3629-4484-bd81-ba7e60b2992a"), "+79024155738" },
                    { 876, 0, new Guid("4d1b4cda-3629-4484-bd81-ba7e60b2992a"), "+79341328846" },
                    { 881, 0, new Guid("bd9193c0-3453-4255-84c1-6c3b857b7dcb"), "+79854842615" },
                    { 882, 0, new Guid("bd9193c0-3453-4255-84c1-6c3b857b7dcb"), "+79651984552" },
                    { 887, 0, new Guid("e64606e5-8f5f-4cad-a01c-083ffe93a415"), "+79724317587" },
                    { 888, 0, new Guid("e64606e5-8f5f-4cad-a01c-083ffe93a415"), "+79139934169" },
                    { 893, 0, new Guid("b09102d8-6e3a-4feb-b8dd-231c436a16f1"), "+79057402023" },
                    { 894, 0, new Guid("b09102d8-6e3a-4feb-b8dd-231c436a16f1"), "+79887049385" },
                    { 899, 0, new Guid("35e32042-8241-4e07-adde-3f6d3d2775c1"), "+79564199029" },
                    { 900, 0, new Guid("35e32042-8241-4e07-adde-3f6d3d2775c1"), "+79557156213" }
                });

            migrationBuilder.InsertData(
                table: "Street",
                columns: new[] { "StreetId", "Name", "ShortName", "StreeTypetId" },
                values: new object[,]
                {
                    { 911, "Луговая", null, 1 },
                    { 912, "Садовая", null, 2 },
                    { 913, "Заречная", null, 4 },
                    { 914, "Новая", null, 1 },
                    { 915, "Школьная", null, 3 },
                    { 916, "Центральная", null, 4 },
                    { 917, "Молодежная", null, 4 },
                    { 918, "Советская", null, 1 },
                    { 919, "Мира", null, 3 },
                    { 920, "Ленина", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Vacancy",
                columns: new[] { "VacancyId", "CloseDate", "CompanyId", "EducationId", "Gender", "LowerAge", "LowerSalary", "Name", "OpenDate", "PositionId", "SocialPackage", "TopAge", "UpperSalary", "WorkBookRegistration" },
                values: new object[,]
                {
                    { 841, new DateTime(2023, 10, 13, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(5279), new Guid("94e350e9-a096-4e9c-8ec3-1b121b3de22b"), 2, "Женский", 18, 27000.0, "Вакансия 2 в <ООО Долина>", new DateTime(2023, 8, 30, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(5278), 9, false, 62, 73000.0, false },
                    { 842, null, new Guid("94e350e9-a096-4e9c-8ec3-1b121b3de22b"), 2, "Не указан", 18, 27000.0, "Вакансия 1 в <ООО Долина>", new DateTime(2023, 9, 7, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(5232), 8, false, 61, 64000.0, false },
                    { 847, null, new Guid("68b3a388-7379-43bf-b63f-f637a9b282a9"), 1, "Не указан", 21, 27000.0, "Вакансия 2 в <ПАО Волна>", new DateTime(2023, 9, 14, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(5147), 1, true, 56, 87000.0, true },
                    { 848, new DateTime(2023, 10, 7, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(5100), new Guid("68b3a388-7379-43bf-b63f-f637a9b282a9"), 1, "Мужской", 18, 39000.0, "Вакансия 1 в <ПАО Волна>", new DateTime(2023, 9, 18, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(5099), 8, false, 53, 73000.0, false },
                    { 853, new DateTime(2023, 9, 30, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(5014), new Guid("236bb49e-8d2e-4e21-889f-aa46078486ca"), 1, "Не указан", 23, 34000.0, "Вакансия 2 в <ООО Гора>", new DateTime(2023, 8, 31, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(5013), 3, false, 57, 95000.0, false },
                    { 854, new DateTime(2023, 10, 12, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4970), new Guid("236bb49e-8d2e-4e21-889f-aa46078486ca"), 4, "Не указан", 23, 54000.0, "Вакансия 1 в <ООО Гора>", new DateTime(2023, 9, 18, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4969), 6, false, 66, 64000.0, true },
                    { 859, null, new Guid("0bca6cff-2ded-409d-bcc4-fd4078425077"), 4, "Не указан", 19, 26000.0, "Вакансия 2 в <ООО Светлячок>", new DateTime(2023, 9, 16, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4889), 8, false, 60, 83000.0, false },
                    { 860, new DateTime(2023, 9, 21, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4842), new Guid("0bca6cff-2ded-409d-bcc4-fd4078425077"), 3, "Мужской", 22, 48000.0, "Вакансия 1 в <ООО Светлячок>", new DateTime(2023, 8, 26, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4841), 9, true, 63, 76000.0, true },
                    { 865, new DateTime(2023, 10, 13, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4757), new Guid("5d6d809d-7241-44f4-bc57-c580218709ed"), 3, "Не указан", 22, 46000.0, "Вакансия 2 в <ПАО Закат>", new DateTime(2023, 9, 6, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4757), 9, false, 61, 91000.0, false },
                    { 866, new DateTime(2023, 9, 28, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4713), new Guid("5d6d809d-7241-44f4-bc57-c580218709ed"), 3, "Не указан", 23, 57000.0, "Вакансия 1 в <ПАО Закат>", new DateTime(2023, 9, 1, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4712), 8, true, 58, 91000.0, true },
                    { 871, new DateTime(2023, 10, 9, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4633), new Guid("4d1b4cda-3629-4484-bd81-ba7e60b2992a"), 2, "Не указан", 19, 37000.0, "Вакансия 2 в <ЗАО Ветерок>", new DateTime(2023, 9, 17, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4632), 8, true, 57, 61000.0, true },
                    { 872, new DateTime(2023, 9, 28, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4588), new Guid("4d1b4cda-3629-4484-bd81-ba7e60b2992a"), 1, "Женский", 18, 43000.0, "Вакансия 1 в <ЗАО Ветерок>", new DateTime(2023, 9, 10, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4587), 1, false, 51, 76000.0, false },
                    { 877, null, new Guid("bd9193c0-3453-4255-84c1-6c3b857b7dcb"), 3, "Женский", 20, 27000.0, "Вакансия 2 в <ООО Горизонт>", new DateTime(2023, 9, 5, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4503), 1, true, 54, 86000.0, true },
                    { 878, new DateTime(2023, 10, 11, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4460), new Guid("bd9193c0-3453-4255-84c1-6c3b857b7dcb"), 2, "Не указан", 19, 49000.0, "Вакансия 1 в <ООО Горизонт>", new DateTime(2023, 9, 1, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4459), 2, false, 62, 97000.0, false },
                    { 883, null, new Guid("e64606e5-8f5f-4cad-a01c-083ffe93a415"), 1, "Мужской", 19, 57000.0, "Вакансия 2 в <ПАО Лес>", new DateTime(2023, 9, 12, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4370), 9, true, 56, 64000.0, true },
                    { 884, null, new Guid("e64606e5-8f5f-4cad-a01c-083ffe93a415"), 2, "Не указан", 19, 58000.0, "Вакансия 1 в <ПАО Лес>", new DateTime(2023, 8, 31, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4326), 5, true, 56, 77000.0, true },
                    { 889, new DateTime(2023, 10, 2, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4238), new Guid("b09102d8-6e3a-4feb-b8dd-231c436a16f1"), 4, "Мужской", 21, 47000.0, "Вакансия 2 в <ЗАО Подсолнух>", new DateTime(2023, 9, 1, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4237), 2, false, 52, 80000.0, false },
                    { 890, new DateTime(2023, 10, 14, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4190), new Guid("b09102d8-6e3a-4feb-b8dd-231c436a16f1"), 3, "Не указан", 20, 48000.0, "Вакансия 1 в <ЗАО Подсолнух>", new DateTime(2023, 9, 7, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4189), 2, false, 53, 92000.0, true },
                    { 895, new DateTime(2023, 10, 8, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4097), new Guid("35e32042-8241-4e07-adde-3f6d3d2775c1"), 3, "Не указан", 23, 43000.0, "Вакансия 2 в <ООО Ромашка>", new DateTime(2023, 8, 24, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4097), 4, false, 51, 72000.0, true },
                    { 896, new DateTime(2023, 9, 25, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4023), new Guid("35e32042-8241-4e07-adde-3f6d3d2775c1"), 1, "Не указан", 19, 41000.0, "Вакансия 1 в <ООО Ромашка>", new DateTime(2023, 9, 7, 16, 11, 56, 732, DateTimeKind.Utc).AddTicks(4017), 1, true, 53, 67000.0, true }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "Apartment", "CompanyId", "ExternalId", "House", "LocalityId", "StreetId" },
                values: new object[,]
                {
                    { 843, "193", null, new Guid("94e350e9-a096-4e9c-8ec3-1b121b3de22b"), "70", 904, 917 },
                    { 844, "23", null, new Guid("94e350e9-a096-4e9c-8ec3-1b121b3de22b"), "31", 906, 915 },
                    { 849, "15", null, new Guid("68b3a388-7379-43bf-b63f-f637a9b282a9"), "4", 909, 911 },
                    { 850, "114", null, new Guid("68b3a388-7379-43bf-b63f-f637a9b282a9"), "76", 909, 911 },
                    { 855, "60", null, new Guid("236bb49e-8d2e-4e21-889f-aa46078486ca"), "38", 901, 911 },
                    { 856, "151", null, new Guid("236bb49e-8d2e-4e21-889f-aa46078486ca"), "78", 905, 913 },
                    { 861, "160", null, new Guid("0bca6cff-2ded-409d-bcc4-fd4078425077"), "46", 909, 918 },
                    { 862, "95", null, new Guid("0bca6cff-2ded-409d-bcc4-fd4078425077"), "77", 905, 917 },
                    { 867, "67", null, new Guid("5d6d809d-7241-44f4-bc57-c580218709ed"), "4", 904, 919 },
                    { 868, "53", null, new Guid("5d6d809d-7241-44f4-bc57-c580218709ed"), "48", 904, 911 },
                    { 873, "4", null, new Guid("4d1b4cda-3629-4484-bd81-ba7e60b2992a"), "65", 906, 915 },
                    { 874, "60", null, new Guid("4d1b4cda-3629-4484-bd81-ba7e60b2992a"), "40", 901, 919 },
                    { 879, "179", null, new Guid("bd9193c0-3453-4255-84c1-6c3b857b7dcb"), "72", 905, 916 },
                    { 880, "158", null, new Guid("bd9193c0-3453-4255-84c1-6c3b857b7dcb"), "25", 910, 913 },
                    { 885, "181", null, new Guid("e64606e5-8f5f-4cad-a01c-083ffe93a415"), "29", 905, 912 },
                    { 886, "30", null, new Guid("e64606e5-8f5f-4cad-a01c-083ffe93a415"), "11", 906, 914 },
                    { 891, "46", null, new Guid("b09102d8-6e3a-4feb-b8dd-231c436a16f1"), "39", 906, 918 },
                    { 892, "127", null, new Guid("b09102d8-6e3a-4feb-b8dd-231c436a16f1"), "28", 908, 918 },
                    { 897, "39", null, new Guid("35e32042-8241-4e07-adde-3f6d3d2775c1"), "87", 904, 920 },
                    { 898, "3", null, new Guid("35e32042-8241-4e07-adde-3f6d3d2775c1"), "4", 902, 920 }
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
