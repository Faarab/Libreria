using LibreriaAPI.Models.Domain;

namespace LibreriaAPI.Repositories.StatoRep
{
    public interface IStatoRepository
    {
        Task<List<Stato>> GetAllAsync();
        Task<Stato> GetByIdAsync(Guid guid);
        Task<Stato> CreateAsync(Stato stato);
        Task<Stato> UpdateAsync(Guid id, Stato stato);
        Task<Stato> DeleteAsync(Guid id);
    }
}
