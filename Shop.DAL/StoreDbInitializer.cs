using Microsoft.EntityFrameworkCore;
using Store.DAL.Interfaces;
using Store.DAL.SeedDataStoreDb;

namespace Store.DAL
{
    public static class DbInitializer<T> 
        where T: IStoreDbContext
    {
        public static void Initialize(StoreDbContext context)
        {
            context.Database.EnsureCreated();
        }

        public static void InitializeSeedData(ModelBuilder builder)
        {
            InitCountries.Init(builder,Constans.PathDerectory + Constans.Countries);
            InitColors.Init(builder, Constans.PathDerectory + Constans.Colors);
            //init data...
        }
    }
}
