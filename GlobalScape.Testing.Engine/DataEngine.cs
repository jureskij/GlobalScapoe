using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalScape.Testing.Engine
{
	public class DataEngine
	{

		public List<CalculatedNumber> GetNumbers(int inclusiveLowerLimit, int inclusiveUpperLimit)
		{
            List<CalculatedNumber> numbers = new List<CalculatedNumber>();

			for (int index = inclusiveLowerLimit; index <= inclusiveUpperLimit; index++)
			{
				numbers.Add(new CalculatedNumber(index));
			}

			return numbers;
		}


		public List<CalculatedNumber> GetCaluclation(int lowerLimit, int upperLimit, List<CalculatorSpecification> specifications)
		{
			List<CalculatedNumber> numbers = GetNumbers(lowerLimit, upperLimit);

			numbers.ForEach(x =>
			{
				specifications.ForEach(specification =>
				{
					x.ApplyCalcuation(() => { return x.Value % specification.Operand == 0; }, specification.ValueToApply);
				});
			});

			return numbers;
		}

		public string GetReport(int lowerLimit, int upperLimit, List<CalculatorSpecification> specifications)
		{
			List<CalculatedNumber> numbers = GetCaluclation(lowerLimit, upperLimit, specifications);
			StringBuilder reportBuilder = new StringBuilder();
			numbers.ForEach(x => reportBuilder.AppendLine(x.ToString()));
			return reportBuilder.ToString();
		
        }
	}
}
