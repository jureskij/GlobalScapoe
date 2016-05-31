namespace GlobalScape.Testing.Engine
{
	public class CalculatorSpecification
	{
		public CalculatorSpecification(int operand, string result)
		{
			Operand = operand;
			ValueToApply = result;
		}

		public int Operand { get; private set; }
		public string ValueToApply { get; private set; }
	}
}