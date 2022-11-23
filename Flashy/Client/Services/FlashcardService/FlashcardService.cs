using Flashy.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Flashy.Client.Services.FlashcardService
{
    public class FlashcardService : IFlashcardService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public FlashcardService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Flashcard> Flashcards { get; set; } = new List<Flashcard>();

        public async Task GetFlashcards()
        {
            var result = await _http.GetFromJsonAsync<List<Flashcard>>("api/Flashcard/GetFlashCards");

            if (result != null)
                Flashcards = result; 
        }
    }
}
