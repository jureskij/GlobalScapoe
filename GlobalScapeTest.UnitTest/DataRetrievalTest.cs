using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlobalScape.Testing.Engine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalScapeTest.UnitTest
{
	[TestClass]
	public class DataRetrievalTests
	{
		[TestMethod]
		public void EngineReturnNumbers1To100()
		{

			// Arrange
			int expectedCount = 100;
			int lowerLimit = 1;
			int upperLimit = 100;
			DataEngine engine = new DataEngine();
			List<CalculatedNumber> numbers = new List<CalculatedNumber>();

			// Act

			numbers = engine.GetNumbers(lowerLimit, upperLimit);


			// Assert

			Assert.AreEqual(expectedCount, numbers.Count);
			Assert.AreEqual(expectedCount, numbers.Where(x => x.Value >= lowerLimit && x.Value <= upperLimit).Count());
		}

		[TestMethod]
		public void EngineReturnsNumbers1To100WhereDivisibleBy3IsAssociatedWithFizz()
		{

			//Arrange
			DataEngine engine = new DataEngine();
			List<CalculatedNumber> numbers = new List<CalculatedNumber>();
			int lowerLimit = 1;
			int upperLimit = 100;
			int operand = 3;
			string result = "fizz";
			CalculatorSpecification specification = new CalculatorSpecification(operand, result);

			List<CalculatedNumber> expectedResult = new List<CalculatedNumber>();

			for(int index = lowerLimit; index <= upperLimit; index++)
			{
				CalculatedNumber numb = new CalculatedNumber(index);
				numb.ApplyCalcuation(() =>{ return numb.Value % specification.Operand == 0; }, result);
				expectedResult.Add(numb);
			}

			//Act

			numbers = engine.GetCaluclation(lowerLimit, upperLimit, new List<CalculatorSpecification>() { specification });


			//Assert
			CollectionAssert.AreEqual(expectedResult, numbers);
		}

		[TestMethod]
		public void EngineReturnsNumbers1To100WhereDivisibleBy5IsAssociatedWithBuzz()
		{

			//Arrange
			DataEngine engine = new DataEngine();
			List<CalculatedNumber> numbers = new List<CalculatedNumber>();
			List<CalculatedNumber> filteredResults = new List<CalculatedNumber>();
			int lowerLimit = 1;
			int upperLimit = 100;
			int operand = 5;
			string result = "buzz";
			CalculatorSpecification specification = new CalculatorSpecification(operand, result);

			List<CalculatedNumber> expectedResult = new List<CalculatedNumber>();

			for (int index = lowerLimit; index <= upperLimit; index++)
			{
				CalculatedNumber numb = new CalculatedNumber(index);
				numb.ApplyCalcuation(() => { return numb.Value % specification.Operand == 0; }, result);
				expectedResult.Add(numb);
			}

			//Act
			
			numbers = engine.GetCaluclation(lowerLimit, upperLimit, new List<CalculatorSpecification>() { specification });

			//Assert
			CollectionAssert.AreEqual(expectedResult, numbers);
		}


		[TestMethod]
		public void MultipleCalucationSpecificationsReturnsCombinedResult()
		{
			//Arrange
			DataEngine engine = new DataEngine();
			List<CalculatedNumber> numbers = new List<CalculatedNumber>();
			List<CalculatedNumber> filteredResults = new List<CalculatedNumber>();
			int lowerLimit = 1;
			int upperLimit = 100;
			int operand1 = 3;
			int operand2 = 5;
			string result1 = "fizz";
			string result2 = "buzz";
			List<CalculatorSpecification> specifications = new List<CalculatorSpecification>()
			{
				new CalculatorSpecification(operand1, result1),
				new CalculatorSpecification(operand2, result2)
			};



		List<CalculatedNumber> expectedResult = new List<CalculatedNumber>();

			for (int index = lowerLimit; index <= upperLimit; index++)
			{
				CalculatedNumber numb = new CalculatedNumber(index);
				specifications.ForEach(x =>
				{
					numb.ApplyCalcuation(() => { return numb.Value % x.Operand == 0; }, x.ValueToApply);

				});
				expectedResult.Add(numb);
			}

			//Act

			numbers = engine.GetCaluclation(lowerLimit, upperLimit, specifications);

			//Assert
			CollectionAssert.AreEqual(expectedResult, numbers);
		}

		[TestMethod]
		public void GetReportReturnsUIFormattedResults()
		{
			//Arrange
			DataEngine engine = new DataEngine();
			string report = string.Empty;
			List<CalculatedNumber> filteredResults = new List<CalculatedNumber>();
			int lowerLimit = 1;
			int upperLimit = 100;
			int operand1 = 3;
			int operand2 = 5;
			string result1 = "fizz";
			string result2 = "buzz";
			StringBuilder expectedResultBuilder = new StringBuilder();
			List<CalculatorSpecification> specifications = new List<CalculatorSpecification>()
			{
				new CalculatorSpecification(operand1, result1),
				new CalculatorSpecification(operand2, result2)
			};



			List<CalculatedNumber> expectedResult = new List<CalculatedNumber>();

			for (int index = lowerLimit; index <= upperLimit; index++)
			{
				CalculatedNumber numb = new CalculatedNumber(index);
				specifications.ForEach(x =>
				{
					numb.ApplyCalcuation(() => { return numb.Value % x.Operand == 0; }, x.ValueToApply);

				});
				expectedResultBuilder.AppendLine(numb.ToString());
			}

			//Act

			report = engine.GetReport(lowerLimit, upperLimit, specifications);

			//Assert
			Assert.AreEqual(expectedResultBuilder.ToString(), report);
		}
	


	}
}
