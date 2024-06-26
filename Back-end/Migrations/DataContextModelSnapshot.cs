﻿// <auto-generated />
using System;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Backend.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Library.Models.Constraint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Constraints");
                });

            modelBuilder.Entity("Library.Models.LearningUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ContactPersonId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Period")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<bool>("Visible")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("ContactPersonId");

                    b.ToTable("LearningUnits");
                });

            modelBuilder.Entity("Library.Models.LearningUnitModule", b =>
                {
                    b.Property<int>("LearningUnitId")
                        .HasColumnType("integer");

                    b.Property<int>("ModuleId")
                        .HasColumnType("integer");

                    b.HasKey("LearningUnitId", "ModuleId");

                    b.HasIndex("ModuleId");

                    b.ToTable("LearningUnitModule");
                });

            modelBuilder.Entity("Library.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<bool>("Visible")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("Library.Models.ModuleConstraint", b =>
                {
                    b.Property<int>("ModuleId")
                        .HasColumnType("integer");

                    b.Property<int>("ConstraintId")
                        .HasColumnType("integer");

                    b.HasKey("ModuleId", "ConstraintId");

                    b.HasIndex("ConstraintId");

                    b.ToTable("ModuleConstraint");
                });

            modelBuilder.Entity("Library.Models.StudyPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ExploringItId")
                        .HasColumnType("integer");

                    b.Property<int>("FreeChoiceOneId")
                        .HasColumnType("integer");

                    b.Property<int>("FreeChoiceThreeId")
                        .HasColumnType("integer");

                    b.Property<int>("FreeChoiceTwoId")
                        .HasColumnType("integer");

                    b.Property<int>("ProfileChoiceOneId")
                        .HasColumnType("integer");

                    b.Property<int>("ProfileChoiceTwoId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExploringItId");

                    b.HasIndex("FreeChoiceOneId");

                    b.HasIndex("FreeChoiceThreeId");

                    b.HasIndex("FreeChoiceTwoId");

                    b.HasIndex("ProfileChoiceOneId");

                    b.HasIndex("ProfileChoiceTwoId");

                    b.HasIndex("UserId");

                    b.ToTable("StudyPlans");
                });

            modelBuilder.Entity("Library.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Credits")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int?>("Grade")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("ReceivesEmailNotifications")
                        .HasColumnType("boolean");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Library.Models.LearningUnit", b =>
                {
                    b.HasOne("Library.Models.User", "ContactPerson")
                        .WithMany()
                        .HasForeignKey("ContactPersonId");
                });

            modelBuilder.Entity("Library.Models.LearningUnitModule", b =>
                {
                    b.HasOne("Library.Models.LearningUnit", "Unit")
                        .WithMany("LearningUnitModules")
                        .HasForeignKey("LearningUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.Module", "Module")
                        .WithMany("LearningUnitModules")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Models.ModuleConstraint", b =>
                {
                    b.HasOne("Library.Models.Constraint", "Constraint")
                        .WithMany("ModuleConstraints")
                        .HasForeignKey("ConstraintId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.Module", "Module")
                        .WithMany("ModuleConstraints")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Models.StudyPlan", b =>
                {
                    b.HasOne("Library.Models.LearningUnit", "ExploringIt")
                        .WithMany()
                        .HasForeignKey("ExploringItId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.LearningUnit", "FreeChoiceOne")
                        .WithMany()
                        .HasForeignKey("FreeChoiceOneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.LearningUnit", "FreeChoiceThree")
                        .WithMany()
                        .HasForeignKey("FreeChoiceThreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.LearningUnit", "FreeChoiceTwo")
                        .WithMany()
                        .HasForeignKey("FreeChoiceTwoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.LearningUnit", "ProfileChoiceOne")
                        .WithMany()
                        .HasForeignKey("ProfileChoiceOneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.LearningUnit", "ProfileChoiceTwo")
                        .WithMany()
                        .HasForeignKey("ProfileChoiceTwoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.User", "User")
                        .WithMany("StudyPlans")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
