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
	}
}
