using PokeTrack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.TeamModels
{
    public class TeamEdit
    {
        public int TeamID { get; set; }
        public List<IndividualPokemon> PokemonTeam { get; set; }
    }
}
