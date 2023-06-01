using LibreriaAPI.Data;
using LibreriaAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibreriaAPI.Repositories
{
    public class SQLTipologiaRepository : ITipologiaRepository
    {
        private readonly LibreriaDbContext dbContext;

        public SQLTipologiaRepository(LibreriaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Tipologia> CreateAsync(Tipologia tipologia)
        {
            await dbContext.Tipologie.AddAsync(tipologia);
            await dbContext.SaveChangesAsync();
            return tipologia;
        }

        public async Task<Tipologia> DeleteAsync(Guid id)
        {
            var existingTipologia = await dbContext.Tipologie.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTipologia == null)
            {
                return null;
            }
            dbContext.Tipologie.Remove(existingTipologia);
            await dbContext.SaveChangesAsync();
            return existingTipologia;
        }

        public async Task<List<Tipologia>> GetAllAsync()
        {
            return await dbContext.Tipologie.ToListAsync();
        }

        public async Task<Tipologia> GetByIdAsync(Guid id)
        {
            return await dbContext.Tipologie.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tipologia> UpdateAsync(Guid id, Tipologia tipologia)
        {
            var existingMarchi = await dbContext.Tipologie.FirstOrDefaultAsync(x => x.Id == id);
            if (existingMarchi == null)
            {
                return null;
            }

            existingMarchi.Name = tipologia.Name;
            existingMarchi.Code = tipologia.Code;

            await dbContext.SaveChangesAsync();
            return existingMarchi;

        }
    }
}
