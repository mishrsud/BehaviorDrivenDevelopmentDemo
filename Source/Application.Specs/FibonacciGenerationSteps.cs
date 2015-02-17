using System;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Assert = NUnit.Framework.Assert;

namespace Application.Specs
{
	[Binding]
	public class FibonacciGenerationSteps
	{
		/// <summary>
		/// Step definition for the entry into postive series scenario.
		/// </summary>
		/// <remarks>Using the "Method name in underscores" style</remarks>
		[Given]
		public void Given_I_have_entered_the_number_INPUT_into_the_generator(int input)
		{
			ScenarioContext.Current.Add("index", input);
		}

		/// <summary>
		/// Step definition for the entry into negative series scenario.
		/// </summary>
		/// <remarks>Using the "Regular expression in attributes" style</remarks>
		[Given(@"I have entered a negative number (.*) into the generator")]
		public void GivenIHaveEnteredANegativeNumberIntoTheGenerator(int input)
		{
			ScenarioContext.Current.Add("index", input);
		}

		/// <summary>
		/// Step definition to call into the implementation and fetch the actial result for positive series
		/// </summary>
		[When]
		public void When_I_execute_the_call_to_the_generator()
		{
			int index = (int)ScenarioContext.Current["index"];
			var result = FibonacciGenerator.MathService.FibonacciNumber(index);
			ScenarioContext.Current.Add("result", result);
		}

		/// <summary>
		/// Step definition to call into the implementation and fetch the actial result for negative series
		/// </summary>
		[When(@"I execute the call to the generator for the negative number")]
		public void WhenIExecuteTheCallToTheGeneratorForTheNegativeNumber()
		{
			int index = (int)ScenarioContext.Current["index"];
			var result = FibonacciGenerator.MathService.FibonacciNumber(index);
			ScenarioContext.Current.Add("result", result);
		}

		/// <summary>
		/// Step Definition to verify the actual vs expected for a postive series.
		/// </summary>
		[Then]
		public void Then_the_result_should_be_OUTPUT(long output)
		{
			var result = (long)ScenarioContext.Current["result"];
			Assert.That(result, Is.EqualTo(output));
		}

		/// <summary>
		/// Step Definition to verify the actual vs expected for a negative series.
		/// </summary>
		/// <remarks>
		/// Uses Scoping to scenario so that correct output may be fetched. Notice step text is similar
		/// That's why scope is being used. Another way is to re-phrase the Then step.
		/// </remarks>
		[Then(@"the result should be a negative (.*)")]
		[Scope(Scenario = "Negative Fibonacci Series")]
		public void ThenTheResultWillBeANegative(long output)
		{
			var result = (long)ScenarioContext.Current["result"];
			Assert.That(result, Is.EqualTo(output));
		}
	}
}
