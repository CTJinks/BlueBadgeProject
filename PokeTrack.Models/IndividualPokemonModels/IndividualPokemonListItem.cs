using PokeTrack.Data;
using PokeTrack.Models.PokemonModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.IndividualPokemonModels
{
    public class IndividualPokemonListItem
    {
        public int IndividualPokemonID { get; set; }
        public string IndividualPokemonName { get; set; }
        
        public string PokemonName { get; set; }
        public string PokemonType { get; set; }
        public string DietType { get; set; }

        // Come back later to address MovesJoiningTable
        public ICollection<IndividualPokemonMoves> MovesJoiningTable { get; set; } 
        public string UserName { get; set; }
    }
}
