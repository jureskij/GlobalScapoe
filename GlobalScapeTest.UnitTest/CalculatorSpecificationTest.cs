using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlobalScape.Testing.Engine;

namespace GlobalScapeTest.UnitTest
{
	[TestClass]
	public class CalculatorSpecificationTest
	{
		[TestMethod]
		public void InstantiatingACalculatorSpecificationCausesObjecttToRetainValue()
		{
			//Arrange
			int expectedIntValue = 1;
			int actualIntValue = 0;
			string expectedStringValue = "MyValue";
			string actualStringValue = string.Empty;
			CalculatorSpecification specification = new CalculatorSpecification(expectedIntValue, expectedStringValue);

			//Act
			actualIntValue = specification.Operand;
			actualStringValue = specification.ValueToApply;

			//Assert

			Assert.AreEqual(expectedIntValue, actualIntValue);
			Assert.AreEqual(expectedStringValue, actualStringValue);
		
		}
	}
}
