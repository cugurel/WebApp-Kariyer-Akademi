using Microsoft.AspNetCore.Mvc;

namespace WebApp.CustomFilter
{
    public class ResponseCacheFilter : ResponseCacheAttribute
    {
        public ResponseCacheFilter() : base()
        {
            Location = ResponseCacheLocation.None;
            NoStore = true;
        }
    }
}
