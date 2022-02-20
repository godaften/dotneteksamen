using Microsoft.AspNetCore.Mvc;
using cbsStudents.Models.Entities;

namespace cbsStudents.Controllers;

public class PostsController : Controller
{
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create([Bind("Title", "Text", "Status")] Post post)
    {
        if (ModelState.IsValid)
        {
            // go ahead and save it into the database
            // redirectToAction()

        }

        return View();
        // Console.WriteLine(post.Text + " " + post.Title);
        // return RedirectToAction("Test");
    }


    public IActionResult Test()
    {
        ViewBag.Jesper = "Jesper is here!";
        return View();
    }

}