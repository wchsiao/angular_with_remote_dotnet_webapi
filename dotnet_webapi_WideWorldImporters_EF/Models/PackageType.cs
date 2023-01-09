using System;
using System.Collections.Generic;

namespace dotnet_webapi_WideWorldImporters_EF.Models;

public partial class PackageType
{
    public int PackageTypeId { get; set; }

    public string PackageTypeName { get; set; } = null!;

    public int LastEditedBy { get; set; }

    public virtual ICollection<InvoiceLine> InvoiceLines { get; } = new List<InvoiceLine>();

    public virtual Person LastEditedByNavigation { get; set; } = null!;

    public virtual ICollection<OrderLine> OrderLines { get; } = new List<OrderLine>();

    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; } = new List<PurchaseOrderLine>();

    public virtual ICollection<StockItem> StockItemOuterPackages { get; } = new List<StockItem>();

    public virtual ICollection<StockItem> StockItemUnitPackages { get; } = new List<StockItem>();
}
