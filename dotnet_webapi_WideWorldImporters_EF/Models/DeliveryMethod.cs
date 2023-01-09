using System;
using System.Collections.Generic;

namespace dotnet_webapi_WideWorldImporters_EF.Models;

public partial class DeliveryMethod
{
    public int DeliveryMethodId { get; set; }

    public string DeliveryMethodName { get; set; } = null!;

    public int LastEditedBy { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

    public virtual Person LastEditedByNavigation { get; set; } = null!;

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; } = new List<PurchaseOrder>();

    public virtual ICollection<Supplier> Suppliers { get; } = new List<Supplier>();
}
