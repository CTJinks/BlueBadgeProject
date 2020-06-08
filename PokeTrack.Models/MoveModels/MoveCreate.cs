using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.MoveModels
{
    public class MoveCreate
    {
        [Required]
        public string MoveName { get; set; }
        [Required]
        public int Damage { get; set; }
    }
}
