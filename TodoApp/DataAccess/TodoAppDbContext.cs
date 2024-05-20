using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.DataAccess
{
    public class TodoAppDbContext : DbContext
    {
        private readonly string ConnectionString = "server=127.0.0.1;uid=root;pwd=123456;database=todoapp";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
