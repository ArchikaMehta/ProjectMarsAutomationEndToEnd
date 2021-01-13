Feature: ProfileCertifications
	In order for buyers to view my certifcations
	As a Skill Trader
	I want to be able to add, update, and delete certifications on my profile

Background: 
	Given I am on the application homepage
	And I am a registered user
	When I login

@mytag
Scenario: Adding certification with valid data
	Given I am on Certification tab
	When I save Certification as follows:
		| Name             | Organisation | Year |
		| Foundation Level | ISTQB        | 2020 |
	Then the success popup message "Foundation Level has been added to your certification" is displayed
	And my profile page displays the newly added Certification
