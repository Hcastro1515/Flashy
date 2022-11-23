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
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message); 
            }

            return await GetFlashcards(); 
        }

        public async Task<List<Flashcard>?> EditFlashcard(Flashcard card)
        {
            Flashcard? flashcard = await context.Flashcards.FirstOrDefaultAsync(f => f.Id == card.Id); 
            try
            {
                if (flashcard != null)
                {
                    flashcard.Title = card.Title;
                    flashcard.Description = card.Description;
                    await context.SaveChangesAsync();
                } 
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message); 
            }
            return await GetFlashcards();
        }

        public async Task<Flashcard?> GetFlashcardById(int id)
        {
            Flashcard? flashcard = await context.Flashcards.FirstOrDefaultAsync(f => f.Id == id); 

            if(flashcard == null) return null;

            return flashcard; 
        }

        public async Task<List<Flashcard>?> GetFlashcards()
        {
            return await context.Flashcards.Include(s => s.Sets).ToListAsync();
        }

        public async Task<bool> RemoveAllFlashCards()
        {
            bool isRemoved = false;

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
