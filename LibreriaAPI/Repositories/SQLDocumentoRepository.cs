using LibreriaAPI.Data;
using LibreriaAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibreriaAPI.Repositories
{
    public class SQLDocumentoRepository : IDocumentoRepository
    {
        private readonly LibreriaDbContext dbContext;

        public SQLDocumentoRepository(LibreriaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Documento> CreateAsync(Documento documento)
        {
            await dbContext.Documenti.AddAsync(documento);
            await dbContext.SaveChangesAsync();
            return documento;
        }

        public async Task<Documento> DeleteAsync(Guid id)
        {
            var existingDocumento = await dbContext.Documenti.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDocumento == null)
            {
                return null;
            }

            dbContext.Documenti.Remove(existingDocumento);
            await dbContext.SaveChangesAsync();
            return existingDocumento;
        }

        public async Task<List<Documento>> GetAllAsync()
        {
            return await dbContext.Documenti.Include(x => x.Categoria).Include(x => x.Marchio).Include(x => x.Tipologia).Include(x=> x.Stato).ToListAsync();
            //return await dbContext.Documenti.Include("Categoria").Include("Marchio").Include("Tipologia").Include("Stato").ToListAsync();
        }

        public async Task<Documento> GetByIdAsync(Guid id)
        {
            return await dbContext.Documenti.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Documento> UpdateAsync(Guid id, Documento documento)
        {
            var existingDocumento = await dbContext.Documenti.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDocumento == null)
            {
                return null;
            }

            existingDocumento.AnnoDiRilascio = documento.AnnoDiRilascio;
            existingDocumento.StatoId = documento.StatoId;
            existingDocumento.Link = documento.Link;
            existingDocumento.Title = documento.Title;
            existingDocumento.Icona = documento.Icona;
            existingDocumento.CategoriaId = documento.CategoriaId;
            existingDocumento.MarchioId = documento.MarchioId;
            existingDocumento.TipologiaId = documento.TipologiaId;

            await dbContext.SaveChangesAsync();
            return existingDocumento;
        }
    }
}
