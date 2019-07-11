using StringCalculator;
using System;
using System.Threading.Tasks;
using Xunit;

namespace StringCalculatorUnitTests
{
	public class StringCalculatorTests
	{
		StringCalculator.StringCalculator StringCalculator = new StringCalculator.StringCalculator();

		/*[Fact]
		public void WhenMoreThan2NumbersAreUsedThenExceptionIsThrown( )
		{			
			Assert.Throws<InvalidArgumentException>( () => StringCalculator.Add("1,2,3"));
		}*/

		[Fact]
		public void when2NumbersAreUsedThenNoExceptionIsThrown( )
		{			
			StringCalculator.Add("1,2");

			Assert.True(true);
		}

		[Fact]
		public void whenNonNumberIsUsedThenExceptionIsThrown( )
		{			
			Assert.Throws<InvalidArgumentException>( () => StringCalculator.Add("1,X"));
		}

		[Fact]
		public void whenEmptyStringIsUsedThenReturnValueIs0( )
		{
			var result = StringCalculator.Add("");
			Assert.Equal( 0, result );
		}

		[Fact]
		public void whenOneNumberIsUsedThenReturnValueIsThatSameNumber( )
		{
			var result = StringCalculator.Add("3");
			Assert.Equal( 3, result );
		}

		[Fact]
		public void whenTwoNumbersAreUsedThenReturnValueIsTheirSum( )
		{
			var result = StringCalculator.Add("3,6");
			Assert.Equal( 9, result );
		}

		[Fact]
		public void whenAnyNumberOfNumbersIsUsedThenReturnValuesAreTheirSums( )
		{
			var expectedInt = 3 + 6 + 15 + 18 + 46 + 33;
			var result = StringCalculator.Add("3,6,15,18,46,33");

			Assert.Equal( expectedInt, result );
		}

		[Fact]
		public void whenNewLineIsUsedBetweenNumbersThenReturnValuesAreTheirSums( )
		{
			var expectedInt = 3 + 6 + 15;
			var result = StringCalculator.Add("3,6\n15");

			Assert.Equal( expectedInt, result );
		}

		[Fact]
		public void whenDelimiterIsSpecifiedThenItIsUsedToSeparateNumbers( )
		{
			var expectedInt = 3 + 6 + 15;
			var result = StringCalculator.Add("//[;]\n3;6;15");

			Assert.Equal( expectedInt, result );
		}

		[Fact]
		public void whenNegativeNumberIsUsedThenRuntimeExceptionIsThrown( )
		{
			Assert.Throws<InvalidArgumentException>( () => StringCalculator.Add( "3,-6,15,18,46,33" ));
		}

		[Fact]
		public void whenNegativeNumbersAreUsedThenRuntimeExceptionIsThrown( )
		{
			Exception exception = null;

			try
			{
				StringCalculator.Add( "3,-6,15,-18,46,-33" );
			}
			catch ( InvalidArgumentException e )
			{
				exception = e;
			}
			
			Assert.NotNull( exception) ;
			Assert.Equal( "Come on, mate. You used [-6, -18, -33]. Negative numbers are NOT allowed.", exception.Message );

		}

		[Fact]
		public void whenOneOrMoreNumbersAreGreaterThan1000IsUsedThenItIsNotIncludedInSum( )
		{
			Assert.Equal( 3+1000+6, StringCalculator.Add( "3,1000,1001,6,1234" ));
		}

		[Fact]
		public void WhenADelimiterOfLengthGreaterIsSpecifiedThenItIsUsedToSeparateNumbers( )
		{
			Assert.Equal( 1+2+3 , StringCalculator.Add( "//[---]\n1---2---3" ));
		}
	}
}
