using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduNote.API.Repositories
{
    public interface IAppSettings
    {
        public string Secret { get; set; }
    }
}
