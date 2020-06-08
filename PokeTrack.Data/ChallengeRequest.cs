using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Data
{
    public class ChallengeRequest
    {
        public int RequestID { get; set; }

        public string RequestUser { get; set; }

        public List<Pokemon> PokemonList { get; set; }

        public bool IsAccepted { get; set; }

        public DateTime CreChallengeDate { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
