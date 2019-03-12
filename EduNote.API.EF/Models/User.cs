using System.Collections.Generic;

namespace EduNote.API.EF.Models
{
    public partial class User: BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public ICollection<UserGroups> UserGroups { get; set; }
        public ICollection<Note> NotesCreated { get; set; }
        public ICollection<Note> NotesUpdated { get; set; }
        public ICollection<Question> QuestionsCreated { get; set; }
        public ICollection<Question> QuestionsUpdated { get; set; }
        public ICollection<Answer> AnswersCreated { get; set; }
        public ICollection<Answer> AnswersUpdated { get; set; }
    }
}