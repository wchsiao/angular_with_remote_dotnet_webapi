using System;
using System.Collections.Generic;

namespace dotnet_webapi_WideWorldImporters_EF.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string FullName { get; set; } = null!;

    public string PreferredName { get; set; } = null!;

    public string SearchName { get; set; } = null!;

    public bool IsPermittedToLogon { get; set; }

    public string? LogonName { get; set; }

    public bool IsExternalLogonProvider { get; set; }

    public byte[]? HashedPassword { get; set; }

    public bool IsSystemUser { get; set; }

    public bool IsEmployee { get; set; }

    public bool IsSalesperson { get; set; }

    public string? UserPreferences { get; set; }

    public string? PhoneNumber { get; set; }

    public string? FaxNumber { get; set; }

    public string? EmailAddress { get; set; }

    public byte[]? Photo { get; set; }

    public string? CustomFields { get; set; }

    public string? OtherLanguages { get; set; }

    public int LastEditedBy { get; set; }

    public virtual ICollection<BuyingGroup> BuyingGroups { get; } = new List<BuyingGroup>();

    public virtual ICollection<City> Cities { get; } = new List<City>();

    public virtual ICollection<Color> Colors { get; } = new List<Color>();

    public virtual ICollection<Country> Countries { get; } = new List<Country>();

    public virtual ICollection<Customer> CustomerAlternateContactPeople { get; } = new List<Customer>();

    public virtual ICollection<CustomerCategory> CustomerCategories { get; } = new List<CustomerCategory>();

    public virtual ICollection<Customer> CustomerLastEditedByNavigations { get; } = new List<Customer>();

    public virtual ICollection<Customer> CustomerPrimaryContactPeople { get; } = new List<Customer>();

    public virtual ICollection<CustomerTransaction> CustomerTransactions { get; } = new List<CustomerTransaction>();

    public virtual ICollection<DeliveryMethod> DeliveryMethods { get; } = new List<DeliveryMethod>();

    public virtual ICollection<Person> InverseLastEditedByNavigation { get; } = new List<Person>();

    public virtual ICollection<Invoice> InvoiceAccountsPeople { get; } = new List<Invoice>();

    public virtual ICollection<Invoice> InvoiceContactPeople { get; } = new List<Invoice>();

    public virtual ICollection<Invoice> InvoiceLastEditedByNavigations { get; } = new List<Invoice>();

    public virtual ICollection<InvoiceLine> InvoiceLines { get; } = new List<InvoiceLine>();

    public virtual ICollection<Invoice> InvoicePackedByPeople { get; } = new List<Invoice>();

    public virtual ICollection<Invoice> InvoiceSalespersonPeople { get; } = new List<Invoice>();

    public virtual Person LastEditedByNavigation { get; set; } = null!;

    public virtual ICollection<Order> OrderContactPeople { get; } = new List<Order>();

    public virtual ICollection<Order> OrderLastEditedByNavigations { get; } = new List<Order>();

    public virtual ICollection<OrderLine> OrderLines { get; } = new List<OrderLine>();

    public virtual ICollection<Order> OrderPickedByPeople { get; } = new List<Order>();

    public virtual ICollection<Order> OrderSalespersonPeople { get; } = new List<Order>();

    public virtual ICollection<PackageType> PackageTypes { get; } = new List<PackageType>();

    public virtual ICollection<PaymentMethod> PaymentMethods { get; } = new List<PaymentMethod>();

    public virtual ICollection<PurchaseOrder> PurchaseOrderContactPeople { get; } = new List<PurchaseOrder>();

    public virtual ICollection<PurchaseOrder> PurchaseOrderLastEditedByNavigations { get; } = new List<PurchaseOrder>();

    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; } = new List<PurchaseOrderLine>();

    public virtual ICollection<SpecialDeal> SpecialDeals { get; } = new List<SpecialDeal>();

    public virtual ICollection<StateProvince> StateProvinces { get; } = new List<StateProvince>();

    public virtual ICollection<StockGroup> StockGroups { get; } = new List<StockGroup>();

    public virtual ICollection<StockItemHolding> StockItemHoldings { get; } = new List<StockItemHolding>();

    public virtual ICollection<StockItemStockGroup> StockItemStockGroups { get; } = new List<StockItemStockGroup>();

    public virtual ICollection<StockItemTransaction> StockItemTransactions { get; } = new List<StockItemTransaction>();

    public virtual ICollection<StockItem> StockItems { get; } = new List<StockItem>();

    public virtual ICollection<Supplier> SupplierAlternateContactPeople { get; } = new List<Supplier>();

    public virtual ICollection<SupplierCategory> SupplierCategories { get; } = new List<SupplierCategory>();

    public virtual ICollection<Supplier> SupplierLastEditedByNavigations { get; } = new List<Supplier>();

    public virtual ICollection<Supplier> SupplierPrimaryContactPeople { get; } = new List<Supplier>();

    public virtual ICollection<SupplierTransaction> SupplierTransactions { get; } = new List<SupplierTransaction>();

    public virtual ICollection<SystemParameter> SystemParameters { get; } = new List<SystemParameter>();

    public virtual ICollection<TransactionType> TransactionTypes { get; } = new List<TransactionType>();
}
