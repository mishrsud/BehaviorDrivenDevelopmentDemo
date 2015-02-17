using System;

namespace FibonacciGenerator
{
	public class MathService
	{
		public static long FibonacciNumber(long n)
		{
			long firstNum = 0;
			long nextNum = 1;
			bool isNegativeSeries = n < 0;

			n = Math.Abs(n);

			if (n > 92)
				throw new ArgumentOutOfRangeException("n", "n>92 would cause airthmetic overflow exception");

			// In N steps compute Fibonacci sequence iteratively.
			for (int i = 0; i < n; i++)
			{
				long temp = firstNum;
				firstNum = nextNum;
				if (i == 92) break;
				nextNum = temp + nextNum;
			}

			return isNegativeSeries ? firstNum * -1 : firstNum;
		}
	}
}
