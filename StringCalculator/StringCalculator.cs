using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
	public class StringCalculator
	{
		public bool Add(string numbersToAdd )
		{
			var intsToCalculate = getNumbersFromString(numbersToAdd);
			
			if ( intsToCalculate.Count > 2 )
				throw new InvalidArgumentException("Please don't provide more than 2 numbers to add, mate.");

			return true;
		}

		private List<int> getNumbersFromString( string numberString )
		{
			var stringList = numberString.Split(",").ToList();

			List<int> intList;

			try
			{
				intList =  stringList.Select( x => int.Parse(x)).ToList();
			}
			catch ( Exception )
			{
				throw new InvalidArgumentException("Please don't try to add numbers that aren't actually numbers, mate.");
			}

			return intList;
		}
	}

	public class InvalidArgumentException : Exception
	{
		public InvalidArgumentException( string message ) : base( message )
		{

		}
	}
}
