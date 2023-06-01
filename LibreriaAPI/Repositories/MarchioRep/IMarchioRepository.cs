using LibreriaAPI.Models.Domain;

namespace LibreriaAPI.Repositories.MarchioRep
{
    public interface IMarchioRepository
    {
        // will be used by the controller cause I expose th interface(not the implementation) to the application
        Task<List<Marchio>> GetAllAsync();

        Task<Marchio?> GetByIdAsync(Guid id);

        Task<Marchio> CreateAsync(Marchio marchio);

        Task<Marchio> UpdateAsync(Guid id, Marchio marchio);

        Task<Marchio> DeleteAsync(Guid id);
    }
}
