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
        Console.WriteLine(post.Text + " " + post.Title);
        return RedirectToAction("Test");
    }


    public IActionResult Test()
    {
        ViewBag.Jesper = "Jesper is here!";
        return View();
    }

}