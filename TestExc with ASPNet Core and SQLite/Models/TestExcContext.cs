using System;
using Microsoft.EntityFrameworkCore;

namespace TestExc_with_ASPNet_Core_and_SQLite.Models
{
    public class TestExcContext : DbContext
    {
        public string DbPath { get; private set; }

        public TestExcContext(DbContextOptions<TestExcContext> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}Database.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite($"Data Source={DbPath}");

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TimeShift> TimeShifts { get; set; }
    }
}
