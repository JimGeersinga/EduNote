namespace EduNote.API.EF.Models
{
    public partial class UserGroups : BaseModel
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }

        public User User { get; set; }
        public Group Group { get; set; }
    }
}
