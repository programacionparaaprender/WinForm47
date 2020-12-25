using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Logging;

namespace WinFormsDotnet.Models
{
    public class MyDBContext:DbContext
    {
        //Configuration.GetConnectionString("BloggingDatabase")
        //public MyDBContext() : base("Data Source=BONE\\SQLEXPRESS;Initial Catalog=TEST;Integrated Security=True")
        //public MyDBContext():base("MyDBConnectionString")
        //public MyDBContext() : base(ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString)
        //public MyDBContext() : base(Configuration.GetConnectionString("MyDBConnectionString"))
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MyDBConnectionString"].ConnectionString);
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MyDb.mdf;Integrated Security=True")
            .EnableSensitiveDataLogging(true);
            //.UseLoggerFactory(new LoggerFactory().addConsole((category, level)=>));
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<Workout> Workout { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Detail> Details { get; set; }

    }
}
