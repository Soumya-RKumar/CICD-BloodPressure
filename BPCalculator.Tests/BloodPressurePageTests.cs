using BPCalculator.Pages;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BPCalculator.Tests;

public class BloodPressurePageTests
{
    [Fact]
    public void OnPost_WhenSystolicIsLessThanDiastolic_ShouldAddModelError()
    {
        // Arrange
        var pageModel = new BloodPressureModel
        {
            BP = new BloodPressure
            {
                Systolic = 80,
                Diastolic = 100
            }
        };

        // Act
        var result = pageModel.OnPost();

        // Assert
        Assert.False(pageModel.ModelState.IsValid);
        Assert.IsType<PageResult>(result);
    }

    [Fact]
    public void OnPost_WhenSystolicIsGreaterThanDiastolic_ShouldBeValid()
    {
        // Arrange
        var pageModel = new BloodPressureModel
        {
            BP = new BloodPressure
            {
                Systolic = 120,
                Diastolic = 80
            }
        };

        // Act
        var result = pageModel.OnPost();

        // Assert
        Assert.True(pageModel.ModelState.IsValid);
        Assert.IsType<PageResult>(result);
    }

    [Fact]
    public void OnPost_WhenSystolicEqualsDiastolic_ShouldAddModelError()
    {
        // Arrange
        var pageModel = new BloodPressureModel
        {
            BP = new BloodPressure
            {
                Systolic = 100,
                Diastolic = 100
            }
        };
        // Act
        var result = pageModel.OnPost();

        // Assert
        Assert.False(pageModel.ModelState.IsValid);
        Assert.IsType<PageResult>(result);
    }

    [Fact]
    public void OnGet_ShouldSetDefaultBloodPressureValues()
    {
        // Arrange
        var pageModel = new BloodPressureModel();

        // Act
        pageModel.OnGet();

        // Assert
        Assert.Equal(100, pageModel.BP.Systolic);
        Assert.Equal(60, pageModel.BP.Diastolic);
    }
}