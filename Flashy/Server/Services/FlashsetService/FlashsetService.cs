using Flashy.Server.Data;
using Flashy.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flashy.Server.Services.FlashsetService
{
    public class FlashsetService : IFlashsetService
    {
        private readonly DataContext _context;

        public FlashsetService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Flashset>?> CreateFlashset(Flashset set)
        {
            try
            {
                if (set != null)
                {
                    await _context.Flashsets.AddAsync(set);
                    await _context.SaveChangesAsync();
                } else
                {
                    return new List<Flashset>();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw;
            }
            
            return await GetFlashSets();
        }

        public async Task<bool> DeleteAllFlashSets(int flashcardId)
        {
            bool isRemoved = false; 
            try
            {
                List<Flashset>? sets = await _context.Flashsets.Where(w => w.FlashcardId == flashcardId).ToListAsync(); 
                if (sets != null)
                {
                    _context.Flashsets.RemoveRange(sets);
                    await _context.SaveChangesAsync(); 
                    isRemoved = true;
                } else { return isRemoved; }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message); 
                throw;
            }
           
            return isRemoved;   
        }

        public async Task<bool> DeleteFlashsetById(int id)
        {

            bool isRemoved = false;
            try
            {
                var set = await GetFlashsetById(id);

                if (set != null)
                {
                    _context.Flashsets.Remove(set);
                    await _context.SaveChangesAsync();
                    isRemoved = true;
                } else
                {
                    return isRemoved; 
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message); 
                throw;
            }

            return isRemoved; 
        }

        public async Task<List<Flashset>?> EditFlashSet(Flashset set)
        {
            try
            {
                Flashset? flashset = await GetFlashsetById(set.Id);
                if (flashset != null)
                {
                    flashset.Term = set.Term;
                    flashset.Definition = set.Definition;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message); 
                throw;
            }
            return await GetFlashSets();
        }

        public async Task<Flashset?> GetFlashsetById(int id)
        {
            return await _context.Flashsets.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<List<Flashset>?> GetFlashSets()
        {
            return await _context.Flashsets.ToListAsync();
        }
    }
}
