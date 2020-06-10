using PokeTrack.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.IndividualPokemonModels
{
    public class IndividualPokemonCreate 
    {
        
       // public int IndividualPokemonID { get; set; }
        [Required]
        public string IndividualPokemonName { get; set; }
        [Required]
        public int MoveID { get; set; }
        [Required]
        public int PokemonID { get; set; }
        [Required]
        public int UserID { get; set; }
        public int? TeamID { get; set; }
        public ICollection<IndividualPokemonMoves> IndividualPokemonMovesList { get; set; } = new List<IndividualPokemonMoves>();

        // public string MoveName { get; set; }

        // public List<IndividualPokemon> IndividualPokemonOfThisType { get; set; } 
    }
}
