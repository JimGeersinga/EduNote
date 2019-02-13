namespace EduNote.API.Database
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EduNoteContext : DbContext
    {
        // Your context has been configured to use a 'EduNoteContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EduNote.API.Database.EduNoteContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EduNoteContext' 
        // connection string in the application configuration file.
        public EduNoteContext()
            : base("name=EduNoteContext")
        {

            //Database.SetInitializer(new EduNoteInitializer());
            Database.SetInitializer(new DropCreateDatabaseAlways<EduNoteContext>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
    }
}