using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalScape.Testing.Engine;

namespace GlobalScapeTest
{
	class Program
	{
		static void Main(string[] args)
		{
			DataEngine engine = new DataEngine();
			Console.Write(engine.GetReport(1, 100, new List<CalculatorSpecification>()
			{
				new CalculatorSpecification(3, "fizz"),
				new CalculatorSpecification(5, "buzz")
			}));
			Console.Read();
		}
	}
}
