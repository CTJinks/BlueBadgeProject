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
        
        [Required]
        public string IndividualPokemonName { get; set; }
        public int IndividualPokemonMovesID { get; set; }
        [Required]
        public int PokemonID { get; set; }
        [Required]
        public int UserID { get; set; }
        public int? TeamID { get; set; }

    }
}
