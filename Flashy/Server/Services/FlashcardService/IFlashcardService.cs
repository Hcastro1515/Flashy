using Flashy.Shared.Entities;

namespace Flashy.Server.Services.FlashcardService
{
    public interface IFlashcardService
    {
        Task<List<Flashcard>> GetFlashcards();
        Task<List<Flashcard>> CreateFlashcard(Flashcard card); 
        Task<Flashcard> GetFlashcardById(int id);
        Task<List<Flashcard>> EditFlashcard(Flashcard card);
        Task<Boolean> RemoveFlashcardsById(int id); 
        Task<Boolean> RemoveAllFlashCards(); 
    }
}
