using System;
using System.Collections.Generic;

namespace FirstWebReact.Model;

public partial class TransactionHistory
{
    public int TransactionId { get; set; }

    public int? UserId { get; set; }

    public string TransactionType { get; set; } = null!;

    public byte[] TransactionDate { get; set; } = null!;

    public string? Details { get; set; }

    public virtual User? User { get; set; }
}
