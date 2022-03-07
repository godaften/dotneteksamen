using Microsoft.AspNetCore.Mvc;
using cbsStudents.Models.Entities;
using CbsStudents.Data;

namespace cbsStudents.Controllers;

public class PostsController : Controller
{
    private CbsStudentsContext _context;
    public PostsController(CbsStudentsContext context)
    {
        this._context = context;
    }

    public IActionResult Index()
    {
        IEnumerable<Post> posts = _context.Posts.ToList();
        return View(posts);
    }

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
            post.Created = DateTime.Now;
            _context.Posts.Add(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View();
        // Console.WriteLine(post.Text + " " + post.Title);
        // return RedirectToAction("Test");
    }

    public IActionResult Edit(int id)
    {
        Post p = _context.Posts.Find(id);
        return View(p);
    }

    [HttpPost]
    public IActionResult Edit(int id, [Bind("Id", "Title", "Text", "Status")] Post post)
    {
        if (ModelState.IsValid)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View();
    }


    public IActionResult Test()
    {
        ViewBag.Jesper = "Jesper is here!";
        return View();
    }

}