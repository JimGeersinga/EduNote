using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EduNote.API.EF
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EduNoteContext>
    {
        public EduNoteContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<EduNoteContext>();

            var connectionString = configuration.GetConnectionString("EduNoteDatabase");

            builder.UseSqlServer(connectionString);

            return new EduNoteContext(builder.Options);
        }
    }
}
