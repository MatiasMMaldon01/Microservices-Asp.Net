using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Rutine.Domain.Entities;

namespace Rutine.Infraestructure.DataContext
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
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

        DbSet<Domain.Entities.Rutine> Rutines { get; set; }
        DbSet<RutineDetail> RutineDetails { get; set; }
        DbSet<Exercise> Exercises { get; set; }


    }
}
