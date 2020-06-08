Feature: ProfileLanguage
	  As a Skill Trader
      I want to be able to Add,update,Delete Languages 
      In order to update my profile details

@automation
Scenario:1.Add language
	Given I clicked on the Language tab under Profile page
	When  I add a new language
	Then  that language should be displayed on my listings

@automation
Scenario:2.Update language 
	Given I clicked on the Language tab under Profile page
	When I  update Language 
	Then that updated language should be displayed on my listings

@automation     
Scenario:3.Delete language 
	Given I clicked on the Language tab under Profile page
	When I delete language 
	Then that language should not be displayed on my listings