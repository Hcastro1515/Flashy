using Flashy.Shared.Entities;

namespace Flashy.Server.Services.FlashcardService
{
    public class FlashcardService : IFlashcardService
    {
        public Task<List<Flashcard>> CreateFlashcard(Flashcard card)
        {
            throw new NotImplementedException();
        }

        public Task<List<Flashcard>> EditFlashcard(Flashcard card)
        {
            throw new NotImplementedException();
        }

        public Task<Flashcard> GetFlashcardById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Flashcard>> GetFlashcards()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAllFlashCards()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFlashcardsById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
