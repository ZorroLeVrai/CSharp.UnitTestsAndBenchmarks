using Moq;
using NUnit.Framework;
using OperationFromJsonFile;

namespace OptimizationTestsUnitTests
{
    [TestFixture]
    public class OperationTests
    { 
        [Test]
        [TestCase("+", 1, 2, 3)]
        [TestCase("+", 1.5, 2.1, 3.6)]
        [TestCase("-", 3.6, 2.1, 1.5)]
        [TestCase("-", 2, 1, 1)]
        [TestCase("*", 2, 1, 2)]
        [TestCase("*", 2, 3, 6)]
        [TestCase("*", 1, 0, 0)]
        [TestCase("/", 1, 2, 0.5)]
        [TestCase("/", 2, 2, 1.0)]
        public void TestOperations(string op, double firstOperand, double secondOperand, double expectedResult) {
            var configReader = new Mock<IConfigurationReader>();
            configReader.Setup(cr => cr.Read()).Returns(new ComputationDto
            {
                Operator = op,
                FirstOperand = firstOperand,
                SecondOperand = secondOperand,
            });
        
            var computator = new Computator(configReader.Object);
            Assert.AreEqual(expectedResult, computator.Compute());
        }
    }
}
