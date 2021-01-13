Feature: ChangePassword
	As a user
	I want to be able to change my password

Background: 
	Given I am on the application homepage
	And I am a registered user
	When I login

Scenario: Changing password to previous password is not allowed
	Given I navigate to "Change Password" page
	When I reuse my current password
	Then The error popup message "Current Password and New Password should not be same" is displayed and password is not saved
