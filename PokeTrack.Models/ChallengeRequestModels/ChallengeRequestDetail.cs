using PokeTrack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.ChallengeRequestModels
{
    public class ChallengeRequestDetail
    {
        public int RequestID { get; set; }
        public string TeamName { get; set; }
        public List<IndividualPokemon> PokemonTeam { get; set; }
        public DateTime ChallengeDate { get; set; }
    }
}
