Feature: AboutGooglePage
	As a derp
	I want to load the 'About Google' page
	So that I can find out more information about Google

Scenario: Should load 'About Google' page
	When I load the "About Google" page
	Then I should see the "About Google" page

Scenario: Should have a mission statement headline 
	When I load the "About Google" page
	Then I should see the "Mission Statement Headline"