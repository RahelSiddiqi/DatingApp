using Microsoft.AspNetCore.Http;

namespace DatingApp.Helpers
{
    public static class Extentions
    {
        public static void AddApplicationErrors(this HttpResponse response, string message){
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Header", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}