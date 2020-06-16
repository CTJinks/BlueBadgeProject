using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.IndividualPokemonMovesModels
{
    public class IndividualPokemonMovesCreate
    {
        public int MoveID { get; set; }

        public int IndividualPokemonID { get; set; }

    }
}
