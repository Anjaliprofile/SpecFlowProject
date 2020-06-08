Feature: Profile
      As a Skill Trader
      I want to be able to Change password, Search Skills, select availability, availability hour and earn target
      In order to manage my Mars Portal

@automation
Scenario: I'd like to change password
	Given Click on Change Password button
    When  provide all details
	Then  password should be changed

Scenario: Update Description
	Given Click on Description icon 
	Then  Description should be updated

Scenario: Search Skills
	Given keys for searching
	When  Click on search button
	Then  Skills detail should be displayed

Scenario: Availability
	Given Click on Availability icon 
	Then  Select your availability

Scenario: AvailabilityHour
	Given Click on Availability Hour icon 
	Then  Select your availability Hour

Scenario: Earn Target
	Given Click on Earn Target icon 
	Then  Select your Earn Target




