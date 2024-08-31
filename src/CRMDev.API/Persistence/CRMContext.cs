using CRMDev.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRMDev.API.Persistence
{
    public class CRMContext : DbContext
    {
        public CRMContext(DbContextOptions<CRMContext> options)
            : base(options)
        {
            
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}