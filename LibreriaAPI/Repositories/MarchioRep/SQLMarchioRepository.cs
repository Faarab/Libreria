using LibreriaAPI.Data;
using LibreriaAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibreriaAPI.Repositories.MarchioRep
{
    public class SQLMarchioRepository : IMarchioRepository
    {
        private readonly LibreriaDbContext dbContext;

        // use the DbContext class through the repository
        public SQLMarchioRepository(LibreriaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Marchio> CreateAsync(Marchio marchio)
        {
            await dbContext.Marchi.AddAsync(marchio);
            await dbContext.SaveChangesAsync();
            return marchio;
        }

        public async Task<Marchio> DeleteAsync(Guid id)
        {
            var existingMarchio = await dbContext.Marchi.FirstOrDefaultAsync(x => x.Id == id);
            if (existingMarchio == null)
            {
                return null;
            }
            dbContext.Marchi.Remove(existingMarchio);
            await dbContext.SaveChangesAsync();
            return existingMarchio;
        }

        public async Task<List<Marchio>> GetAllAsync()
        {
            return await dbContext.Marchi.ToListAsync();
        }

        public async Task<Marchio> GetByIdAsync(Guid id)
        {
            return await dbContext.Marchi.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Marchio> UpdateAsync(Guid id, Marchio marchio)
        {
            var existingMarchio = await dbContext.Marchi.FirstOrDefaultAsync(x => x.Id == id);
            if (existingMarchio == null)
            {
                return null;
            }

            existingMarchio.Name = marchio.Name;
            existingMarchio.Code = marchio.Code;

            await dbContext.SaveChangesAsync();
            return existingMarchio;

        }
    }
}
