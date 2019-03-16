using System.Collections.Generic;

namespace EduNote.API.EF.Models
{
    public partial class Group : BaseModel
    {
        public string Name { get; set; }

        public ICollection<UserGroups> UserGroups { get; set; }
    }
}