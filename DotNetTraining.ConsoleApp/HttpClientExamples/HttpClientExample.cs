using System;
using System.Reflection.Metadata;
using System.Text;
using DotNetTraining.ConsoleApp.Models;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace DotNetTraining.ConsoleApp.HttpClientExamples
{
	public class HttpClientExample
	{
		public HttpClientExample()
		{
		}

		public async Task Run()
		{
			await Read();
			await Edit(4);
			await Create("title","author","content");
			await Update(4,"title4","author4","content4");
            await Delete(4);
		}

		private async Task Read()
		{
			HttpClient httpClient = new HttpClient();
			HttpResponseMessage res = await httpClient.GetAsync("https://localhost:7204/api/blog");
			if (res.IsSuccessStatusCode)
			{
				String jsonStr = await res.Content.ReadAsStringAsync();
				Console.WriteLine(jsonStr);

                //JsonConvert.SerializeObject // Obj to Json
                //JsonConvert.DeserializeObject // Json to Obj

                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr);

				foreach (BlogModel blog in lst)
				{
                    Console.WriteLine(blog.BlogId);
                    Console.WriteLine(blog.BlogTitle);
                    Console.WriteLine(blog.BlogAuthor);
                    Console.WriteLine(blog.BlogContent);
                }
			}

		}

		private async Task Edit(int id)
		{
			HttpClient httpClient = new HttpClient();
			HttpResponseMessage res = await httpClient.GetAsync($"https://localhost:7204/api/blog/{id}");
			if (res.IsSuccessStatusCode)
			{
				String jsonStr = await res.Content.ReadAsStringAsync();

				BlogModel lst = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;

				Console.WriteLine(lst.BlogId);
				Console.WriteLine(lst.BlogTitle);
				Console.WriteLine(lst.BlogAuthor);
				Console.WriteLine(lst.BlogContent);
			}
			else
			{
				Console.WriteLine(await res.Content.ReadAsStringAsync());
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

			string jsonBlog = JsonConvert.SerializeObject(blog);
			string url = $"https://localhost:7204/api/blog";


            HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, Application.Json);
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage res = await httpClient.PostAsync(url, httpContent);
            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine(await res.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(await res.Content.ReadAsStringAsync());
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

            string jsonBlog = JsonConvert.SerializeObject(blog);
            string url = $"https://localhost:7204/api/blog/{id}";


            HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, Application.Json);
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage res = await httpClient.PutAsync(url, httpContent);
            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine(await res.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(await res.Content.ReadAsStringAsync());
            }
        }

		private async Task Delete(int id)
		{
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage res = await httpClient.DeleteAsync($"https://localhost:7204/api/blog/{id}");
            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine(await res.Content.ReadAsStringAsync());
            }
        }
    }
}

