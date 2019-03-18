using EduNote.API.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduNote.API.EF
{
    public class EduNoteContext : DbContext
    {

        public EduNoteContext(DbContextOptions<EduNoteContext> options) : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroups> UserGroups { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionTags> QuestionTags { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<NoteTags> NoteTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Question
            modelBuilder.Entity<Question>()
                .HasOne(q => q.CreatedBy)
                .WithMany(u => u.QuestionsCreated)
                .HasForeignKey(q => q.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Question>()
                .HasOne(q => q.ModifiedBy)
                .WithMany(u => u.QuestionsUpdated)
                .HasForeignKey(q => q.ModifiedById)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Question>()
                .HasOne(a => a.Section)
                .WithMany(u => u.Questions)
                .HasForeignKey(a => a.SectionId);
            #endregion Answer

            #region Answer
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.CreatedBy)
                .WithMany(u => u.AnswersCreated)
                .HasForeignKey(a => a.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.ModifiedBy)
                .WithMany(u => u.AnswersUpdated)
                .HasForeignKey(a => a.ModifiedById)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(u => u.Answers)
                .HasForeignKey(a => a.QuestionId);
            #endregion Answer

            #region Note
            modelBuilder.Entity<Note>()
               .HasOne(n => n.CreatedBy)
               .WithMany(u => u.NotesCreated)
               .HasForeignKey(n => n.CreatedById)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Note>()
                .HasOne(n => n.ModifiedBy)
                .WithMany(u => u.NotesUpdated)
                .HasForeignKey(n => n.ModifiedById)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Note>()
                .HasOne(n => n.Section)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.SectionId);
            #endregion

            #region Sections
            modelBuilder.Entity<Section>()
                .HasOne(s => s.Parent)
                .WithMany(s => s.Sections)
                .HasForeignKey(s => s.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion Sections

            #region UserGroups
            modelBuilder.Entity<UserGroups>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.UserGroups)
                .HasForeignKey(ug => ug.UserId);
            modelBuilder.Entity<UserGroups>()
                .HasOne(ug => ug.Group)
                .WithMany(g => g.UserGroups)
                .HasForeignKey(ug => ug.GroupId);
            #endregion UserGroups

            #region NoteTags
            modelBuilder.Entity<NoteTags>()
                .HasOne(nt => nt.Note)
                .WithMany(u => u.NoteTags)
                .HasForeignKey(nt => nt.NoteId);
            modelBuilder.Entity<NoteTags>()
                .HasOne(nt => nt.Tag)
                .WithMany(g => g.NoteTags)
                .HasForeignKey(nt => nt.TagId);
            #endregion NoteTags

            #region QuestionTags
            modelBuilder.Entity<QuestionTags>()
                .HasOne(qt => qt.Question)
                .WithMany(u => u.QuestionTags)
                .HasForeignKey(qt => qt.QuestionId);
            modelBuilder.Entity<QuestionTags>()
                .HasOne(qt => qt.Tag)
                .WithMany(g => g.QuestionTags)
                .HasForeignKey(qt => qt.TagId);
            #endregion QuestionTags

            modelBuilder.Entity<User>()
                .HasData(new User() { Id = 1, FirstName = "Jim", LastName = "Geersinga", Email = "0968640@hr.nl" },
                         new User() { Id = 2, FirstName = "Simon", LastName = "Besseling", Email = "simonbesseling@outlook.com" },
                         new User() { Id = 3, FirstName = "Kamiel", LastName = "Kruidenier", Email = "0548643@hr.nl" },
                         new User() { Id = 4, FirstName = "Mike", LastName = "Van Leeuwen", Email = "0973546@hr.nl" },
                         new User() { Id = 5, FirstName = "Marco", LastName = "Peltenburg", Email = "0958245@hr.nl" });

            modelBuilder.Entity<Section>()
                .HasData(new Section() { Id = 1, Title = "Year 1", Description = "" },
                         new Section() { Id = 2, Title = "Year 2", Description = "" },
                         new Section() { Id = 3, Title = "Dev", Description = "", ParentId = 1 });

            modelBuilder.Entity<Question>()
                .HasData(new Question() { Id = 1, Title = "Why is a camel?", Body = "Confirmed to have a body.", SectionId = 1, CreatedById = 1, Created = DateTime.UtcNow },
                         new Question() { Id = 2, Title = "Lorem ipsum", Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", SectionId = 2, CreatedById = 1, Created = DateTime.UtcNow });

            modelBuilder.Entity<Answer>()
                .HasData(new Answer() { Id = 1, Body = "Yes", QuestionId = 1, CreatedById = 1, Created = DateTime.UtcNow },
                         new Answer() { Id = 2, Body = "What the .. do you mean?", QuestionId = 1, CreatedById = 1, Created = DateTime.UtcNow },
                         new Answer() { Id = 3, Body = "This is correct", QuestionId = 2, CreatedById = 1, Created = DateTime.UtcNow });

            modelBuilder.Entity<Note>()
                .HasData(new Note() { Id = 1, Title = "Dev 3 OOP", Body = "A Full guide to ", SectionId = 3, CreatedById = 1, Created = DateTime.UtcNow });                         
        }
    }
}
