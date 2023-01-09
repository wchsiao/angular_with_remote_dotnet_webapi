using System;
using System.Collections.Generic;

namespace dotnet_webapi_WideWorldImporters_EF.Models;

public partial class City
{
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public int StateProvinceId { get; set; }

    public long? LatestRecordedPopulation { get; set; }

    public int LastEditedBy { get; set; }

    public virtual ICollection<Customer> CustomerDeliveryCities { get; } = new List<Customer>();

    public virtual ICollection<Customer> CustomerPostalCities { get; } = new List<Customer>();

    public virtual Person LastEditedByNavigation { get; set; } = null!;

    public virtual StateProvince StateProvince { get; set; } = null!;

    public virtual ICollection<Supplier> SupplierDeliveryCities { get; } = new List<Supplier>();

    public virtual ICollection<Supplier> SupplierPostalCities { get; } = new List<Supplier>();

    public virtual ICollection<SystemParameter> SystemParameterDeliveryCities { get; } = new List<SystemParameter>();

    public virtual ICollection<SystemParameter> SystemParameterPostalCities { get; } = new List<SystemParameter>();
}
