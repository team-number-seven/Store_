using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.DAL.Interfaces;
using Store.DAL.SeedDataStoreDb;

namespace Store.DAL
{
    public static class DbInitializer<T>
        where T : IStoreDbContext
    {
        public static void Initialize(StoreDbContext context)
        {
            context.Database.EnsureCreated();
        }

        public static async Task InitializeSeedData(ModelBuilder builder)
        {
            await InitCountries.Init(builder, Constans.PathDerectory + Constans.Countries);
            await InitColors.Init(builder, Constans.PathDerectory + Constans.Colors);
            //init data...
        }
    }
}