using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduNote.API.Repositories
{
    public class AppSettings: IAppSettings
    {
        public string Secret { get; set; }
    }
}
