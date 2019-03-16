using System;

namespace EduNote.API.Shared.ApiModels
{
    public class NoteAPIModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public int SectionId { get; set; }
        public int CreatedById { get; set; }
        public int ModifiedById { get; set; }
    }
}