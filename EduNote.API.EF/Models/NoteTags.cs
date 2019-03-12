namespace EduNote.API.EF.Models
{
    public partial class NoteTags : BaseModel
    {
        public int NoteId { get; set; }
        public int TagId { get; set; }

        public Note Note { get; set; }
        public Tag Tag { get; set; }
    }
}
