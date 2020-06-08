using PokeTrack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models
{
    public class ChallengeRequestListItem
    {
        public int RequestID { get; set; }
        public string RequestUser { get; set; }
        public List<Pokemon> PokemonList { get; set; }
        public bool IsAccepted { get; set; }
        //DateTime ChallengeDate 
    }
}
