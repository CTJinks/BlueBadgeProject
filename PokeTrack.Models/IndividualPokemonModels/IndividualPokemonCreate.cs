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
        public string PokemonName { get; set; }
        [Required]
        public string PokemonType { get; set; }
        [Required]
        public string DietType { get; set; }
        [Required]
        public List<Move> Moves { get; set; }
    }
}
