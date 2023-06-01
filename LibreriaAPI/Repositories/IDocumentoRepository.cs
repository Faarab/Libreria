using LibreriaAPI.Models.Domain;

namespace LibreriaAPI.Repositories
{
    public interface IDocumentoRepository
    {
        Task<Documento> CreateAsync(Documento documento);
        Task<Documento> UpdateAsync(Guid id, Documento documento);
        Task<Documento> DeleteAsync(Guid id);
        Task<List<Documento>> GetAllAsync();
        Task<Documento> GetByIdAsync(Guid id);

    }
}
