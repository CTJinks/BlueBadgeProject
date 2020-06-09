using PokeTrack.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models
{
    public class PokemonListItem
    {
        public int PokemonID { get; set; }
        public string PokemonName { get; set; }
        public string PokemonType { get; set; }
      
        // public List<Move> MoveList { get; set; }
        public string DietType { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
