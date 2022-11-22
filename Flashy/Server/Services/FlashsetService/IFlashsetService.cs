using Flashy.Shared.Entities;
using System.Runtime.CompilerServices;

namespace Flashy.Server.Services.FlashsetService
{
    public interface IFlashsetService
    {
        Task<List<Flashset>?> GetFlashSets();
        Task<Flashset?> GetFlashsetById(int id); 
        Task<List<Flashset>?> CreateFlashset(Flashset set);
        Task<List<Flashset>?> EditFlashSet(Flashset set);
        Task<Boolean> DeleteFlashsetById(int id); 
        Task<Boolean> DeleteAllFlashSets(); 
    }
}
