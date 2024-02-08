using System;
using DotNetTraining.ConsoleApp.Models;
using MySqlX.XDevAPI.Common;

namespace DotNetTraining.ConsoleApp.EFCoreExamples
{
	public class EFCoreExamples
	{
		public EFCoreExamples()
		{
		}

		public void Read()
		{
			AppDbContext dbContext = new AppDbContext();
			List<BlogModel> lts = dbContext.Blogs.ToList();

			foreach (BlogModel item in lts) {
				Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

		public void Edit(int id) {
			AppDbContext dbContext = new AppDbContext();
			BlogModel? item = dbContext.Blogs.FirstOrDefault(item => item.BlogId == id);

            if(item == null)
			{
				Console.WriteLine("No Data Found");
				return;
			}

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

		public void Create(String title, String author, String content)
		{
			BlogModel blog = new BlogModel()
			{
				BlogTitle = title,
				BlogAuthor = author,
				BlogContent = content
			};

			AppDbContext dbContext = new AppDbContext();
			dbContext.Add(blog);
			int result = dbContext.SaveChanges();
            String message = result > 0 ? "Saving Successful" : "Saving failed!";
			Console.WriteLine(message);
        }

		public void Update(int id, String title, String author, String content)
		{
			AppDbContext dbContext = new AppDbContext();
			BlogModel? item = dbContext.Blogs.FirstOrDefault(item => item.BlogId == id);

            if (item == null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

			item.BlogTitle = title;
			item.BlogAuthor = author;
			item.BlogContent = content;

			int result = dbContext.SaveChanges();

            String message = result > 0 ? "Updating Successful" : "Updating failed!";
            Console.WriteLine(message);
        }

		public void Delete(int id)
		{
            AppDbContext dbContext = new AppDbContext();
            BlogModel? item = dbContext.Blogs.FirstOrDefault(item => item.BlogId == id);

            if (item == null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

			dbContext.Blogs.Remove(item);
			int result = dbContext.SaveChanges();
            String message = result > 0 ? "Deleting Successful" : "Deleting failed!";

            Console.WriteLine(message);
        }

	}
}

