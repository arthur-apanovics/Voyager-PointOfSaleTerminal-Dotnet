using System;
using Terminal.Models;
using TerminalUnitTests.Builders.Models;
using TerminalUnitTests.Builders.PricingStrategies;

namespace TerminalUnitTests.PricingStrategyTests.StandardPricingStrategyTests;

public class ConstructorTests
{
    [Fact]
    public void ThrowsWhenEmptyPricingProvided()
    {
        // Arrange
        var emptyPricing = Array.Empty<ProductPrice>();

        // Act
        var actual = () => StandardPricingStrategyBuilder.Build(
            withProductPricing: emptyPricing
        );

        // Assert
        actual.Should().ThrowExactly<ArgumentException>();
    }

    [Fact]
    public void ThrowsWhenDuplicateProductCodePresentInPricing()
    {
        // Arrange
        var pricingWithDuplicates = new[]
        {
            ProductPriceBuilder.Build(withCode: "A", withPrice: 1.25m),
            ProductPriceBuilder.Build(withCode: "B", withPrice: 4.25m),
            ProductPriceBuilder.Build(withCode: "B", withPrice: 1m)
        };

        // Act
        var actual = () => StandardPricingStrategyBuilder.Build(
            withProductPricing: pricingWithDuplicates
        );

        // Assert
        actual.Should().ThrowExactly<ArgumentException>();
    }
}