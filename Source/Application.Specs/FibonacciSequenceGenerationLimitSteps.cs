using System;
using NUnit.Core;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Assert = NUnit.Framework.Assert;

namespace Application.Specs
{
	[Binding]
	public class FibonacciSequenceGenerationLimitSteps
	{
		private int _input;
		private long _output;

		[Given(@"I have entered (.*) into the generator")]
		[Given(@"I enter (.*) into the generator")]
		[Given(@"I enter a value greater than 92 e.g. (.*)")]
		public void GivenIHaveEnteredIntoTheGenerator(int input)
		{
			_input = input;
		}

		[When(@"I call the generator")]
		public void WhenICallTheGenerator()
		{
			_output = FibonacciGenerator.MathService.FibonacciNumber(_input);
		}

		[Then(@"the result is (.*)")]
		public void ThenTheResultIs(long output)
		{
			Assert.That(_output, Is.EqualTo(output), "Unexpected output");
		}

		[Then(@"the result is equal to (.*)")]
		[Scope(Tag = "negativeLimitScenario")]
		public void ThenTheResultIsEqualTo(long output)
		{
			Assert.That(_output, Is.EqualTo(output), "Unexpected output");
		}

		[When(@"I make a call to the generator")]
		public void WhenIMakeACallToTheGenerator()
		{
			try
			{
				_output = FibonacciGenerator.MathService.FibonacciNumber(_input);
			}
			catch (ArgumentOutOfRangeException exception)
			{
				ScenarioContext.Current["Exception"] = exception;
			}
		}

		[Then(@"it throws an error saying the limit has been crossed")]
		public void ThenItThrowsAnErrorSayingTheLimitHasBeenCrossed()
		{
			var actualException = ScenarioContext.Current["Exception"];
			Assert.That(actualException, Is.AssignableTo<ArgumentOutOfRangeException>());
		}
	}
}
