using System;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using RestSharp;
using DotNetTraining.ConsoleApp.Models;
using System.Reflection.Metadata;
using System.Security.Policy;

namespace DotNetTraining.ConsoleApp.RestClientExamples
{
	public class RestClientExample
	{
		public RestClientExample()
		{
		}

        private readonly string _apiUrl = "https://localhost:7204/api/blog";

        public async Task Run()
        {
            await Read();
            await Edit(4);
            await Create("title", "author", "content");
            await Update(4, "title4", "author4", "content4");
            await Delete(4);
        }

        private async Task Read()
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(_apiUrl,Method.Get);
            RestResponse res = await restClient.ExecuteAsync(restRequest);
            if (res.IsSuccessStatusCode)
            {
                string jsonStr =  res.Content!;
                Console.WriteLine(jsonStr);
                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;

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
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest($"{_apiUrl}/{id}", Method.Get);
            RestResponse res = await restClient.ExecuteAsync(restRequest);
           
            if (res.IsSuccessStatusCode)
            {
                String jsonStr = res.Content!;

                BlogModel lst = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;

                Console.WriteLine(lst.BlogId);
                Console.WriteLine(lst.BlogTitle);
                Console.WriteLine(lst.BlogAuthor);
                Console.WriteLine(lst.BlogContent);
            }
            else
            {
                Console.WriteLine(res.Content);
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

            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest($"{_apiUrl}", Method.Post);
            restRequest.AddJsonBody(blog);
            RestResponse res = await restClient.ExecuteAsync(restRequest);

            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine(res.Content);
            }
            else
            {
                Console.WriteLine(res.Content);
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
            string url = $"{_apiUrl}/{id}";


            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(url, Method.Put);
            restRequest.AddJsonBody(blog);
            RestResponse res = await restClient.ExecuteAsync(restRequest);


            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine(res.Content);
            }
            else
            {
                Console.WriteLine(res.Content);
            }
        }

        private async Task Delete(int id)
        {
            string url = $"{_apiUrl}/{id}";
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(url, Method.Delete);
          
            RestResponse res = await restClient.ExecuteAsync(restRequest);
            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine(res.Content);
            }
        }
    }
}

