using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public interface IDataContext : IDisposable
    {
        DbSet<Advertisement> Advertisement { get; set; }

        Task<int> SaveChangesAsync();
    }
}