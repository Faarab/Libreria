using LibreriaAPI.Models.Domain;

namespace LibreriaAPI.Repositories
{
    public interface ICategoriaRepository
    {
        Task<List<Categoria>> GetAllAsync();
        Task<Categoria> GetByIdAsync(Guid id);
        Task<Categoria> CreateAsync(Categoria categoria);
        Task<Categoria> UpdateAsync(Guid id, Categoria categoria);
        Task<Categoria> DeleteAsync(Guid id);
    }
}
