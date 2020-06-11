using PokeTrack.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.PokemonModels
{
    public class PokemonCreate
    {
        [Required]
        public int PokemonID { get; set; }

        [Required]
        public string PokemonName { get; set; }
        [Required]
        public string PokemonType { get; set; }

        //[Required] 6/11 removed due postman error
        public List<IndividualPokemon> IndividualPokemonOfThisType { get; set; }
       
        [Required]
        public string DietType { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
