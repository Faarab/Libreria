using LibreriaAPI.Data;
using LibreriaAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibreriaAPI.Repositories
{
    public class SQLCategoriaRepository : ICategoriaRepository
    {
        private readonly LibreriaDbContext dbContext;

        public SQLCategoriaRepository(LibreriaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Categoria> CreateAsync(Categoria categoria)
        {
            await dbContext.Categorie.AddAsync(categoria);
            await dbContext.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> DeleteAsync(Guid id)
        {
            var existingCategoria = await dbContext.Categorie.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCategoria == null)
            {
                return null;
            }
            dbContext.Categorie.Remove(existingCategoria);
            await dbContext.SaveChangesAsync();
            return existingCategoria;
        }

        public async Task<List<Categoria>> GetAllAsync()
        {
            return await dbContext.Categorie.ToListAsync();
        }

        public async Task<Categoria> GetByIdAsync(Guid id)
        {
            return await dbContext.Categorie.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Categoria> UpdateAsync(Guid id, Categoria categoria)
        {
            var existingCategorie = await dbContext.Categorie.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCategorie == null)
            {
                return null;
            }

            existingCategorie.Name = categoria.Name;
            existingCategorie.Code = categoria.Code;

            await dbContext.SaveChangesAsync();
            return existingCategorie;

        }
    }
}
