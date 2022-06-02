using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectStudents.Models.Entities;

namespace ProjectStudents.DataAccess
{
    public class Context : IdentityDbContext<User>
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        public DbSet<Discipline> Disciplines { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Learn> Learn { get; set; }
    }
}
