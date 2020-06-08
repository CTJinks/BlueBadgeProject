using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Data
{
    public class IndividualPokemon
    {
        [Key]
        public int IndividualPokemonID { get; set; }
        [ForeignKey("Pokemon")]
        public int PokemonID { get; set; }
        public virtual Pokemon Pokemon { get; set; }
        [ForeignKey("Move")]
        public int MoveID { get; set; }
        public virtual Move Move { get; set; }
        public ICollection<IndividualPokemon> PokemonTeam { get; set; } = new List<IndividualPokemon>();


    }
}
