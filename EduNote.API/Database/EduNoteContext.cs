using System;
using EduNote.API.Models;
using Microsoft.EntityFrameworkCore;
using EduNote.API.Shared.ApiModels;

namespace EduNote.API.Database
{
    public class EduNoteContext : DbContext
    {
        public EduNoteContext(DbContextOptions<EduNoteContext> options): base(options)
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
                .HasOne(q => q.UpdatedBy)
                .WithMany(u => u.QuestionsUpdated)
                .HasForeignKey(q => q.UpdatedById)
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
                .HasOne(a => a.UpdatedBy)
                .WithMany(u => u.AnswersUpdated)
                .HasForeignKey(a => a.UpdatedById)
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
                .HasOne(n => n.UpdatedBy)
                .WithMany(u => u.NotesUpdated)
                .HasForeignKey(n => n.UpdatedById)
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
                .HasData(new User() {Id = 1, FirstName = "Jim", LastName = "Geersinga", Email = "j.geersinga@outlook.com" });
        }
    }
}
