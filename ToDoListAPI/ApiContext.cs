using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Models;

namespace ToDoListAPI
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ToDoListDb");
        }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
