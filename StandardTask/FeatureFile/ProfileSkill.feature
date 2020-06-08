Feature: ProfileSkill
	  As a Skill Trader
      I want to be able to Add,update,delete skills 
      In order to update my profile details

@automation
Scenario Outline:1.Add Skill 
    Given I clicked on the Skills tab under Profile page
	When I add new skill	
	Then i should see the skill displayed on my listings

@automation	
Scenario:2.Update Skill 
    Given I clicked on the Skills tab under Profile page
	When I update skill 
	Then i should see updated skill displayed on my listings

@automation
Scenario Outline:3.Delete Skill 
    Given I clicked on the Skills tab under Profile page
	When I delete skill 
	Then i should not see deleted skill displayed on my listings

