using LibreriaAPI.Data;
using LibreriaAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibreriaAPI.Repositories.StatoRep
{
    public class SQLStatoRepository : IStatoRepository
    {
        private readonly LibreriaDbContext dbContext;

        public SQLStatoRepository(LibreriaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Stato> CreateAsync(Stato stato)
        {
            await dbContext.Stati.AddAsync(stato);
            await dbContext.SaveChangesAsync();
            return stato;
        }

        public async Task<Stato> DeleteAsync(Guid id)
        {
            var existingStato = await dbContext.Stati.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStato == null)
            {
                return null;
            }
            dbContext.Stati.Remove(existingStato);
            await dbContext.SaveChangesAsync();
            return existingStato;
        }

        public async Task<List<Stato>> GetAllAsync()
        {
            return await dbContext.Stati.ToListAsync();
        }

        public async Task<Stato> GetByIdAsync(Guid id)
        {
            return await dbContext.Stati.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Stato> UpdateAsync(Guid id, Stato stato)
        {
            var existingStato = await dbContext.Stati.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStato == null)
            {
                return null;
            }

            existingStato.Descrizione = stato.Descrizione;
            existingStato.Code = stato.Code;

            await dbContext.SaveChangesAsync();
            return existingStato;
        }
    }
}
