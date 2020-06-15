using PokeTrack.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Models.UserModels
{
    public class UserCreate
    {
        [Required]
        public string UserName { get; set; }

        public string ApplicationUserID { get; set; }

    }
}
