using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
	public class StringCalculator
	{
		public int Add( string numbersToAdd )
		{
			int total = 0;

			if ( string.IsNullOrEmpty( numbersToAdd) )
				return total;

			var stringList = numbersToAdd.Split(",").ToList();

			var intsToCalculate = getNumbersFromString( stringList );
			
			intsToCalculate.ForEach( x => total += x );

			return total;
		}

		private List<int> getNumbersFromString( List<string> stringList )
		{
			List<int> intList;

			try
			{
				intList =  stringList.Select( x => int.Parse(x)).ToList() ;
			}
			catch ( FormatException e )
			{
				throw new InvalidArgumentException( "Please don't try to add numbers that aren't actually numbers, mate.", e );
			}

			return intList;
		}
	}

	public class InvalidArgumentException : Exception
	{
		public InvalidArgumentException( string message ) : base( message )
		{

		}

		public InvalidArgumentException( string message, Exception innerException ) : base( message, innerException )
		{
		}
	}
}
