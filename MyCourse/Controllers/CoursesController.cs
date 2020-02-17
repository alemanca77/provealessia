using Microsoft.AspNetCore.Mvc;

namespace MyCourse.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index(){
            // Una volta create la cartella/sottocartella Vieews/Courses e l'Index.cshtml.
            // L'acton che segue : asp.net core mvc andrà a cercare una View che segue le convenzioni: che si chiama Index.cshtml contenuta all'interno della directory courses contenuta all'interno
            // di Views 
            return View();
            // return View("Detail");
        }
          public IActionResult Detail(string id){
            //return Content($"Sono Detail, ho ricevuto l'id {id}");
            return View();
        }
    }
}