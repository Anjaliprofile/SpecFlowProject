Feature: ShareSkill
	  As a Skill Trader
      I want to be able to Add Skills 
      In order to Add and edit service through ShareSkill page

@automation
Scenario: I want to add Service
	Given Click on ShareSkill tab
	When  I provide all details of service and click on save button
	Then  Service list should be displayed on managelisting page
