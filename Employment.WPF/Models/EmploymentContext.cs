using Employment.WPF.Models.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Employment.WPF.Models;

public class EmploymentContext : DbContext
{
    public EmploymentContext() { }
    public EmploymentContext(DbContextOptions<EmploymentContext> options)
        : base(options) { }

    public virtual DbSet<Company> Companies { get; set; }
    //public virtual DbSet<Organization> Organizations { get; set; }
    public virtual DbSet<Vacancy> Vacancies { get; set; }
    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<Phone> Phones { get; set; }
    public virtual DbSet<Locality> Localities { get; set; }
    public virtual DbSet<LocalityType> LocalityTypes { get; set; }
    public virtual DbSet<Responsibility> Responsibilities { get; set; }
    public virtual DbSet<VacancyResponsibility> VacancyResponsibilities { get; set; }
    public virtual DbSet<Skill> Skills { get; set; }
    public virtual DbSet<VacancySkill> VacancySkills { get; set; }
    public virtual DbSet<Street> Streets { get; set; }
    public virtual DbSet<StreetType> StreetTypes { get; set; }
    public virtual DbSet<Education> Educations { get; set; }
    public virtual DbSet<Position> Positions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Employment;Username=postgres;Password=101001Zeus");
            optionsBuilder.UseNpgsql("Host=localhost;Port=5434;Database=Employment;Username=postgres;Password=password");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Organization>(entity =>
        //{
        //    entity.HasKey(e => e.OrganizationId);

        //    entity.Property(e => e.OrganizationId)
        //       .ValueGeneratedOnAdd()
        //       .HasDefaultValueSql("gen_random_uuid()");

        //    entity.Property(e => e.Name)
        //       .HasMaxLength(255);

        //    entity.Property(e => e.ShortName)
        //       .HasMaxLength(63);

        //    entity.Property(e => e.Email)
        //        .HasMaxLength(256);

        //    entity.HasMany<Phone>(o => o.Phones)
        //        .WithOne()
        //        .HasForeignKey(p => p.ExternalId)
        //        .OnDelete(DeleteBehavior.Cascade);
        //});
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            entityType.SetTableName(entityType.DisplayName());
        }

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId);

            entity.Property(e => e.CompanyId)
               .ValueGeneratedOnAdd()
               .HasDefaultValueSql("gen_random_uuid()");

            entity.Property(e => e.Name)
               .HasMaxLength(255);

            entity.Property(e => e.ShortName)
               .HasMaxLength(63);

            entity.Property(e => e.Email)
                .HasMaxLength(256);

            entity.HasMany<Phone>(o => o.Phones)
                .WithOne()
                .HasForeignKey(p => p.ExternalId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(a => a.AddressId);

            //entity.HasOne(a => a.Organization)
            //      .WithMany()
            //      .HasForeignKey(a => a.ExternalId)
            //      .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.Company)
                  .WithMany()
                  .HasForeignKey(a => a.ExternalId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.Locality)
                  .WithMany(l => l.Addresses)
                  .HasForeignKey(a => a.LocalityId);

            entity.HasOne(a => a.Street)
                  .WithMany()
                  .HasForeignKey(a => a.StreetId);
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(p => p.PhoneId);

            entity.HasOne(p => p.Company)
                  .WithMany(c => c.Phones)
                  .HasForeignKey(p => p.ExternalId)
                  .OnDelete(DeleteBehavior.Restrict)
                  .IsRequired(false);

            //entity.HasOne(p => p.Organization)
            //      .WithMany(o => o.Phones)
            //      .HasForeignKey(p => p.ExternalId)
            //      .OnDelete(DeleteBehavior.Restrict)
            //      .IsRequired(false);
        });

        modelBuilder.Entity<Locality>(entity =>
        {
            entity.HasKey(l => l.LocalityId);

            entity.Property(e => e.Name)
            .HasMaxLength(255);

            entity.Property(e => e.ShortName)
            .HasMaxLength(63);

            entity.HasOne(l => l.LocalityType)
                  .WithMany(lt => lt.Localities)
                  .HasForeignKey(l => l.LocalityTypeId);
        });

        modelBuilder.Entity<LocalityType>(entity =>
        {
            entity.HasKey(lt => lt.LocalityTypeId);

            entity.Property(e => e.Name)
            .HasMaxLength(255);

            entity.Property(e => e.ShortName)
            .HasMaxLength(63);
        });

        modelBuilder.Entity<Responsibility>(entity =>
        {
            entity.HasKey(r => r.ResponsibilityId);

            entity.Property(e => e.Name)
            .HasMaxLength(255);

        });

        modelBuilder.Entity<VacancyResponsibility>(entity =>
        {
            entity.HasKey(vr => new { vr.VacancyId, vr.ResponsibilityId });

            entity.HasOne(vr => vr.Vacancy)
                  .WithMany(v => v.Responsibilities)
                  .HasForeignKey(vr => vr.VacancyId);

            entity.HasOne(vr => vr.Responsibility)
                  .WithMany(r => r.Vacancies)
                  .HasForeignKey(vr => vr.ResponsibilityId);
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(s => s.SkillId);
        });

        modelBuilder.Entity<VacancySkill>(entity =>
        {
            entity.HasKey(vs => new { vs.VacancyId, vs.SkillId });

            entity.HasOne(vs => vs.Vacancy)
                  .WithMany(v => v.Skills)
                  .HasForeignKey(vs => vs.VacancyId);

            entity.HasOne(vs => vs.Skill)
                  .WithMany(s => s.Vacancies)
                  .HasForeignKey(vs => vs.SkillId);
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.HasKey(s => s.StreetId);

            entity.Property(e => e.Name)
            .HasMaxLength(255);

            entity.Property(e => e.ShortName)
            .HasMaxLength(63);

            entity.HasOne(s => s.StreetType)
                  .WithMany()
                  .HasForeignKey(s => s.StreeTypetId);
        });

        modelBuilder.Entity<StreetType>(entity =>
        {
            entity.HasKey(st => st.StreetTypeId);

            entity.Property(e => e.Name)
            .HasMaxLength(255);

            entity.Property(e => e.ShortName)
            .HasMaxLength(63);
        });

        modelBuilder.Entity<Vacancy>(entity =>
        {
            entity.HasKey(v => v.VacancyId);

            entity.Property(v => v.Name)
                .HasMaxLength(255);

            entity.HasOne(v => v.Company)
                  .WithMany(c => c.Vacancies)
                  .HasForeignKey(v => v.CompanyId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(v => v.Education)
                  .WithMany(c => c.Vacancies)
                  .HasForeignKey(v => v.EducationId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(v => v.Position)
                  .WithMany(c => c.Vacancies)
                  .HasForeignKey(v => v.PositionId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(v => v.Skills)
                  .WithOne(vs => vs.Vacancy)
                  .HasForeignKey(vs => vs.VacancyId)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(v => v.Responsibilities)
                  .WithOne(vr => vr.Vacancy)
                  .HasForeignKey(vr => vr.VacancyId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Генерация типов улиц и населенных пунктов
        var streetTypes = DataGenerator.GenerateStreetTypes();
        modelBuilder.Entity<StreetType>().HasData(streetTypes);

        var localityTypes = DataGenerator.GenerateLocalityTypes();
        modelBuilder.Entity<LocalityType>().HasData(localityTypes);

        // Генерация улиц и населенных пунктов
        var streets = DataGenerator.GenerateStreets(streetTypes);
        modelBuilder.Entity<Street>().HasData(streets);

        var localities = DataGenerator.GenerateLocalities(localityTypes);
        modelBuilder.Entity<Locality>().HasData(localities);

        // Генерация компаний
        var companies = DataGenerator.GenerateCompanies();
        modelBuilder.Entity<Company>().HasData(companies);

        var educations = DataGenerator.GenerateEducations();
        modelBuilder.Entity<Education>().HasData(educations);

        var positions = DataGenerator.GeneratePositions();
        modelBuilder.Entity<Position>().HasData(positions);

        var responsibilities = DataGenerator.GenerateResponsibilities();
        modelBuilder.Entity<Responsibility>().HasData(responsibilities);

        var skills = DataGenerator.GenerateSkills();  
        modelBuilder.Entity<Skill>().HasData(skills); 

        // Генерация телефонов, вакансий и адресов для компаний
        var allPhones = new List<Phone>();
        var allAddresses = new List<Address>();
        var allVacancies = new List<Vacancy>();

        foreach (var company in companies)
        {
            var phones = DataGenerator.GeneratePhonesForCompany(company.CompanyId, 40);
            allPhones.AddRange(phones);

            var addresses = DataGenerator.GenerateAddressesForCompany(company.CompanyId, 40, streets, streetTypes, localityTypes, localities);
            allAddresses.AddRange(addresses);

            var vacancies = DataGenerator.GenerateVacanciesForCompany(company.Name, company.CompanyId, 40);
            allVacancies.AddRange(vacancies);
        }

        modelBuilder.Entity<Phone>().HasData(allPhones);
        modelBuilder.Entity<Address>().HasData(allAddresses);

        var allVacancyResponsibilities = new List<VacancyResponsibility>();
        var allVacancySkills = new List<VacancySkill>();

        Random random = new Random(); // Генератор случайных чисел

        foreach (var vacancy in allVacancies)
        {
            vacancy.Responsibilities = null; // Очистите список обязанностей
            vacancy.Skills = null;
            modelBuilder.Entity<Vacancy>().HasData(vacancy);

            // Перемешайте список обязанностей
            var shuffledResponsibilities = responsibilities.OrderBy(r => random.Next()).ToList();

            // Выберите случайное количество обязанностей (от 1 до 3)
            int randomResponsibilityCount = random.Next(1, 4);

            // Присваивайте только выбранное количество обязанностей
            for (int i = 0; i < randomResponsibilityCount; i++)
            {
                allVacancyResponsibilities.Add(new VacancyResponsibility
                {
                    VacancyId = vacancy.VacancyId,
                    ResponsibilityId = shuffledResponsibilities[i].ResponsibilityId
                });
            }

            // Точно так же делаем для навыков (если это еще нужно)
            var shuffledSkills = skills.OrderBy(s => random.Next()).ToList();
            int randomSkillCount = random.Next(1, 4);
            for (int i = 0; i < randomSkillCount; i++)
            {
                allVacancySkills.Add(new VacancySkill
                {
                    VacancyId = vacancy.VacancyId,
                    SkillId = shuffledSkills[i].SkillId
                });
            }
        }

        modelBuilder.Entity<VacancyResponsibility>().HasData(allVacancyResponsibilities);
        modelBuilder.Entity<VacancySkill>().HasData(allVacancySkills);
    }
}
