using BuisnessLayer;
using System;
using System.Collections.Generic;

<<<<<<< HEAD
namespace BuisnessLayer;
=======
namespace BusinessLayer;

>>>>>>> fc9834e (Removed unnessecary folder)
public partial class Continent
{
        public string ContinentCode { get; set; } = null!;

        public string ContinentName { get; set; } = null!;

        public virtual ICollection<Country> Countries { get; set; } = new List<Country>();

        public virtual ICollection<Trophy> Trophies { get; set; } = new List<Trophy>();
}
