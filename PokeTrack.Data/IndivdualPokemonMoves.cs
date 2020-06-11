using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Data
{
    public class IndividualPokemonMoves
    {
        [Key]
        public int IndividualPokemonMovesID { get; set; }

        [ForeignKey("Moves")]
        public int MoveID { get; set; }
        public virtual Move Move { get; set; }

        [ForeignKey("IndividualPokemon")]
        public int IndividualPokemonID { get; set; }
        public virtual IndividualPokemon IndividualPokemon { get; set; }
    }
}
