Feature: UC01_FilterProject
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: FilterProject
	Given user stay at main home
	When user choose into the location area
	When user choose into the type area
	When user choose into bedroom area
	When user choose into bathroom area
	Then user click Search
