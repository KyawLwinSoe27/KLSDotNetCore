using System;
using DotNetTraining.ConsoleApp.Models;
using Newtonsoft.Json;

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
	}
}

