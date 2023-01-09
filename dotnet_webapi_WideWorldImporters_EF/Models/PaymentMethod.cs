using System;
using System.Collections.Generic;

namespace dotnet_webapi_WideWorldImporters_EF.Models;

public partial class PaymentMethod
{
    public int PaymentMethodId { get; set; }

    public string PaymentMethodName { get; set; } = null!;

    public int LastEditedBy { get; set; }

    public virtual ICollection<CustomerTransaction> CustomerTransactions { get; } = new List<CustomerTransaction>();

    public virtual Person LastEditedByNavigation { get; set; } = null!;

    public virtual ICollection<SupplierTransaction> SupplierTransactions { get; } = new List<SupplierTransaction>();
}
