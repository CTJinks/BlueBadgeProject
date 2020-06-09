using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Data
{
    public class ChallengeRequest
    {
        public int RequestID { get; set; }
        [ForeignKey("Team")]
        public int TeamID { get; set; }
        public virtual Team ChallengeTeam { get; set; }
        public string RequestUser { get; set; }
        public DateTime ChallengeDate { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
