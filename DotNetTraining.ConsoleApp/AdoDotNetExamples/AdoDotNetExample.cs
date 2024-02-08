using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace DotNetTraining.ConsoleApp.AdoDotNetExamples
{
	public class AdoDotNetExample
	{
		public AdoDotNetExample()
		{
		}

		public void Read()
		{
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "localhost";
            sqlConnectionStringBuilder.InitialCatalog = "test_db";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "kyawlwinsoe123@";

            String query = "SELECT * FROM tbl_blog";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);


            sqlConnection.Close();

            //DataSet
            //DataTable
            //DataRow
            //DataColumn

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
            }
        }

        public void Edit(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "localhost";
            sqlConnectionStringBuilder.InitialCatalog = "test_db";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "kyawlwinsoe123@";

            
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();

            String query = @"SELECT 
                [BlogId], 
                [BlogTitle], 
                [BlogAuthor],
                [BlogContent]
                FROM Tbl_Blog WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);


            sqlConnection.Close();

            if(dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data Found!");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
            
           
        }

        public String Save(String title, String author, String content) {

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "localhost";
            sqlConnectionStringBuilder.InitialCatalog = "test_db";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "kyawlwinsoe123@";


            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();

            String query = @"INSERT INTO Tbl_Blog
                (BlogTitle, 
                BlogAuthor,
                BlogContent) VALUES
                (
                @BlogTitle,
                @BlogAuthor,
                @BlogContent
)";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            int result = cmd.ExecuteNonQuery();

            sqlConnection.Close();

            String message = result > 0 ? "Saving Successful" : "Saving failed!";

            return message;
        }

        public String Update(int id, String title, String author, String content) {

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "localhost";
            sqlConnectionStringBuilder.InitialCatalog = "test_db";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "kyawlwinsoe123@";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            String query = @"UPDATE Tbl_Blog
                SET [BlogTitle] = @BlogTitle, [BlogAuthor]= @BlogAuthor, [BlogContent]=@BlogContent
                WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query,sqlConnection);

            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            int result = cmd.ExecuteNonQuery();

            sqlConnection.Close();
            String message = result > 0 ? "Updating Successful" : "Updating failed!";

            return message;

        }

        public void Delete(int id) {

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "localhost";
            sqlConnectionStringBuilder.InitialCatalog = "test_db";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "kyawlwinsoe123@";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            String query = @"DELETE FROM Tbl_Blog
                WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            cmd.Parameters.AddWithValue("@BlogId", id);

            int result = cmd.ExecuteNonQuery();

            sqlConnection.Close();
            String message = result > 0 ? "Deleting Successful" : "Deleting failed!";

            Console.WriteLine(message);
        }
    }
}

