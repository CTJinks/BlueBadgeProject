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
        public string PokemonName { get; set; }
        [Required]
        public string PokemonType { get; set; }
        [Required]
        [Range(1, 4)]//this may not be the right way to do this
        public List<Move> MoveList { get; set; }
        [Required]
        public string DietType { get; set; }
    }
}
