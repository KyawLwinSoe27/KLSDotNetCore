using System;
using DotNetTraining.ConsoleApp.Models;
using Refit;

namespace DotNetTraining.ConsoleApp.RefitExamples
{
	public interface IBlogApi
	{
        [Get("/api/Blog")]
        Task<List<BlogModel>> GetBlogs();

        [Get("/api/Blog/{id}")]
        Task<BlogModel> GetBlog(int id);

        [Post("/api/Blog")]
        Task<string> CreateBlog(BlogModel blog);

        [Put("/api/Blog/{id}")]
        Task<string> UpdateBlog(int id, BlogModel blog);

        [Delete("/api/Blog/{id}")]
        Task<string> DeleteBlog(int id);
    }
}

