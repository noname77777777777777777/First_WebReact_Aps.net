using System;
using System.Collections.Generic;

namespace FirstWebReact.Model;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? UserId { get; set; }

    public string CreditCardNumber { get; set; } = null!;

    public string CardHolderName { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }

    public string Cvv { get; set; } = null!;

    public virtual User? User { get; set; }
}
