using CafeApp.Data.Repository;
using CafeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeApp.Data.Repositories
{
    public class RestaurantRepository : IRepository<Restaurant>
    {
        private readonly AppDbContext appDbContext;

        public RestaurantRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Restaurant>> GetAll()
        {
            return await appDbContext.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> GetById(int id)
        {
            return await appDbContext.Restaurants.FindAsync(id);
        }

        public async Task Add(Restaurant restaurant)
        {
            await appDbContext.Restaurants.AddAsync(restaurant);
            await appDbContext.SaveChangesAsync();

        }

        public async Task Delete(Restaurant entity)
        {
            appDbContext.Restaurants.Remove(entity);
            await appDbContext.SaveChangesAsync();
        }

        public async Task Update(Restaurant entity)
        {
            appDbContext.Restaurants.Update(entity);
            await appDbContext.SaveChangesAsync();

        }
    }
}
