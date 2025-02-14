using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class ToDoListDbContext: IdentityDbContext
    {
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options) { }
        public DbSet<TaskList> TaskList { get; set; }

        public DbSet<CategoryList> CategoryList { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
       
        //protected override void OnModelCreating(ModelBuilder modelBuilder)           //sonradan ekledik-tabloları birleştirmek için
        //{
        //    modelBuilder.Entity<CategoryList>()
        //        .HasMany(c => c.TaskList)
        //        .WithOne(t => t.CategoryList)
        //        .HasForeignKey(t => t.CategoryListId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //}

    }
}
