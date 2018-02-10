using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BKO.Web.Models
{
    public class Player
    {
            public int Id { get; set; }
            public string IdentityId { get; set; }
            public AppUser Identity { get; set; }  // navigation property
            public string Gender { get; set; }
    }
}
