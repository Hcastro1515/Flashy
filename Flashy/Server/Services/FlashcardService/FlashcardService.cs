using Flashy.Server.Data;
using Flashy.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flashy.Server.Services.FlashcardService
{
    public class FlashcardService : IFlashcardService
    {
        private readonly DataContext context; 
        public FlashcardService(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Flashcard>?> CreateFlashcard(Flashcard card)
        {
            try
            {
                if(card != null)
                {
                    card.Sets = null; 
                    await context.Flashcards.AddAsync(card);
                    await context.SaveChangesAsync();
                }else
                {
                    return new List<Flashcard>(); 
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message); 
                throw;
            }

            return await GetFlashcards(); 
        }

        public async Task<List<Flashcard>?> EditFlashcard(Flashcard card)
        {
            Flashcard? flashcard = await GetFlashcardById(card.FlashcardId); 
            try
            {
                if (flashcard != null)
                {

                    flashcard.Title = card.Title;
                    flashcard.Description = card.Description;
                    await context.AddAsync(flashcard);
                    await context.SaveChangesAsync();
                } 
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message); 
                throw;
            }
            return await GetFlashcards();
        }

        public async Task<Flashcard?> GetFlashcardById(int id)
        {
            return await context.Flashcards.FirstOrDefaultAsync(w => w.FlashcardId == id); 
        }

        public async Task<List<Flashcard>?> GetFlashcards()
        {
            return await context.Flashcards.ToListAsync();
        }

        public async Task<bool> RemoveAllFlashCards()
        {
            var isRemoved = false;

            try
            {
                List<Flashcard>? cards = await GetFlashcards(); 
                if(cards != null)
                {
                    context.Flashcards.RemoveRange(cards);
                    await context.SaveChangesAsync();
                    isRemoved = true;
                }else
                {
                    return isRemoved; 
                }

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message); 
            }
            
            return isRemoved;
        }

        public async Task<bool> RemoveFlashcardsById(int id)
        {
            var isRemoved = false;
            try
            {
                var card = await GetFlashcardById(id); 
                if(card != null)
                {
                    context.Flashcards.Remove(card); 
                    await context.SaveChangesAsync();
                    isRemoved = true; 
                }else
                {
                    return isRemoved; 
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message); 
            };

            return isRemoved;
        }
    }
}
