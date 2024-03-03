using DotNetTraining.ConsoleApp.EFCoreExamples;
using DotNetTraining.ConsoleApp.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetTraining.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _db;

        public BlogController()
        {
            _db = new AppDbContext();
        }

        // GET: api/values
        [HttpGet]
        public IActionResult GetBlogs()
        {
            List<BlogModel> lst = _db.Blogs.OrderByDescending(x => x.BlogId).ToList();
            return Ok(lst);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);

            if (item == null)
            {
                Console.WriteLine("No Data Found");
                return NotFound("No Data Found");
            }

            return Ok(item);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(BlogModel blog)
        {
            _db.Blogs.Add(blog);
            int result = _db.SaveChanges();
            String message = result > 0 ? "Save Success" : "Failed";
            return Ok(message);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, BlogModel blog)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);

            if (item == null)
            {
                Console.WriteLine("No Data Found");
                return NotFound("No Data Found");
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor =blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            int result = _db.SaveChanges();

            String message = result > 0 ? "Updating Successful" : "Updating failed!";

            return Ok(message);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if (item == null)
            {
                Console.WriteLine("No Data Found");
                return NotFound("No Data Found");
            }

            _db.Blogs.Remove(item);
            int result = _db.SaveChanges();

            String message = result > 0 ? "Delete Succcess" : "Delete Failed";
            return Ok(message);
        }
    }
}

