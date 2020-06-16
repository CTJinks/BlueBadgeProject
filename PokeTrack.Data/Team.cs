using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Data
{// This object creates  Joining Table between User and Individual Pokemon, meaning that each entity of a Team will be a single Individual Pokemon paired with a User. For a Team of 6 pokemon, you will have 6 entities with different TeamIDs and one UserID
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public virtual ICollection<IndividualPokemon> PokemonTeam { get; set; }  = new List<IndividualPokemon>();

        // and maybe a second property to apply additional filters with
    }
}
