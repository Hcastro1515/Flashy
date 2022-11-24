using Flashy.Shared.Entities;

namespace Flashy.Client.Services.FlashcardService
{
    public interface IFlashcardService
    {
        List<Flashcard> Flashcards { get; set; }
        Task GetFlashcards(); 
        Task<Flashcard> GetFlashcardById(int id); 
        Task CreateFlashCard(Flashcard card); 
        Task RemoveFlashcardById(int id); 
        Task RemoveAllFlashcards(); 
        Task UpdateFlashcard(FlashcardService card); 

    }
}
