Feature: ShareSkillAdd
	In order for buyers to view or purchase my services
	As a Skill Trader
	I want to be able to offer skills to others

Background: 
	Given I am on the application homepage
	And I am a registered user
	When I login

@mytag
Scenario: List a new skill for trade
	Given I open Share Skill page
	When I list my "Selenium" skill for trade
	Then "Selenium" is found in my managed listings 
