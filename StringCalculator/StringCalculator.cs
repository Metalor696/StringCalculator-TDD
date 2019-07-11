using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
	public class StringCalculator
	{
		public int Add( string numbersToAdd )
		{
			if ( string.IsNullOrEmpty( numbersToAdd) )
				return 0;

			var stringList = numbersToAdd.Split(",").ToList();

			var intsToCalculate = getNumbersFromString( stringList );
			
			if ( intsToCalculate.Count > 2 )
				throw new InvalidArgumentException( "Please don't provide more than 2 numbers to add, mate." );

			int total = 0;
			 
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
