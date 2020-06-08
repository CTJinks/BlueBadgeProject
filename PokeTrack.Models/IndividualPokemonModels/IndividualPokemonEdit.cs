using PokeTrack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.IndividualPokemonModels
{
    class IndividualPokemonEdit
    {
        public int IndividualPokemonID { get; set; }
        public ICollection<Move> Moves { get; set; }
    }
}
