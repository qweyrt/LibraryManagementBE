using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;

namespace LibraryManagement.Models
{

    public class LibraryManagementDbContext : DbContext
    {
        public LibraryManagementDbContext(DbContextOptions<LibraryManagementDbContext> options)
            : base(options)
        {
        }
        public DbSet<BooksModel> Books { get; set; }
        public DbSet<RequestModel> Requests { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<RequestDetailsModel> RequestDetails { get; set; }
        public DbSet<UserModel> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<BooksModel>()
            .Property(f => f.BookID)
            .ValueGeneratedOnAdd();
            builder.Entity<CategoryModel>()
            .Property(f => f.CategoryID)
            .ValueGeneratedOnAdd();
            builder.Entity<UserModel>()
            .Property(f => f.UserId)
            .ValueGeneratedOnAdd();
            builder.Entity<RequestModel>()
            .Property(f => f.RequestID)
            .ValueGeneratedOnAdd();
            builder.Entity<RequestDetailsModel>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
            builder.Entity<RequestModel>()
            .Property(b => b.RequestStatus)
            .HasDefaultValue((Status)0);
            builder.Entity<CategoryModel>().HasData(
                new CategoryModel { CategoryID = 1, CategoryName = "Fantasy" },
                new CategoryModel { CategoryID = 2, CategoryName = "Adventure" },
                new CategoryModel { CategoryID = 3, CategoryName = "Romance" },
                new CategoryModel { CategoryID = 4, CategoryName = "Contemporary" },
                new CategoryModel { CategoryID = 5, CategoryName = "Mystery" },
                new CategoryModel { CategoryID = 6, CategoryName = "Horror" },
                new CategoryModel { CategoryID = 7, CategoryName = "Cooking" },
                new CategoryModel { CategoryID = 8, CategoryName = "Sci Fi" }
            );

            /*builder.Entity<BooksModel>().HasData(
                new BooksModel { BookID = 1, BookName = "Alexander", CategoryID = 1 },
                new BooksModel { BookID = 2, BookName = "Alonso", CategoryID = 2 },
                new BooksModel { BookID = 3, BookName = "Anand", CategoryID = 3 },
                new BooksModel { BookID = 4, BookName = "Barzdukas", CategoryID = 4 },
                new BooksModel { BookID = 5, BookName = "Li", CategoryID = 5 },
                new BooksModel { BookID = 6, BookName = "Justice", CategoryID = 6 },
                new BooksModel { BookID = 7, BookName = "Norman", CategoryID = 7 },
                new BooksModel { BookID = 8, BookName = "Olivetto", CategoryID = 8 }
            );

            builder.Entity<RequestModel>().HasData(
                new RequestModel { RequestID = 1, RequestName = "1", RequestStatus = "Approved" },
                new RequestModel { RequestID = 2, RequestName = "2", RequestStatus = "Approved" },
                new RequestModel { RequestID = 3, RequestName = "3", RequestStatus = "Rejected" }
            );*/
            builder.Entity<UserModel>().HasData(new UserModel
            {
                UserId = 1,
                Username = "admin",
                Password = "12345",
                DoB = DateTime.Now.AddYears(-50),
                Name = "Tony Stark",
                Role = (UserRoles)0
            });
            builder.Entity<UserModel>().HasData(new UserModel
            {
                UserId = 2,
                Username = "user",
                Password = "12345",
                DoB = DateTime.Now.AddYears(-40),
                Name = "Bruce Banner",
                Role = (UserRoles)1
            });
        }
    }
}
