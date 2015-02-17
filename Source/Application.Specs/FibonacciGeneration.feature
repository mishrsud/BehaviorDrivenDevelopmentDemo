Feature: Fibonacci Sequence Generation
	As an end user
	I want to be able to generate a Fibonacci Number based on the input index of the number in the sequence
	The sequence is intended to be bi-directional, both positive and negative

#This tag is scenario specific
@happyPathScenario 
Scenario Outline: Positive Fibonacci Series
	Given I have entered the number <num> into the generator
	When I execute the call to the generator
	Then the result should be <outnum>

Examples: 
	| num | outnum |
	| 0   | 0      |
	| 1   | 1      |
	| 2   | 1      |
	| 3   | 2      |

@happyPathScenario
Scenario Outline: Negative Fibonacci Series
	Given I have entered a negative number <negnum> into the generator
	When I execute the call to the generator for the negative number
	Then the result should be a negative <negoutnum>

Examples: 
	| negnum	| negoutnum  |
	| 0			| 0          |
	| -1		| -1         |
	| -2		| -1         |
	| -3		| -2         |

@positiveLimitScenario
Scenario: Positive series limit
	Given I have entered 92 into the generator
	When I call the generator
	Then the result is 7540113804746346429

@negativeLimitScenario
Scenario: Negative series Limit
	Given I enter -92 into the generator
	When I call the generator
	Then the result is equal to -7540113804746346429

@positiveLimitBreakingCase
Scenario: Positive Series breaks
	Given I enter a value greater than 92 e.g. 93
	When I make a call to the generator
	Then it throws an error saying the limit has been crossed