using PokeTrack.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models
{
    public class UserListItem
    {
        public int UserID { get; set; }

        [Display(Name = "Trainer")]
        public string UserName { get; set; }

        //public List<Pokemon> PokemonList { get; set; }
        // public ChallengeRequest ChallengeRequest { get; set; } <--maybe stretch goal
       
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
     
    }
}
