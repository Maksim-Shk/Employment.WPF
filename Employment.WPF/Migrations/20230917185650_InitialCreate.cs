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
                    { new Guid("00cb7216-f4b6-43db-8849-e18bbb48272c"), "forest@mail.ru", "ПАО Лес", "Лес" },
                    { new Guid("09dc7a08-b773-44cb-9bf2-6b826da12703"), "daisy@mail.ru", "ООО Ромашка", "Ромашка" },
                    { new Guid("1c46902e-e53b-41e9-8517-d274a50cdc2f"), "horizon@mail.ru", "ООО Горизонт", "Горизонт" },
                    { new Guid("305d33d0-4be9-4fb9-a10e-4e7039911815"), "sunflower@mail.ru", "ЗАО Подсолнух", "Подсолнух" },
                    { new Guid("7533b048-2445-4836-8f14-b6acb4c825c4"), "firefly@mail.ru", "ООО Светлячок", "Светлячок" },
                    { new Guid("95c018c1-80a7-4428-bcd0-738e0e2a3b1a"), "breeze@mail.ru", "ЗАО Ветерок", "Ветерок" },
                    { new Guid("95f9bf51-47de-4480-ab55-38a344209670"), "valley@mail.ru", "ООО Долина", "Долина" },
                    { new Guid("b03e0f65-250c-4b83-b6e8-515cd65902a6"), "wave@mail.ru", "ПАО Волна", "Волна" },
                    { new Guid("dc0ab0c3-861e-453f-b626-7b769aa0b7ec"), "mountain@mail.ru", "ООО Гора", "Гора" },
                    { new Guid("fc856d8a-ec49-4b58-bfe2-4228dd2d02bc"), "sunset@mail.ru", "ПАО Закат", "Закат" }
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
                    { 903, 1, "Заборье", null },
                    { 904, 1, "Липово", null },
                    { 905, 4, "Степаново", null },
                    { 906, 2, "Березовка", null },
                    { 907, 3, "Каменка", null },
                    { 908, 2, "Вязовка", null },
                    { 909, 3, "Дубровка", null },
                    { 910, 5, "Погорелка", null }
                });

            migrationBuilder.InsertData(
                table: "Phone",
                columns: new[] { "PhoneId", "EntityType", "ExternalId", "PhoneNumber" },
                values: new object[,]
                {
                    { 845, 0, new Guid("95f9bf51-47de-4480-ab55-38a344209670"), "+79052688856" },
                    { 846, 0, new Guid("95f9bf51-47de-4480-ab55-38a344209670"), "+79275872049" },
                    { 851, 0, new Guid("b03e0f65-250c-4b83-b6e8-515cd65902a6"), "+79441498072" },
                    { 852, 0, new Guid("b03e0f65-250c-4b83-b6e8-515cd65902a6"), "+79144155083" },
                    { 857, 0, new Guid("dc0ab0c3-861e-453f-b626-7b769aa0b7ec"), "+79686073694" },
                    { 858, 0, new Guid("dc0ab0c3-861e-453f-b626-7b769aa0b7ec"), "+79551407915" },
                    { 863, 0, new Guid("7533b048-2445-4836-8f14-b6acb4c825c4"), "+79323563025" },
                    { 864, 0, new Guid("7533b048-2445-4836-8f14-b6acb4c825c4"), "+79979828709" },
                    { 869, 0, new Guid("fc856d8a-ec49-4b58-bfe2-4228dd2d02bc"), "+79987271047" },
                    { 870, 0, new Guid("fc856d8a-ec49-4b58-bfe2-4228dd2d02bc"), "+79833204229" },
                    { 875, 0, new Guid("95c018c1-80a7-4428-bcd0-738e0e2a3b1a"), "+79653241789" },
                    { 876, 0, new Guid("95c018c1-80a7-4428-bcd0-738e0e2a3b1a"), "+79018235088" },
                    { 881, 0, new Guid("1c46902e-e53b-41e9-8517-d274a50cdc2f"), "+79177094732" },
                    { 882, 0, new Guid("1c46902e-e53b-41e9-8517-d274a50cdc2f"), "+79453151667" },
                    { 887, 0, new Guid("00cb7216-f4b6-43db-8849-e18bbb48272c"), "+79144383346" },
                    { 888, 0, new Guid("00cb7216-f4b6-43db-8849-e18bbb48272c"), "+79249244390" },
                    { 893, 0, new Guid("305d33d0-4be9-4fb9-a10e-4e7039911815"), "+79089323170" },
                    { 894, 0, new Guid("305d33d0-4be9-4fb9-a10e-4e7039911815"), "+79114779875" },
                    { 899, 0, new Guid("09dc7a08-b773-44cb-9bf2-6b826da12703"), "+79413929466" },
                    { 900, 0, new Guid("09dc7a08-b773-44cb-9bf2-6b826da12703"), "+79151707023" }
                });

            migrationBuilder.InsertData(
                table: "Street",
                columns: new[] { "StreetId", "Name", "ShortName", "StreeTypetId" },
                values: new object[,]
                {
                    { 911, "Луговая", null, 1 },
                    { 912, "Садовая", null, 5 },
                    { 913, "Заречная", null, 4 },
                    { 914, "Новая", null, 5 },
                    { 915, "Школьная", null, 4 },
                    { 916, "Центральная", null, 1 },
                    { 917, "Молодежная", null, 1 },
                    { 918, "Советская", null, 4 },
                    { 919, "Мира", null, 3 },
                    { 920, "Ленина", null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Vacancy",
                columns: new[] { "VacancyId", "CloseDate", "CompanyId", "EducationId", "Gender", "LowerAge", "LowerSalary", "Name", "OpenDate", "PositionId", "SocialPackage", "TopAge", "UpperSalary", "WorkBookRegistration" },
                values: new object[,]
                {
                    { 841, new DateTime(2023, 10, 6, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(6083), new Guid("95f9bf51-47de-4480-ab55-38a344209670"), 4, "Мужской", 22.0, 40000.0, "Вакансия 2 в <ООО Долина>", new DateTime(2023, 9, 11, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(6083), 6, true, 55.0, 71000.0, false },
                    { 842, null, new Guid("95f9bf51-47de-4480-ab55-38a344209670"), 1, "Не указан", 22.0, 30000.0, "Вакансия 1 в <ООО Долина>", new DateTime(2023, 8, 31, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(6067), 9, false, 68.0, 92000.0, false },
                    { 847, new DateTime(2023, 10, 13, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(6036), new Guid("b03e0f65-250c-4b83-b6e8-515cd65902a6"), 2, "Не указан", 20.0, 32000.0, "Вакансия 2 в <ПАО Волна>", new DateTime(2023, 9, 7, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(6036), 3, false, 68.0, 64000.0, false },
                    { 848, new DateTime(2023, 10, 11, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(6020), new Guid("b03e0f65-250c-4b83-b6e8-515cd65902a6"), 3, "Не указан", 20.0, 53000.0, "Вакансия 1 в <ПАО Волна>", new DateTime(2023, 9, 16, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(6019), 4, true, 60.0, 92000.0, true },
                    { 853, null, new Guid("dc0ab0c3-861e-453f-b626-7b769aa0b7ec"), 4, "Не указан", 21.0, 58000.0, "Вакансия 2 в <ООО Гора>", new DateTime(2023, 9, 7, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5938), 1, false, 61.0, 87000.0, true },
                    { 854, null, new Guid("dc0ab0c3-861e-453f-b626-7b769aa0b7ec"), 1, "Не указан", 22.0, 49000.0, "Вакансия 1 в <ООО Гора>", new DateTime(2023, 9, 17, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5925), 1, true, 51.0, 64000.0, true },
                    { 859, null, new Guid("7533b048-2445-4836-8f14-b6acb4c825c4"), 1, "Мужской", 18.0, 27000.0, "Вакансия 2 в <ООО Светлячок>", new DateTime(2023, 8, 26, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5898), 9, true, 53.0, 92000.0, true },
                    { 860, new DateTime(2023, 9, 22, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5885), new Guid("7533b048-2445-4836-8f14-b6acb4c825c4"), 2, "Не указан", 19.0, 27000.0, "Вакансия 1 в <ООО Светлячок>", new DateTime(2023, 8, 24, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5885), 3, true, 50.0, 95000.0, true },
                    { 865, null, new Guid("fc856d8a-ec49-4b58-bfe2-4228dd2d02bc"), 1, "Мужской", 19.0, 49000.0, "Вакансия 2 в <ПАО Закат>", new DateTime(2023, 8, 26, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5822), 3, true, 55.0, 91000.0, false },
                    { 866, new DateTime(2023, 9, 30, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5806), new Guid("fc856d8a-ec49-4b58-bfe2-4228dd2d02bc"), 4, "Женский", 22.0, 27000.0, "Вакансия 1 в <ПАО Закат>", new DateTime(2023, 8, 23, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5806), 6, true, 54.0, 79000.0, true },
                    { 871, new DateTime(2023, 9, 19, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5775), new Guid("95c018c1-80a7-4428-bcd0-738e0e2a3b1a"), 4, "Мужской", 18.0, 50000.0, "Вакансия 2 в <ЗАО Ветерок>", new DateTime(2023, 8, 22, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5775), 5, false, 51.0, 84000.0, false },
                    { 872, new DateTime(2023, 10, 7, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5760), new Guid("95c018c1-80a7-4428-bcd0-738e0e2a3b1a"), 1, "Не указан", 22.0, 25000.0, "Вакансия 1 в <ЗАО Ветерок>", new DateTime(2023, 8, 22, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5760), 4, false, 67.0, 74000.0, false },
                    { 877, new DateTime(2023, 10, 9, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5728), new Guid("1c46902e-e53b-41e9-8517-d274a50cdc2f"), 1, "Мужской", 19.0, 44000.0, "Вакансия 2 в <ООО Горизонт>", new DateTime(2023, 8, 20, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5727), 2, false, 52.0, 63000.0, true },
                    { 878, null, new Guid("1c46902e-e53b-41e9-8517-d274a50cdc2f"), 1, "Мужской", 21.0, 48000.0, "Вакансия 1 в <ООО Горизонт>", new DateTime(2023, 9, 6, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5694), 7, true, 57.0, 62000.0, true },
                    { 883, null, new Guid("00cb7216-f4b6-43db-8849-e18bbb48272c"), 1, "Не указан", 23.0, 33000.0, "Вакансия 2 в <ПАО Лес>", new DateTime(2023, 9, 5, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5662), 3, false, 55.0, 74000.0, false },
                    { 884, null, new Guid("00cb7216-f4b6-43db-8849-e18bbb48272c"), 3, "Женский", 18.0, 28000.0, "Вакансия 1 в <ПАО Лес>", new DateTime(2023, 9, 2, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5649), 1, false, 56.0, 61000.0, true },
                    { 889, new DateTime(2023, 9, 22, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5611), new Guid("305d33d0-4be9-4fb9-a10e-4e7039911815"), 1, "Не указан", 19.0, 35000.0, "Вакансия 2 в <ЗАО Подсолнух>", new DateTime(2023, 8, 21, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5610), 3, true, 56.0, 70000.0, false },
                    { 890, null, new Guid("305d33d0-4be9-4fb9-a10e-4e7039911815"), 3, "Не указан", 19.0, 32000.0, "Вакансия 1 в <ЗАО Подсолнух>", new DateTime(2023, 9, 4, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5594), 8, false, 67.0, 71000.0, true },
                    { 895, null, new Guid("09dc7a08-b773-44cb-9bf2-6b826da12703"), 4, "Мужской", 18.0, 45000.0, "Вакансия 2 в <ООО Ромашка>", new DateTime(2023, 8, 27, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5528), 5, false, 63.0, 71000.0, true },
                    { 896, null, new Guid("09dc7a08-b773-44cb-9bf2-6b826da12703"), 1, "Не указан", 19.0, 52000.0, "Вакансия 1 в <ООО Ромашка>", new DateTime(2023, 9, 11, 18, 56, 50, 219, DateTimeKind.Utc).AddTicks(5495), 1, false, 59.0, 69000.0, false }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "AddressId", "Apartment", "CompanyId", "ExternalId", "House", "LocalityId", "StreetId" },
                values: new object[,]
                {
                    { 843, "48", null, new Guid("95f9bf51-47de-4480-ab55-38a344209670"), "54", 905, 911 },
                    { 844, "160", null, new Guid("95f9bf51-47de-4480-ab55-38a344209670"), "11", 902, 920 },
                    { 849, "155", null, new Guid("b03e0f65-250c-4b83-b6e8-515cd65902a6"), "8", 910, 917 },
                    { 850, "50", null, new Guid("b03e0f65-250c-4b83-b6e8-515cd65902a6"), "64", 906, 915 },
                    { 855, "36", null, new Guid("dc0ab0c3-861e-453f-b626-7b769aa0b7ec"), "74", 903, 918 },
                    { 856, "114", null, new Guid("dc0ab0c3-861e-453f-b626-7b769aa0b7ec"), "18", 904, 911 },
                    { 861, "79", null, new Guid("7533b048-2445-4836-8f14-b6acb4c825c4"), "9", 904, 916 },
                    { 862, "146", null, new Guid("7533b048-2445-4836-8f14-b6acb4c825c4"), "35", 905, 914 },
                    { 867, "51", null, new Guid("fc856d8a-ec49-4b58-bfe2-4228dd2d02bc"), "60", 906, 918 },
                    { 868, "63", null, new Guid("fc856d8a-ec49-4b58-bfe2-4228dd2d02bc"), "72", 901, 914 },
                    { 873, "75", null, new Guid("95c018c1-80a7-4428-bcd0-738e0e2a3b1a"), "63", 903, 919 },
                    { 874, "159", null, new Guid("95c018c1-80a7-4428-bcd0-738e0e2a3b1a"), "35", 907, 912 },
                    { 879, "38", null, new Guid("1c46902e-e53b-41e9-8517-d274a50cdc2f"), "66", 907, 912 },
                    { 880, "37", null, new Guid("1c46902e-e53b-41e9-8517-d274a50cdc2f"), "79", 901, 920 },
                    { 885, "155", null, new Guid("00cb7216-f4b6-43db-8849-e18bbb48272c"), "56", 902, 917 },
                    { 886, "78", null, new Guid("00cb7216-f4b6-43db-8849-e18bbb48272c"), "73", 906, 915 },
                    { 891, "24", null, new Guid("305d33d0-4be9-4fb9-a10e-4e7039911815"), "34", 909, 919 },
                    { 892, "37", null, new Guid("305d33d0-4be9-4fb9-a10e-4e7039911815"), "84", 903, 912 },
                    { 897, "83", null, new Guid("09dc7a08-b773-44cb-9bf2-6b826da12703"), "97", 907, 920 },
                    { 898, "116", null, new Guid("09dc7a08-b773-44cb-9bf2-6b826da12703"), "19", 905, 918 }
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
