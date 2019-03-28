using System;
using System.Net;
using System.Net.Http;
using EduNote.App.Api;
using EduNote.App.Droid.Clients;

[assembly: Xamarin.Forms.Dependency(typeof(EduHttpClient))]
namespace EduNote.App.Droid.Clients
{
    public class EduHttpClient : IEduHttpClient
    {
        public HttpClient HttpClient()
        {
            Console.WriteLine("Creating httpclient on android");
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            return new HttpClient(new Xamarin.Android.Net.AndroidClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
            });
        }
    }
}
