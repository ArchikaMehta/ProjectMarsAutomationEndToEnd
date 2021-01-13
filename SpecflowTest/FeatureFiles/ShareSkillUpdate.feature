Feature: ShareSkillUpdate
	In order for buyers to to view the updated information of my listings
	As a Skill Trader
	I want to be able to update skills that I have shared

Background: 
	Given I am on the application homepage
	And I am a registered user
	When I login

@mytag
Scenario: Update listed skill information
	Given I am on Listing Management page
	When I update my "Selenium" listing 
	Then "Selenium" is updated successfully 
	