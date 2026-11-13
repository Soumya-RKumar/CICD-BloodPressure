
using BPCalculator;
using Reqnroll;
using Xunit;

namespace BPCalculator.BDDTests.StepDefinitions
{
    [Binding]
    public class BloodPressureSteps
    {
        private int _systolic;
        private int _diastolic;
        private BPCategory _actualCategory;

        [Given("the systolic pressure is {int}")]
        public void GivenTheSystolicPressureIs(int systolic)
        {
            _systolic = systolic;
        }

        [Given("the diastolic pressure is {int}")]
        public void GivenTheDiastolicPressureIs(int diastolic)
        {
            _diastolic = diastolic;
        }

        [When("the blood pressure category is calculated")]
        public void WhenTheBloodPressureCategoryIsCalculated()
        {
            var bloodPressure = new BloodPressure
            {
                Systolic = _systolic,
                Diastolic = _diastolic
            };

            _actualCategory = bloodPressure.Category;
        }

        [Then("the category should be {word}")]
        public void ThenTheCategoryShouldBe(string expectedCategory)
        {
            var expected = Enum.Parse<BPCategory>(expectedCategory);

            Assert.Equal(expected, _actualCategory);
        }
    }
}
