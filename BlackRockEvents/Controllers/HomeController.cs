using BlackRockEvents.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlackRockEvents.Controllers
{
    /*This controller is visible to all users whether or not they are authorized.*/
   [AllowAnonymous]
   public class HomeController : Controller
   {
      /*This method returns the home page view which consists of a carousel of images of the venue and details about the venue.*/
      public IActionResult Index()
      {
         return View();
      }
      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
