﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Domain.Entities.EmployeeAddress", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EmployeeId1")
                        .HasColumnType("integer");

                    b.HasKey("EmployeeId");

                    b.HasIndex("EmployeeId1");

                    b.ToTable("EmployeeAddresses");
                });

            modelBuilder.Entity("Domain.Entities.EmployeeSkill", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EmployeeId"));

                    b.Property<int>("EmployeeId1")
                        .HasColumnType("integer");

                    b.Property<int>("SkillId")
                        .HasColumnType("integer");

                    b.HasKey("EmployeeId");

                    b.HasIndex("EmployeeId1");

                    b.HasIndex("SkillId");

                    b.ToTable("EmployeeSkills");
                });

            modelBuilder.Entity("Domain.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.HasOne("Domain.Entities.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Domain.Entities.EmployeeAddress", b =>
                {
                    b.HasOne("Domain.Entities.Employee", "Employee")
                        .WithMany("EmployeeAddresses")
                        .HasForeignKey("EmployeeId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Entities.EmployeeSkill", b =>
                {
                    b.HasOne("Domain.Entities.Employee", "Employee")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("EmployeeId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Skill", "Skill")
                        .WithMany("EmployeeSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Domain.Entities.Company", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Navigation("EmployeeAddresses");

                    b.Navigation("EmployeeSkills");
                });

            modelBuilder.Entity("Domain.Entities.Skill", b =>
                {
                    b.Navigation("EmployeeSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
