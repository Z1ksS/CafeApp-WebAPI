using CafeApp.Data;
using CafeApp.Data.Repository;
using CafeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CafeApp.Data.Repositories
{
    public class NewsRepository : IRepository<News>
    {
        private readonly AppDbContext appDbContext;

        public NewsRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<News>> GetAll()
        {
            return await appDbContext.Set<News>().ToListAsync();
        }

        public async Task<News> GetById(int id)
        {
            return await appDbContext.Set<News>().FindAsync(id);
        }

        public async Task Add(News news)
        {
            await appDbContext.Set<News>().AddAsync(news);
            await appDbContext.SaveChangesAsync();
        }

        public async Task Delete(News news)
        {
            appDbContext.Set<News>().Remove(news);
            await appDbContext.SaveChangesAsync();
        }

        public async Task Update(News news)
        {
            appDbContext.Set<News>().Update(news);
            await appDbContext.SaveChangesAsync();
        }
    }
}
