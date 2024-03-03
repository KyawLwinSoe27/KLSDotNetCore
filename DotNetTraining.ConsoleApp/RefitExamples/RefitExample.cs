using System;
using DotNetTraining.ConsoleApp.Models;
using Newtonsoft.Json;
using Refit;
using RestSharp;

namespace DotNetTraining.ConsoleApp.RefitExamples
{
	public class RefitExample
	{
		public RefitExample()
		{
		}

        IBlogApi blogApi = RestService.For<IBlogApi>("https://localhost:7204");

        public async Task Run()
		{
			await Read();
            await Edit(3);
            await Edit(1032);
            await Create("title Refit", "author Refit", "content Refit");
            await Update(3, "title", "author3", "content3");
            await Delete(3);

		}

		private async Task Read()
		{
            
            var items = await blogApi.GetBlogs();
			foreach(var item in items)
			{
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine(item.BlogTitle);
            }
			
        }

        private async Task Edit(int id)
        {

            try
            {
                var item = await blogApi.GetBlog(id);
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine(item.BlogTitle);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }


        private async Task Create(string title, string author, string content)
        {

            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            try
            {
                var message = await blogApi.CreateBlog(blog);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task Update(int id, string title, string author, string content)
        {

            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            try
            {
                var message = await blogApi.UpdateBlog(id, blog);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }



        private async Task Delete(int id)
        {
            try {

                var message = await blogApi.DeleteBlog(id);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

