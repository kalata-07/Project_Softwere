using System;
using System.Collections.Generic;

namespace BuisnessLayer;

public partial class Team
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public string CoachName { get; set; } = null!;

    public string Colours { get; set; } = null!;

    public int? Founded { get; set; }

    public string TeamStadium { get; set; } = null!;

    public virtual Country CountryCodeNavigation { get; set; } = null!;

    public virtual ICollection<Footballer> Footballers { get; set; } = new List<Footballer>();
}
