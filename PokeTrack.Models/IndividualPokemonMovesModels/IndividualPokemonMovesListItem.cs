using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.IndividualPokemonMovesModels
{
    public class IndividualPokemonMovesListItem
    {
        public int IndividualPokemonMovesID { get; set; }
        public string MoveName { get; set; }
        public int Damage { get; set; }
        public string IndividualPokemonName { get; set; }
    }
}
