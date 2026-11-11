namespace BPCalculator.Tests;

public class BloodPressureTests
{
    [Theory]
    [InlineData(85, 50, BPCategory.Low)]
    [InlineData(100, 60, BPCategory.Ideal)]
    [InlineData(120, 75, BPCategory.PreHigh)]
    [InlineData(110, 85, BPCategory.PreHigh)]
    [InlineData(135, 92, BPCategory.High)]
    [InlineData(139, 89, BPCategory.PreHigh)]
    [InlineData(140, 80, BPCategory.High)]
    [InlineData(139, 90, BPCategory.High)]
    [InlineData(89, 50, BPCategory.Low)]
    [InlineData(90, 50, BPCategory.Ideal)]
    [InlineData(119, 70, BPCategory.Ideal)]
    [InlineData(120, 70, BPCategory.PreHigh)]
    [InlineData(139, 80, BPCategory.PreHigh)]
    [InlineData(85, 59, BPCategory.Low)]
    [InlineData(85, 60, BPCategory.Ideal)]
    [InlineData(100, 79, BPCategory.Ideal)]
    [InlineData(100, 80, BPCategory.PreHigh)]
    [InlineData(100, 89, BPCategory.PreHigh)]
    [InlineData(100, 90, BPCategory.High)]
    public void Category_ShouldReturnExpectedResult(
        int systolic,
        int diastolic,
        BPCategory expectedCategory)
    {
        // Arrange
        var bp = new BloodPressure
        {
            Systolic = systolic,
            Diastolic = diastolic
        };

        // Act
        var actualCategory = bp.Category;

        // Assert
        Assert.Equal(expectedCategory, actualCategory);
    }
}