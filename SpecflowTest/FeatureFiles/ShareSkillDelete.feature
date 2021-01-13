Feature: ShareSkillDelete
	In order to retract services that I offer
	As a Skill Trader
	I want to be able to remove skills that I have shared

Background: 
	Given I am on the application homepage
	And I am a registered user
	When I login

@mytag
Scenario: Remove a skill from the listing
	Given I am on Listing Management page
	When I delete my "Selenium" listing
	Then "Selenium" is no longer found in my managed listings
