namespace EduNote.API.EF.Models
{
    public partial class QuestionTags : BaseModel
    {
        public int QuestionId { get; set; }
        public int TagId { get; set; }

        public Question Question { get; set; }
        public Tag Tag { get; set; }
    }
}
