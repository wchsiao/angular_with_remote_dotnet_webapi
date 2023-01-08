using System;
using System.Collections.Generic;

namespace dotnet_webapi_WideWorldImporters_EF.Models;

public partial class BuyingGroup
{
    public int BuyingGroupId { get; set; }

    public string BuyingGroupName { get; set; } = null!;

    public int LastEditedBy { get; set; }

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

    public virtual Person LastEditedByNavigation { get; set; } = null!;

    public virtual ICollection<SpecialDeal> SpecialDeals { get; } = new List<SpecialDeal>();
}
