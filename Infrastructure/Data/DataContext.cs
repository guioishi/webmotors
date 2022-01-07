using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    /// <summary>
    /// Database data constext.
    /// </summary>
    public class DataContext : DbContext, IDataContext
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        public DataContext()
        {
            // used in unit test
        }

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="options">Database context options.</param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<Core.Entities.Advertisement> Advertisement { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Core.Entities.Advertisement>().ToTable("tb_AnuncioWebmotors");
        }
    }
}