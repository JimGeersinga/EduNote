namespace EduNote.API.EF.Models
{
    public partial class QuestionTags : BaseModel
    {
        public long QuestionId { get; set; }
        public long TagId { get; set; }

        public Question Question { get; set; }
        public Tag Tag { get; set; }
    }
}
