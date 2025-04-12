using BusinessLayer;
using System;
using System.Collections.Generic;

namespace BuisnessLayer;
<<<<<<< HEAD
    public class Country
=======
<<<<<<< HEAD
    public partial class Country
>>>>>>> 8b23668 (Our version of Business Layer classes)
    {
        public string CountryCode { get; set; } = null!;
=======
>>>>>>> fc9834e (Removed unnessecary folder)

        public string CountryName { get; set; } = null!;

        public string ContinentCode { get; set; } = null!;

        public virtual Continent ContinentCodeNavigation { get; set; } = null!;

        public virtual ICollection<Footballer> Footballers { get; set; } = new List<Footballer>();

        public virtual ICollection<Stadium> Stadium { get; set; } = new List<Stadium>();

        public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

        public virtual ICollection<Trophy> Trophies { get; set; } = new List<Trophy>();
    }