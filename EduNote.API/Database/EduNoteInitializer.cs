using System.Data.Entity;

namespace EduNote.API.Database
{
    public class EduNoteInitializer : CreateDatabaseIfNotExists<EduNoteContext>
    {
        protected override void Seed(EduNoteContext context)
        {
            base.Seed(context);
        }
    }
}