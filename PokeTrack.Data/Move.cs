using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Data
{
    public class Move
    {
        [Key]
        public int MoveID { get; set; }

        [Required]
        public string MoveName { get; set; }

        [Required]
        public int Damage { get; set; }

        /*public ICollection<IndividualPokemon> PokemonWithThisMove { get; set; } = new List<IndividualPokemon>();*/
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
