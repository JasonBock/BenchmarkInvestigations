using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace BenchmarkInvestigations.SupportingTypes
{
	public static class FibonacciTechniques
	{
		public static BigInteger CalculateViaList(BigInteger start)
		{
			if (start == BigInteger.Zero || start == BigInteger.One)
			{
				return start;
			}

			var numbers = new List<BigInteger> { BigInteger.Zero, BigInteger.One };

			var counter = 2;
			while (counter <= start)
			{
				numbers.Add(
				  numbers[counter - 2] +
				  numbers[counter - 1]);
				counter++;
			}

			return numbers.Last();
		}

		public static BigInteger CalculateViaRecursion(BigInteger start)
		{
			if (start == BigInteger.Zero || start == BigInteger.One)
			{
				return start;
			}

			return FibonacciTechniques.CalculateViaRecursion(start - BigInteger.One) + FibonacciTechniques.CalculateViaRecursion(start - 2);
		}

		public static BigInteger CalculateViaLocals(BigInteger start)
		{
			if (start == BigInteger.Zero || start == BigInteger.One)
			{
				return start;
			}

			var thirdNumber = BigInteger.Zero;
			var secondNumber = BigInteger.One;
			var firstNumber = BigInteger.Zero;

			var counter = 2;
			while (counter <= start)
			{
				firstNumber = thirdNumber + secondNumber;
				thirdNumber = secondNumber;
				secondNumber = firstNumber;
				counter++;
			}

			return firstNumber;
		}
	}
}