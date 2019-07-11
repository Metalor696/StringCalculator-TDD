using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
	public class StringCalculator
	{
		public int Add( string userStringCommand )
		{
			int total = 0;

			if ( string.IsNullOrEmpty( userStringCommand ) )
				return total;

			var delimiterKey = "//";
			var delimiters = new List<string> { ",", "\n" };			

			string workingString = userStringCommand;			

			if ( userStringCommand.StartsWith( delimiterKey ) )
			{
				workingString = workingString.Remove( 0, 2 );
				var customDelimiters = getCustomDelimiters( workingString );
				delimiters.AddRange( customDelimiters );
				workingString = RemoveCustomDelimiters(customDelimiters, workingString);
			}

			var stringList = workingString.Split( delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries ).ToList( );

			var intsToCalculate = getNumbersFromString( stringList ).Where(x => x <= 1000 ).ToList();

			CheckCollectionIsPositive(intsToCalculate);
			
			intsToCalculate.ForEach( x => total += x );

			return total;
		}

		private void CheckCollectionIsPositive( List<int> numbers )
		{
			List<int> negativeInts = new List<int>();

			foreach(int number in numbers)
			{
				if ( number < 0 )
				{
					negativeInts.Add(number);
				}
			}

			if( negativeInts.Any() )
			{
				throw new InvalidArgumentException( $"Come on, mate. You used [{string.Join(", ", negativeInts.Select(x => x))}]. Negative numbers are NOT allowed.");
			}
		}

		private string RemoveCustomDelimiters(List<string> customDelimiters, string sourceString)
		{
			foreach( string delimiter in customDelimiters )
			{
				var delimiterKey = "[" + delimiter + "]";

				int index = sourceString.IndexOf(delimiterKey);
				sourceString = (index < 0)
    				? sourceString
    				: sourceString.Remove(index, delimiterKey.Length);
			}

			return sourceString;			
		}

		private List<string> getCustomDelimiters( string sourceString )
		{
			var customDelimiters = new List<string>(){ };
			var pattern = @"\[(.*?)\]";

			var matches = Regex.Matches(sourceString, pattern);

			foreach (var match in matches)
			{
				var delimiterValue = match.ToString().Replace("[", "").Replace("]","");
				customDelimiters.Add( delimiterValue );
			}			

			return customDelimiters;
		}

		private List<int> getNumbersFromString( List<string> stringList )
		{
			List<int> intList;

			try
			{
				intList =  stringList.Select( x => int.Parse(x)).ToList() ;
			}
			catch ( FormatException )
			{
				throw new InvalidArgumentException( "Please don't try to add numbers that aren't actually numbers, mate." );
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
