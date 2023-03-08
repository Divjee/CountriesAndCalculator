using CtoHomework.Models;
using Microsoft.EntityFrameworkCore;

namespace CtoHomework.Data
{
    public class CtoHomeworkDbContext: DbContext
    {
        public CtoHomeworkDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Calculator> Calculations { get; set; }
    }
}
