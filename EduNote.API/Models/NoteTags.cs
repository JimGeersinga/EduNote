using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduNote.API.Models
{
    public class NoteTags
    {
        public int Id { get; set; }
        public int NoteId { get; set; }
        public int TagId { get; set; }

        public Note Note { get; set; }
        public Tag Tag { get; set; }
    }
}
