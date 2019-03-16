namespace EduNote.API.EF.Models
{
    public partial class NoteTags : BaseModel
    {
        public long NoteId { get; set; }
        public long TagId { get; set; }

        public Note Note { get; set; }
        public Tag Tag { get; set; }
    }
}
