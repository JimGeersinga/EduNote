using System;
using System.Collections.Generic;

namespace EduNote.API.Database
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}