using Flashy.Shared.Entities;

namespace Flashy.Client.Services.FlashcardService
{
    public interface IFlashcardService
    {
        List<Flashcard> Flashcards { get; set; }
        Task GetFlashcards(); 
    }
}
