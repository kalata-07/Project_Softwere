using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer;

public partial class Footballer
{
    [Key]
    public int Id { get; set; }

    public int? ShirtNumber { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? Age { get; set; }

    public int? TeamId { get; set; }

    public string TeamPosition { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal Salary { get; set; }

    public int? Trophies { get; set; }

    public bool? Captain { get; set; }

    public virtual Country? CountryCodeNavigation { get; set; }

    public virtual ICollection<Footballerstrophy> Footballerstrophies { get; set; } = new List<Footballerstrophy>();

    public virtual Team? Team { get; set; }
}
