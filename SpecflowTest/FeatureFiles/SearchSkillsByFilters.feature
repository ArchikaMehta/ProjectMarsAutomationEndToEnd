Feature: SearchSkillsByFilters
	In order to narrow down skill search results 
	As a user
	I want to be able to filter search results by their location types

Background: 
	Given I am on the application homepage
	And I am a registered user
	When I login

@mytag
Scenario: Apply location filters on search results
	Given the skill search results for "Automation" are shown
	When I filter the results with "Online" location filter
	Then only the matching skills are displayed for location filter
