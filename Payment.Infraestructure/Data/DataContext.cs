using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.DirectoryServices.ActiveDirectory;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Payment.Domain.Entities;

namespace Payment.Infraestructure.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        DbSet<PriceList> PriceLists { get; set; }
        DbSet<Domain.Entities.Payment> Payments { get; set; }
    }
}
