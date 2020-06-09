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
        
        public int IndividualPokemonID { get; set; }
        
        public string IndividualPokemonName { get; set; }

        
        public int PokemonID { get; set; }
       
        public string PokemonName { get; set; }
        
        public string PokemonType { get; set; }
       
        public string DietType { get; set; }

        public virtual List<Move> Moves { get; set; }

        // public List<IndividualPokemon> IndividualPokemonOfThisType { get; set; } 
       
        public DateTimeOffset CreatedUtc { get; set; }
        public string UserName { get; set; }

        // public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
