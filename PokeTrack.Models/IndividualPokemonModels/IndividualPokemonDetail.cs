using PokeTrack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.IndividualPokemonModels
{
    class IndividualPokemonDetail
    {
        public int IndividualPokemonID { get; set; }
        public string PokemonName { get; set; }
        public string PokemonType { get; set; }
        public string DietType { get; set; }
        public ICollection<Move> Moves { get; set; }
        public string UserName { get; set; }
    }
}
