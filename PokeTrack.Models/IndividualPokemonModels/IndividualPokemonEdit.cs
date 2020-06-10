using PokeTrack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.IndividualPokemonModels
{
    public class IndividualPokemonEdit
    {
        public int IndividualPokemonID { get; set; }
        public string IndividualPokemonName { get; set; }
        public string TeamName { get; set; }
        public List<IndividualPokemonMoves> IndividualPokemonMovesList { get; set; }

    }
}
