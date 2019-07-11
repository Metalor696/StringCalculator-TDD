using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
	public class StringCalculator
	{
		public int Add( string userStringCommand )
		{
			int total = 0;

			var delimiterKey = "//";
			var delimiters = new List<char> { ',', '\n' };			

			string workingString = userStringCommand;

			if ( string.IsNullOrEmpty( userStringCommand ) )
				return total;

			if ( userStringCommand.StartsWith( delimiterKey ) )
			{
				workingString = workingString.Remove( 0, 2 );
				delimiters.AddRange( getCustomDelimiters( workingString ) );
			}

			var stringList = workingString.Split( delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries ).ToList( );

			Console.WriteLine("start");
			stringList.ForEach( x => Console.WriteLine(x));

			var intsToCalculate = getNumbersFromString( stringList );
			
			intsToCalculate.ForEach( x => total += x );

			return total;
		}

		private List<char> getCustomDelimiters( string workingString )
		{
			var customDelimiters = new List<char>(){ workingString.First() };

			return customDelimiters;
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
