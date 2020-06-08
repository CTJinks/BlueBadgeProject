﻿using PokeTrack.Data;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.IndividualPokemonModels
{
    public class IndividualPokemonListItem
    {
        public string PokemonName { get; set; }
        public string PokemonType { get; set; }
        public string DietType { get; set; }
        public ICollection<Move> Moves { get; set; }
    }
}