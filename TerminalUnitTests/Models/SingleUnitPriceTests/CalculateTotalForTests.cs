using Terminal.Models;

namespace TerminalUnitTests.Models.SingleUnitPriceTests;

public class CalculateTotalForTests
{
    [Theory]
    [InlineData(1, 1, 1)]
    [InlineData(1, 35, 35)]
    [InlineData(3, 1, 3)]
    [InlineData(3, 3, 9)]
    [InlineData(3, 12, 36)]
    [InlineData(1.05, 2, 2.1)]
    public void ReturnsExpectedTotalPrice(
        decimal pricePerUnit,
        int unitQuantity,
        decimal expectedTotal
    )
    {
        // Arrange
        var price = SingleUnitPrice.Create("_", pricePerUnit);

        // Act
        var actualTotal = price.CalculateTotalFor(unitQuantity);

        // Assert
        actualTotal.Should().Be(expectedTotal);
    }
}