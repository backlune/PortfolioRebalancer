using NUnit.Framework;
using Shouldly;
using System;

namespace PortfolioRebalancer.Tests
{
    [TestFixture]
    public class PortfolioAssetTests
    {

        [TestCase("1", 1)]
        [TestCase("10", 10)]
        [TestCase("65.432", 65.432)]
        [TestCase("65,432", 65.432)]
        [TestCase("9 999", 9999)]
        public void CreateFromRawData_Units(string units, decimal expected)
        {
            var asset = PortfolioAsset.CreateFromRawData("iShares 20+ Year Treasury Bond ETF", units, "600 USD", "6617");
            asset.Units.ShouldBe(expected);
        }

        [TestCase("1 USD", 1, "USD")]
        [TestCase("10 EUR", 10, "EUR")]
        [TestCase("65.432 SEK", 65.432, "SEK")]
        [TestCase("65,432 USD", 65.432, "USD")]
        [TestCase("9 999 USD", 9999, "USD")]
        public void CreateFromRawData_UnitPrice(string unitPrice, decimal expected, string expectedCurrency)
        {
            var asset = PortfolioAsset.CreateFromRawData("iShares 20+ Year Treasury Bond ETF", "10", unitPrice, "6617");
            asset.UnitPrice.ShouldBe(expected);
            asset.Currency.ShouldBe(expectedCurrency);
        }

        [TestCase("1", 1)]
        [TestCase("10", 10)]
        [TestCase("65.432", 65.432)]
        [TestCase("65,432", 65.432)]
        [TestCase("9 999", 9999)]
        public void CreateFromRawData_ValueDomestic(string value, decimal expected)
        {
            var asset = PortfolioAsset.CreateFromRawData("iShares 20+ Year Treasury Bond ETF", "10", "600 USD", value);
            asset.ValueDomesticCurrency.ShouldBe(expected);
        }
    }
}
