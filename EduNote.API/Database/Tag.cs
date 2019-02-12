using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduNote.API.Database
{
    public class Tag
    {
        public int TagID { get; set; }
        public string Name { get; set; }

        public ICollection<Note> Notes { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}