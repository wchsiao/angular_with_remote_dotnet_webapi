using System;
using System.Collections.Generic;

namespace dotnet_webapi_WideWorldImporters_EF.Models;

public partial class Color
{
    public int ColorId { get; set; }

    public string ColorName { get; set; } = null!;

    public int LastEditedBy { get; set; }

    public virtual Person LastEditedByNavigation { get; set; } = null!;

    public virtual ICollection<StockItem> StockItems { get; } = new List<StockItem>();
}
