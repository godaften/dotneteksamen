using Microsoft.AspNetCore.Mvc;

namespace cbsStudents.Controllers;

public class PostsController : Controller
{
    public IActionResult Test()
    {
        ViewBag.Jesper = "Jesper is here!";
        return View();
    }

}