using PokeTrack.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.ChallengeRequestModels
{
    public class ChallengeRequestCreate
    {
        [Required]
        public string RequestUser { get; set; }
        [Required]
        public List<Pokemon> PokemonList { get; set; }
        //public bool IsAccepted?
    }
}
