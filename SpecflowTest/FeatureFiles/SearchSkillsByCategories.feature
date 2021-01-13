Feature: SearchSkillsByCategories
	In order to find specific services 
	As a user
	I want to be able to use categories and subcateogries to filter search results

Background: 
	Given I am on the application homepage
	And I am a registered user
	When I login

@mytag
Scenario: Search skills using a specific category
	Given the skill search results for "Automation" are shown
	When I filter the results by category "Programming & Tech"
	Then only the matching skills are displayed