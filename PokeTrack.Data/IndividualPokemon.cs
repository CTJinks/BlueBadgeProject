﻿using System;
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

        [Required]
        public string IndividualPokemonName { get; set; }

        public ICollection<IndividualPokemonMoves> MovesJoiningTable { get; set; }

        [ForeignKey("UserName")]
        public int UserID { get; set; }
        public virtual User UserName { get; set; }

        [ForeignKey("Pokemon")]
        public int PokemonID { get; set; }
        public virtual Pokemon Pokemon { get; set; }

        [ForeignKey("Team")]
        public int? TeamID { get; set; }
        public virtual Team Team { get; set; }

    }
}
