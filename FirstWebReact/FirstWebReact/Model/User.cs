using System;
using System.Collections.Generic;
using FirstWebReact.Model;
using Microsoft.EntityFrameworkCore;

namespace FirstWebReact.Model;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    public virtual ICollection<TransactionHistory> TransactionHistories { get; } = new List<TransactionHistory>();

    public virtual ICollection<Vipmembership> Vipmemberships { get; } = new List<Vipmembership>();
}

