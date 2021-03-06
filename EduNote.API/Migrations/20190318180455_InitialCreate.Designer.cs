﻿// <auto-generated />
using System;
using EduNote.API.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EduNote.API.Migrations
{
    [DbContext(typeof(EduNoteContext))]
    [Migration("20190318180455_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EduNote.API.EF.Models.Answer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<DateTime>("Created");

                    b.Property<long>("CreatedById");

                    b.Property<DateTime?>("Modified");

                    b.Property<long?>("ModifiedById");

                    b.Property<long>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new { Id = 1L, Body = "Yes", Created = new DateTime(2019, 3, 18, 18, 4, 55, 385, DateTimeKind.Utc), CreatedById = 1L, QuestionId = 1L },
                        new { Id = 2L, Body = "What the .. do you mean?", Created = new DateTime(2019, 3, 18, 18, 4, 55, 385, DateTimeKind.Utc), CreatedById = 1L, QuestionId = 1L },
                        new { Id = 3L, Body = "This is correct", Created = new DateTime(2019, 3, 18, 18, 4, 55, 385, DateTimeKind.Utc), CreatedById = 1L, QuestionId = 2L }
                    );
                });

            modelBuilder.Entity("EduNote.API.EF.Models.Group", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("EduNote.API.EF.Models.Note", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<DateTime>("Created");

                    b.Property<long>("CreatedById");

                    b.Property<DateTime?>("Modified");

                    b.Property<long?>("ModifiedById");

                    b.Property<long>("SectionId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("SectionId");

                    b.ToTable("Notes");

                    b.HasData(
                        new { Id = 1L, Body = "A Full guide to ", Created = new DateTime(2019, 3, 18, 18, 4, 55, 385, DateTimeKind.Utc), CreatedById = 1L, SectionId = 3L, Title = "Dev 3 OOP" }
                    );
                });

            modelBuilder.Entity("EduNote.API.EF.Models.NoteTags", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Modified");

                    b.Property<long>("NoteId");

                    b.Property<long>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.HasIndex("TagId");

                    b.ToTable("NoteTags");
                });

            modelBuilder.Entity("EduNote.API.EF.Models.Question", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<DateTime>("Created");

                    b.Property<long>("CreatedById");

                    b.Property<DateTime?>("Modified");

                    b.Property<long?>("ModifiedById");

                    b.Property<long>("SectionId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ModifiedById");

                    b.HasIndex("SectionId");

                    b.ToTable("Questions");

                    b.HasData(
                        new { Id = 1L, Body = "Confirmed to have a body.", Created = new DateTime(2019, 3, 18, 18, 4, 55, 385, DateTimeKind.Utc), CreatedById = 1L, SectionId = 1L, Title = "Why is a camel?" },
                        new { Id = 2L, Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", Created = new DateTime(2019, 3, 18, 18, 4, 55, 385, DateTimeKind.Utc), CreatedById = 1L, SectionId = 2L, Title = "Lorem ipsum" }
                    );
                });

            modelBuilder.Entity("EduNote.API.EF.Models.QuestionTags", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Modified");

                    b.Property<long>("QuestionId");

                    b.Property<long>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("TagId");

                    b.ToTable("QuestionTags");
                });

            modelBuilder.Entity("EduNote.API.EF.Models.Section", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("Modified");

                    b.Property<long?>("ParentId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Sections");

                    b.HasData(
                        new { Id = 1L, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "", Title = "Year 1" },
                        new { Id = 2L, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "", Title = "Year 2" },
                        new { Id = 3L, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Description = "", ParentId = 1L, Title = "Dev" }
                    );
                });

            modelBuilder.Entity("EduNote.API.EF.Models.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("EduNote.API.EF.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime?>("Modified");

                    b.Property<string>("Password");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1L, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "0968640@hr.nl", FirstName = "Jim", LastName = "Geersinga", Password = "$2b$10$kAnol6IKmJLj35UJXRETNeI9mrMvPIEzwXtRPKzPgacMa3YlUahvW" },
                        new { Id = 2L, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "simonbesseling@outlook.com", FirstName = "Simon", LastName = "Besseling", Password = "$2b$10$Olnpn6Lgzq1Js66Ktc3FROVoRgIwxPgxkdQ9S4Iq5FfJvkXBQxhvO" },
                        new { Id = 3L, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "0548643@hr.nl", FirstName = "Kamiel", LastName = "Kruidenier", Password = "$2b$10$bjkPjRpVIvj9xFGZ43NEOuTh3I4RCQikoQR0VyekjlQ8yKOYFjM1G" },
                        new { Id = 4L, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "0973546@hr.nl", FirstName = "Mike", LastName = "Van Leeuwen", Password = "$2b$10$71F0Qh4xpZsZzh7qOEJeP.7flWhEEaKuZAQbAsMZU7GgAFn96NxGi" },
                        new { Id = 5L, Created = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "0958245@hr.nl", FirstName = "Marco", LastName = "Peltenburg", Password = "$2b$10$76fE9y8XtbKLJms6i7HTNuhb6qV9lbU.ClaO3sRb6u3S4Yrt.0g7C" }
                    );
                });

            modelBuilder.Entity("EduNote.API.EF.Models.UserGroups", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<long>("GroupId");

                    b.Property<DateTime?>("Modified");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("UserGroups");
                });

            modelBuilder.Entity("EduNote.API.EF.Models.Answer", b =>
                {
                    b.HasOne("EduNote.API.EF.Models.User", "CreatedBy")
                        .WithMany("AnswersCreated")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EduNote.API.EF.Models.User", "ModifiedBy")
                        .WithMany("AnswersUpdated")
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EduNote.API.EF.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EduNote.API.EF.Models.Note", b =>
                {
                    b.HasOne("EduNote.API.EF.Models.User", "CreatedBy")
                        .WithMany("NotesCreated")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EduNote.API.EF.Models.User", "ModifiedBy")
                        .WithMany("NotesUpdated")
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EduNote.API.EF.Models.Section", "Section")
                        .WithMany("Notes")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EduNote.API.EF.Models.NoteTags", b =>
                {
                    b.HasOne("EduNote.API.EF.Models.Note", "Note")
                        .WithMany("NoteTags")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EduNote.API.EF.Models.Tag", "Tag")
                        .WithMany("NoteTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EduNote.API.EF.Models.Question", b =>
                {
                    b.HasOne("EduNote.API.EF.Models.User", "CreatedBy")
                        .WithMany("QuestionsCreated")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EduNote.API.EF.Models.User", "ModifiedBy")
                        .WithMany("QuestionsUpdated")
                        .HasForeignKey("ModifiedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("EduNote.API.EF.Models.Section", "Section")
                        .WithMany("Questions")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EduNote.API.EF.Models.QuestionTags", b =>
                {
                    b.HasOne("EduNote.API.EF.Models.Question", "Question")
                        .WithMany("QuestionTags")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EduNote.API.EF.Models.Tag", "Tag")
                        .WithMany("QuestionTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EduNote.API.EF.Models.Section", b =>
                {
                    b.HasOne("EduNote.API.EF.Models.Section", "Parent")
                        .WithMany("Sections")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EduNote.API.EF.Models.UserGroups", b =>
                {
                    b.HasOne("EduNote.API.EF.Models.Group", "Group")
                        .WithMany("UserGroups")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EduNote.API.EF.Models.User", "User")
                        .WithMany("UserGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
