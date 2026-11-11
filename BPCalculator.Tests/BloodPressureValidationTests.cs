using System.ComponentModel.DataAnnotations;

namespace BPCalculator.Tests;

public class BloodPressureValidationTests
{
    [Theory]
    [InlineData(200, 80, false)]
    [InlineData(69, 60, false)]
    [InlineData(120, 101, false)]
    [InlineData(120, 39, false)]
    [InlineData(70, 40, true)]
    [InlineData(190, 100, true)]
    public void BloodPressure_RangeValidation_ShouldReturnExpectedResult(
        int systolic,
        int diastolic,
        bool expectedIsValid)
    {
        // Arrange
        var bp = new BloodPressure
        {
            Systolic = systolic,
            Diastolic = diastolic
        };

        var context = new ValidationContext(bp);
        var results = new List<ValidationResult>();

        // Act
        bool isValid = Validator.TryValidateObject(
            bp,
            context,
            results,
            validateAllProperties: true);

        // Assert
        Assert.Equal(expectedIsValid, isValid);
    }
}