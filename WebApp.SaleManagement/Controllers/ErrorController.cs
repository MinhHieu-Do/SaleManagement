using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.SaleManagement.ViewModels;

namespace WebApp.SaleManagement.Controllers
{
    public class ErrorController : Controller
    {
        [Route("ErrorPage/{statuscode}")]
        public IActionResult Index(int statuscode)
        {
            var errorPage = new ErrorPage();
            switch (statuscode)
            {
                case 400:
                    errorPage.Message = "Bad Request";
                    break;
                case 404:
                    errorPage.Message = "Page Not Found";
                    break;
                case 403:
                    errorPage.Message = "Forbidden";
                    break;
                case 500:
                    errorPage.Message = "Internal Server Error";
                    break;
                case 501:
                    errorPage.Message = "Not Implemented";
                    break;
                case 502:
                    errorPage.Message = "Bad Gateway";
                    break;
                case 503:
                    errorPage.Message = "Service Unavailable";
                    break;
                case 504:
                    errorPage.Message = "Gateway Timeout";
                    break;
                case 505:
                    errorPage.Message = "HTTP Version Not Supported";
                    break;

            }
            
            errorPage.StatusCode = statuscode;
            return View("ErrorPage",errorPage);
        }
    }
}
