using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduNote.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public ICollection<UserGroups> UserGroups { get; set; }
        public ICollection<Note> NotesCreated { get; set; }
        public ICollection<Note> NotesUpdated { get; set; }
        public ICollection<Question> QuestionsCreated { get; set; }
        public ICollection<Question> QuestionsUpdated { get; set; }
        public ICollection<Answer> AnswersCreated { get; set; }
        public ICollection<Answer> AnswersUpdated { get; set; }
    }
}