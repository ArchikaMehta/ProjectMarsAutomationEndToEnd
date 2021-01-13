Feature: ProfileLanguage
	In order for buyers to view my languages capabilities
	As a Skill Trader
	I want to be able to add, update, and delete my language capabilities on my profile

Background: 
	Given I am on the application homepage
	And I am a registered user
	When I login

@mytag
Scenario: Adding languages with valid data
	Given I am on Language tab 
	When I save Language as follows:
		| Name    | Level  |
		| English | Fluent |
	Then the success popup message "English has been added to your languages" is displayed 
	And my profile page displays the newly added Language

	