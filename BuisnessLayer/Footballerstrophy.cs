using System;
using System.Collections.Generic;

namespace DataLayer.BusinessLayer;

public partial class Footballerstrophy
{
    public int Id { get; set; }

    public int? FootballerId { get; set; }

    public int? TrophyId { get; set; }

    public virtual Footballer? Footballer { get; set; }

    public virtual Trophy? Trophy { get; set; }
}
