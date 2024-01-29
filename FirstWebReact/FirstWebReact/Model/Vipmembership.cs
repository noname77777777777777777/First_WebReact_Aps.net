using System;
using System.Collections.Generic;

namespace FirstWebReact.Model;

public partial class Vipmembership
{
    public int MembershipId { get; set; }

    public int? UserId { get; set; }

    public string MembershipType { get; set; } = null!;

    public DateTime? ExpiryDate { get; set; }

    public string? MembershipDetails { get; set; }

    public virtual User? User { get; set; }
}
