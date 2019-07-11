using StringCalculator;
using System;
using System.Threading.Tasks;
using Xunit;

namespace StringCalculatorUnitTests
{
	public class StringCalculatorTests
	{
		StringCalculator.StringCalculator StringCalculator = new StringCalculator.StringCalculator();

		[Fact]
		public void WhenMoreThan2NumbersAreUsedThenExceptionIsThrown( )
		{			
			Assert.Throws<InvalidArgumentException>( () => StringCalculator.Add("1,2,3"));
		}

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
	}
}
