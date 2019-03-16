namespace EduNote.API.EF.Models
{
    public partial class UserGroups : BaseModel
    {
        public long UserId { get; set; }
        public long GroupId { get; set; }

        public User User { get; set; }
        public Group Group { get; set; }
    }
}
