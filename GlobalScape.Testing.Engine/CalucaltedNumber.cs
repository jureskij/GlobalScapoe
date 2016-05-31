using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalScape.Testing.Engine
{
	public class CalculatedNumber: IComparable
	{
		public int Value { get; private set; }

		private string result;

		/// <summary>
		/// Creates a new number for calculation
		/// </summary>
		/// <param name="number"></param>
		public CalculatedNumber(int number)
		{
			Value = number;
			result = number.ToString();
		}

		public override string ToString()
		{
			return result.ToString();
		}

		/// <summary>
		/// Applies result to object if IsPositiveResult returns true
		/// </summary>
		/// <param name="IsPositiveResult">Contains the logic to determine if result should be applied</param>
		/// <param name="toPrint">Accessible through ToString</param>
		public void ApplyCalcuation(Func<bool> IsPositiveResult, string toPrint)
		{
			if (IsPositiveResult.Invoke())
			{
				result = String.Format("{0}, {1}", result, toPrint);
			}
		}

		public int CompareTo(object obj)
		{
			if (obj is CalculatedNumber)
			{
				CalculatedNumber testObj = (CalculatedNumber)obj;

				if (testObj.Value.Equals(Value) && testObj.ToString().Equals(ToString()))
				{
					return 1;
				}

			}
			return 0;
		}

		public override bool Equals(object obj)
		{
			return CompareTo(obj).Equals(1);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
