using BusinessLayer;
using System;
using System.Collections.Generic;

namespace BuisnessLayer;

public partial class Trophy
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public string ContinentCode { get; set; } = null!;

    public int? Footballers { get; set; }

    public virtual Continent ContinentCodeNavigation { get; set; } = null!;

    public virtual Country CountryCodeNavigation { get; set; } = null!;

    public virtual ICollection<Footballerstrophy> Footballerstrophies { get; set; } = new List<Footballerstrophy>();
}
