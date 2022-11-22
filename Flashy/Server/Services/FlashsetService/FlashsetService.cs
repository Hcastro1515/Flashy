using Flashy.Shared.Entities;

namespace Flashy.Server.Services.FlashsetService
{
    public class FlashsetService : IFlashsetService
    {
        public Task<List<Flashset>> CreateFlashset(Flashset set)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAllFlashSets()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFlashsetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Flashset>> EditFlashSetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Flashset> GetFlashsetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Flashset>> GetFlashSets()
        {
            throw new NotImplementedException();
        }
    }
}
