Feature: HomePage
	As a derp
	I want to load the Google Search home page
	So that I can begin my search

Scenario: Should load home page
	When I load the "Home" page
	Then I should see the "Home" page
	And I should see the "Search Form"

Scenario: Should have an 'About Google' link
	Given I load the "Home" page
	When I click the "About Google Link"
	Then I should see the "About Google" page