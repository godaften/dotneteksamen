using Microsoft.AspNetCore.Mvc;
using cbsStudents.Models.Entities;
using CbsStudents.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace cbsStudents.Controllers;

[Authorize]
public class PostsController : Controller
{
    private CbsStudentsContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public PostsController(CbsStudentsContext context, UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
        this._context = context;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        // var posts = from p in _context.Posts select p;

        var posts = _context.Posts.Include(y => y.User).ToList();
        // posts = posts.Include(y => y.User);

        // IEnumerable<Post> posts = _context.Posts.ToList();
        return View(posts);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Title", "Text", "Status")] Post post)
    {
        if (ModelState.IsValid)
        {
            // go ahead and save it into the database
            // redirectToAction()
            IdentityUser user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            post.UserId = user.Id;

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