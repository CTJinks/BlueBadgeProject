using PokeTrack.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.UserModels
{
    public class UserCreate
    {
        [Required]
        public string UserName { get; set; }
        
        //[Required]
        //[Range(1, 6)]//this may not be the right way to do this
        //public List<Pokemon> PokemonList { get; set; }
        // public ChallengeRequest ChallengeRequest { get; set; } <-- maybe stretch goal
        // public int ChallengesAccepted { get; set; }
    }
}
