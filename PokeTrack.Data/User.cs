using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Data
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
        public ICollection<Team> Teams { get; set; } = new List<Team>();

            

        //need a property that holds a collection of our User's Teams
    }
}
