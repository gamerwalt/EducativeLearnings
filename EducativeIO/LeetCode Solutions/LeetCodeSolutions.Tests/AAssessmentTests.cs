using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCodeSolutions.Tests
{
    [TestClass]
    public class AAssessmentTests
    {
        [TestMethod]
        public void AssessmentTest1()
        {
            var str = "-12";

            var result = AAssessment.StringToInteger(str);

            result.Should().Be(-12);
        }

        [TestMethod]
        public void AssessmentTest2()
        {
            var str = "+1";

            var result = AAssessment.StringToInteger(str);

            result.Should().Be(1);
        }

        [TestMethod]
        public void AssessmentTest3()
        {
            var str = "        -42";

            var result = AAssessment.StringToInteger(str);

            result.Should().Be(-42);
        }

        [TestMethod]
        public void AssessmentTest4()
        {
            var str = "00000-42a1234";

            var result = AAssessment.StringToInteger(str);

            result.Should().Be(0);
        }
    }
}
