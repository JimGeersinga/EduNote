using System;
using System.Net.Http;

namespace EduNote.App.Api
{
    public interface IEduHttpClient
    {
        HttpClient HttpClient();
    }
}
