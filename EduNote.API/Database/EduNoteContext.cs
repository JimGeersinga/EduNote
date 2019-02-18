using System;
using EduNote.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EduNote.API.Database
{
    public class EduNoteContext : DbContext
    {
        public EduNoteContext(DbContextOptions<EduNoteContext> options): base(options)
        {
        }

        public virtual DbSet<User> Users{ get; set; }
    }
}
