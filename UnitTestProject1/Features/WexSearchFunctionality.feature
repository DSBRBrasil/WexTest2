Feature: WexSearchFunctionality
	The target of the test case it is to find a behavior unexpected 

@mytag2
Scenario: To write especial character
	Given I navigate to 'https://www.wexinc.com'
	And I write the sentence '/health'
	Then the result should be a list of topics about health

@mytag3
Scenario: To Find for a reduce costs 
	Given I navigate to 'https://www.wexinc.com'
	And I write the sentence 'reduce costs'
	Then the result should be a list of topics reduce costs
