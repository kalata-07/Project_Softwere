using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer;
    public partial class Country
{

        [Key]
        public string CountryCode { get; set; } = null!;

        public string CountryName { get; set; } = null!;


        public string ContinentCode { get; set; } = null!;

        public virtual Continent ContinentCodeNavigation { get; set; } = null!;

        public virtual ICollection<Footballer> Footballers { get; set; } = new List<Footballer>();

        public virtual ICollection<Stadium> Stadium { get; set; } = new List<Stadium>();

        public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

        public virtual ICollection<Trophy> Trophies { get; set; } = new List<Trophy>();
    }