using LibreriaAPI.Models.Domain;

namespace LibreriaAPI.Repositories
{
    public interface ITipologiaRepository
    {
        Task<List<Tipologia>> GetAllAsync();
        Task<Tipologia> GetByIdAsync(Guid id);
        Task<Tipologia> CreateAsync(Tipologia tipologia);
        Task<Tipologia> UpdateAsync(Guid id, Tipologia tipologia);
        Task<Tipologia> DeleteAsync(Guid id);
    }
}
