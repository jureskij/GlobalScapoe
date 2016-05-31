using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlobalScape.Testing.Engine;

namespace GlobalScapeTest.UnitTest
{
	[TestClass]
	public class NumberTests
	{
		[TestMethod]
		public void InstanstiatingNumberRetainsPassedValue()
		{
			//Arrange
			int expectedValue = 1;
			int actualValue = 0;
			string actualResult = string.Empty;

			//Act
			CalculatedNumber number = new CalculatedNumber(expectedValue);
			actualValue = number.Value;
			actualResult = number.ToString();

			//Assert
			Assert.AreEqual(expectedValue, actualValue);
			Assert.AreEqual(expectedValue.ToString(), actualResult);
		}

		[TestMethod]
		public void ApplyingCalucationChangesToString()
		{
			//Arrange
			int expectedValue = 3;
			string expectedStringValue = "3, test";
            int actualValue = 0;
			string actualResult = string.Empty;

			CalculatorSpecification specification = new CalculatorSpecification(expectedValue, "test");

			//Act
			CalculatedNumber number = new CalculatedNumber(expectedValue);
			actualValue = number.Value;
			number.ApplyCalcuation(()=>
			{
				return number.Value % specification.Operand == 0;
			}, specification.ValueToApply);
			actualResult = number.ToString();

			//Assert
			Assert.AreEqual(expectedValue, actualValue);
			Assert.AreEqual(expectedStringValue, actualResult);
		}
	}
}
