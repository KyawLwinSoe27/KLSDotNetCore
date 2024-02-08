using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using Dapper;
using DotNetTraining.ConsoleApp.Models;

namespace DotNetTraining.ConsoleApp.DapperExamples
{
	public class DapperExample
	{
		public DapperExample()
		{
		}

        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "localhost",
            InitialCatalog = "test_db",
            UserID = "sa",
            Password = "kyawlwinsoe123@"
        };

        public void Read()
        {
           

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);


            String query = @"SELECT 
                [BlogId], [BlogTitle], [BlogAuthor], [BlogContent]
                 FROM tbl_blog";

            List<BlogModel> lts =  db.Query<BlogModel>(query).ToList();

          foreach(BlogModel blog in lts)
            {
                Console.WriteLine(blog.BlogTitle);
                Console.WriteLine(blog.BlogAuthor);
                Console.WriteLine(blog.BlogContent);
            }



        }

        public void Edit(int id)
        {
            String query = @"SELECT 
                [BlogId], 
                [BlogTitle], 
                [BlogAuthor],
                [BlogContent]
                FROM Tbl_Blog WHERE BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            BlogModel? item = db.Query<BlogModel>(query, new {BlogId = id}).FirstOrDefault();

            if (item == null) {
                Console.WriteLine("No Result!");
                return;
            }

            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);

        }

        public String Save(String title, String author, String content)
        {


            String query = @"INSERT INTO Tbl_Blog
                (BlogTitle, 
                BlogAuthor,
                BlogContent) VALUES
                (
                @BlogTitle,
                @BlogAuthor,
                @BlogContent
)";
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };


            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            String message = result > 0 ? "Saving Successful" : "Saving failed!";

            return message;
        }

        public String Update(int id, String title, String author, String content)
        {

            String query = @"UPDATE Tbl_Blog
                SET [BlogTitle] = @BlogTitle, [BlogAuthor]= @BlogAuthor, [BlogContent]=@BlogContent
                WHERE BlogId = @BlogId";

            BlogModel blog = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);
            String message = result > 0 ? "Updating Successful" : "Updating failed!";

            return message;

        }

        public void Delete(int id)
        {

          
            String query = @"DELETE FROM Tbl_Blog
                WHERE BlogId = @BlogId";


            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            int result = db.Execute(query, new { BlogId = id });
            String message = result > 0 ? "Deleting Successful" : "Deleting failed!";

            Console.WriteLine(message);
        }
    }
}

