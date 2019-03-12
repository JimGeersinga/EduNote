using EduNote.API.EF.Models;
using System;

namespace EduNote.API.EF.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }

        DateTime Created { get; set; }
        DateTime? Modified { get; set; }

        int? CreatedById { get; set; }
        int? ModifiedById { get; set; }

        User CreatedBy { get; set; }
        User ModifiedBy { get; set; }
    }
}
