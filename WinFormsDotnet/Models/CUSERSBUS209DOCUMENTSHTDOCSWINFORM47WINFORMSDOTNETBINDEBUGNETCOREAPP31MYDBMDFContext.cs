using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WinFormsDotnet.Models
{
    public partial class CUSERSBUS209DOCUMENTSHTDOCSWINFORM47WINFORMSDOTNETBINDEBUGNETCOREAPP31MYDBMDFContext : DbContext
    {
        public CUSERSBUS209DOCUMENTSHTDOCSWINFORM47WINFORMSDOTNETBINDEBUGNETCOREAPP31MYDBMDFContext()
        {
        }

        public CUSERSBUS209DOCUMENTSHTDOCSWINFORM47WINFORMSDOTNETBINDEBUGNETCOREAPP31MYDBMDFContext(DbContextOptions<CUSERSBUS209DOCUMENTSHTDOCSWINFORM47WINFORMSDOTNETBINDEBUGNETCOREAPP31MYDBMDFContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MyDb.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
