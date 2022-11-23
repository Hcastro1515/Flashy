using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Flashy.Shared.Entities
{
    public class Flashcard
    {
        public int FlashcardId { get; set; }
        [Required]
        public string? Title { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        [JsonIgnore]
        public List<Flashset>? Sets { get; set; }

    }
}
