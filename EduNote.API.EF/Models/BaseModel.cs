using EduNote.API.EF.Interfaces;
using System;

namespace EduNote.API.EF.Models
{
    public class BaseModel: IEntity
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }

    }
}
