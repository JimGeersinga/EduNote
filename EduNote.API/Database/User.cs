using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduNote.API.Database
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Group> Groups { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<Section> AllowedSections { get; set; }
    }
}