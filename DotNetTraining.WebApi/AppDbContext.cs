using System;
using DotNetTraining.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace DotNetTraining.ConsoleApp.EFCoreExamples
{
	public class AppDbContext : DbContext
	{
		public AppDbContext()
		{
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "localhost",
                InitialCatalog = "test_db",
                UserID = "sa",
                Password = "kyawlwinsoe123@",
                TrustServerCertificate = true
            };
            optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ConnectionString);
        }

        //Mapping Configure
        public DbSet<BlogModel> Blogs { get; set; }
    }
}

