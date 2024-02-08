// See https://aka.ms/new-console-template for more information

using System.Data;
using System.Data.SqlClient;
using DotNetTraining.ConsoleApp.AdoDotNetExamples;
using DotNetTraining.ConsoleApp.DapperExamples;
using DotNetTraining.ConsoleApp.EFCoreExamples;

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

EFCoreExamples eFCoreExamples = new EFCoreExamples();
//eFCoreExamples.Read();
//eFCoreExamples.Edit(18);
//eFCoreExamples.Edit(21);
//eFCoreExamples.Create("Title Form C#", "Author From C#", "Content From C#");
//eFCoreExamples.Update(19, "This is title Edited", "This is the author edited", "this is content edited");
eFCoreExamples.Delete(19);
Console.ReadKey();