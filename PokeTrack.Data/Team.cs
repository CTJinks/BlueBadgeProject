using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Data
{
    public class Team
    {
        public int TeamID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("IndividualPokemon")]
        public int IndividualPokemonID { get; set; }
        public virtual IndividualPokemon IndividualPokemon { get; set; }

    }
}
