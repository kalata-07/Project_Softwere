using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer;

public partial class Stadium
{

    
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Capacity { get; set; }

    public string CountryCode { get; set; } = null!;

    public string TownName { get; set; } = null!;

    public virtual Country CountryCodeNavigation { get; set; } = null!;
}
