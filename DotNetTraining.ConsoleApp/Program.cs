// See https://aka.ms/new-console-template for more information

using System.Data;
using System.Data.SqlClient;
using DotNetTraining.ConsoleApp.AdoDotNetExamples;
using DotNetTraining.ConsoleApp.DapperExamples;
using DotNetTraining.ConsoleApp.EFCoreExamples;
using DotNetTraining.ConsoleApp.HttpClientExamples;
using DotNetTraining.ConsoleApp.Models;
using DotNetTraining.ConsoleApp.RefitExamples;
using DotNetTraining.ConsoleApp.RestClientExamples;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
////adoDotNetExample.Read();
////adoDotNetExample.Edit(1);
////adoDotNetExample.Edit(21);

//String str = adoDotNetExample.Save("Title Form C#", "Author From C#", "Content From C#");

//str = adoDotNetExample.Update(5, "This is title2", "This is the author edited", "this is content edited");
//Console.WriteLine(str);
//adoDotNetExample.Delete(7);

//DapperExample dapperExample = new DapperExample();

//dapperExample.Read();
//dapperExample.Edit(1);
//dapperExample.Edit(21);
//String str = dapperExample.Save("Title Form C# Dapper", "Author From C# Dapper", "Content From C# Dapper");
//String str = dapperExample.Update(10,"Title Form C# Dapper Edited", "Author From C# Dapper Edited", "Content From C# Dapper Edited");
//Console.WriteLine(str);
//dapperExample.Delete(1);

//EFCoreExamples eFCoreExamples = new EFCoreExamples();
//eFCoreExamples.Read();
//eFCoreExamples.Edit(18);
//eFCoreExamples.Edit(21);
//eFCoreExamples.Create("Title Form C#", "Author From C#", "Content From C#");
//eFCoreExamples.Update(19, "This is title Edited", "This is the author edited", "this is content edited");
//eFCoreExamples.Delete(19);



//BlogModel blog = new BlogModel();
//blog.BlogAuthor = "Test";
//blog.BlogContent = "Test";
//blog.BlogTitle = "Test";

//string res = JsonConvert.SerializeObject(blog);

//Console.WriteLine(res);

//BlogModel resBlog = JsonConvert.DeserializeObject<BlogModel>(res)!;

//Console.WriteLine(resBlog.BlogTitle);
//Console.WriteLine(resBlog.BlogAuthor);
//Console.WriteLine(resBlog.BlogContent);

Console.WriteLine("Waiting for API ...");
Console.ReadKey();

//HttpClientExample httpClientExample = new HttpClientExample();
//await httpClientExample.Run();

//RestClientExample restClientExample = new RestClientExample();
//await restClientExample.Run();

RefitExample refitClientExample = new RefitExample();
await refitClientExample.Run();

Console.ReadKey();