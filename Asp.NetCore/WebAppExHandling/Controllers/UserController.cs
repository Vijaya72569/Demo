using Microsoft.AspNetCore.Mvc;

namespace WebAppExHandling.Controllers
{
    public class UserController : Controller
    {
        [Route("Display/{StatusCode}")]
        public IActionResult Display(int StatusCode)
        {
            switch (StatusCode)
            {
                case 400:ViewBag.Title = "Bad Request";
                    ViewBag.Msg = "The Server Can't return a response due to an error on the client side";
                    break;
                case 401:
                    ViewBag.Title = "Unauthorized or Authorization Required";
                    ViewBag.Msg = "Return by server when the target resource lacks authentication credentials";
                    break;
                case 402:
                    ViewBag.Title = "Payment Required";
                    ViewBag.Msg = "Processing the request is not possible due to lack of required founds";
                    break;
                case 403:
                    ViewBag.Title = "Forbidden";
                    ViewBag.Msg = "Your are attempting to access the resource that you don't have permission to view";
                    break;
                case 404:
                    ViewBag.Title = "404-Runtime Error";
                    ViewBag.Msg = "Page is not found";
                    break;
                case 405:
                    ViewBag.Title = "Method not Allowed";
                    ViewBag.Msg = "Hosting Server supports the method received,but the target resource doesn't";
                    break;
            }
            return View("PageNotFound");
        }
    }
}
