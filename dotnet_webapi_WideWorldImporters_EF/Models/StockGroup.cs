using System;
using System.Collections.Generic;

namespace dotnet_webapi_WideWorldImporters_EF.Models;

public partial class StockGroup
{
    public int StockGroupId { get; set; }

    public string StockGroupName { get; set; } = null!;

    public int LastEditedBy { get; set; }

    public virtual Person LastEditedByNavigation { get; set; } = null!;

    public virtual ICollection<SpecialDeal> SpecialDeals { get; } = new List<SpecialDeal>();

    public virtual ICollection<StockItemStockGroup> StockItemStockGroups { get; } = new List<StockItemStockGroup>();
}
