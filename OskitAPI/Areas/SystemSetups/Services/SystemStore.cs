﻿using MacbooksAPI.Areas.SystemSetups.Services.SubStores;
using MacbooksAPI.Core.EFCore;
using MacbooksAPI.Data;

namespace MacbooksAPI.Areas.SystemSetups.Services
{
    public class SystemStore (
        AppDbContext? context,
        ILogger<DbStoreBase>? logger,
        ShippingTermStore? shippingTerms,
        ShippingMethodStore? shippingMethods,
        CountryStore? countries,
        CurrencyStore? currencies,
        DateFormatStore? dateFormats,
        SystemCompanyNumberStore? companyNumber,
        PaymentMethodStore? paymentMethods,
        PaymentTermStore? paymentTerms,
        ValueAddedTaxStore? valueAddedTax)
        : DbStoreBase(context, logger)
    {
        public readonly ShippingTermStore? ShippingTerms = shippingTerms;
        public readonly ShippingMethodStore? ShippingMethods = shippingMethods;
        public readonly CountryStore? Countries = countries;
        public readonly CurrencyStore? Currencies = currencies;
        public readonly DateFormatStore? DateFormats = dateFormats;
        public readonly SystemCompanyNumberStore? CompanyNumber = companyNumber;
        public readonly PaymentMethodStore? PaymentMethods = paymentMethods;
        public readonly PaymentTermStore? PaymentTerms = paymentTerms;
        public readonly ValueAddedTaxStore? ValueAddedTax = valueAddedTax;
    }
}
