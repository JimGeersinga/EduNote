using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduNote.API.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public int test { get; set; }

        public int SectionId { get; set; }
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }

        public Section Section { get; set; }
        public ICollection<NoteTags> NoteTags { get; set; }
        public User CreatedBy { get; set; }
        public User UpdatedBy { get; set; }
    }
}