using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Flashy.Shared.Entities
{
    public class Flashset
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(255), MinLength(1)]
        public string? Term { get; set; }
        [Required, MaxLength(255), MinLength(1)]
        public string? Definition { get; set; }
        [ForeignKey("FlashcardId")]
        public int FlashcardId { get; set; }
        public Flashcard? Flashcard { get; set; }
    }
}