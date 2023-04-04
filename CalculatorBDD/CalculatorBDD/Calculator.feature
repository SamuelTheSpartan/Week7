Feature: Calculator

As a Spartan, I want a calculator, so I can do maths

@Happy
Scenario: Addition
	Given I have a calculator
	And I enter 5 and 2 into the calculator
	When I press add
	Then the result should be 7

@Happy
Scenario: Subtract
	Given I have a calculator
	And I enter <input1> and <input2> into the calculator
	When I press subtract
	Then the result should be <result>
	Examples: 
	| input1 | input2 | result |
	| 1 | 1 | 0 |
	| 0 | 1 | -1 |
	| 1000 | 1 | 999 |

@Happy
Scenario: Multiply
	Given I have a calculator
	And I enter <input1> and <input2> into the calculator
	When I press multiply
	Then the result should be <result>
	Examples: 
	| input1 | input2 | result |
	| 1 | 1 | 1 |
	| 0 | 1 | 0 |
	| 1000 | 1 | 1000 |

@Happy
Scenario: Divide
	Given I have a calculator
	And I enter <input1> and <input2> into the calculator
	When I press divide
	Then the result should be <result>
	Examples: 
	| input1 | input2 | result |
	| 1 | 1 | 1 |
	| 0 | 1 | 0 |
	| 1000 | 2 | 500 |


@Sad
Scenario: DivideBy0
	Given I have a calculator
	And I enter <input1> and <input2> into the calculator
	When I press divide
	Then it should throw an exception
	Examples: 
	| input1 | input2 |
	| 1 | 0 |
	



	
	@HappyPath
Scenario: SumOfNumbersDivisibleBy2
Given I have a calculator
And I enter the numbers below to a list
| nums |
| 1    |
| 2    |
| 3    |
| 4    |
| 5    |
When I iterate through the list to add all the even numbers
Then the result should be 6