using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetTraining.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetTraining.MvcApp.Controllers
{
    // https://localhost:7068/Blog/Index
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;

        public BlogController()
        {
            _db = new AppDbContext();
        }

        //https://localhost:7068/Blog/Index
        [ActionName("Index")] // logical name
        public IActionResult BlogIndex()
        {
            List<BlogModel> lst = _db.Blogs.ToList();
            return View("BlogIndex", lst); //physical name
        }

        //https://localhost:7068/Blog/Edit/1
        //https://localhost:7068/Blog/Edit?id=1 if it doesn't match our pattern (pattern exist in program.cs)
        [ActionName("Edit")]
        public IActionResult BlogEdit(int id)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return Redirect("/Blog");
            } else
            {
                return View("BlogEdit", item);
            }
            
        }
    }
}

