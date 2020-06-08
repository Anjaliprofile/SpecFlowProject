Feature: ProfileEducation
	  As a Skill Trader
      I want to be able to Add,update,delete education 
      In order to update my profile details


@automation
Scenario Outline:1.Add Education
    Given I clicked on the Education tabunder Profile page
	When i add new education
	Then i should see the education displayed on my listings


@automation
Scenario Outline:2.Update Education
    Given I clicked on the Education tabunder Profile page
	When I update education 
	Then i should see the updated education displayed on my listings


@automation
Scenario Outline:3.Delete  Education
    Given I clicked on the Education tabunder Profile page
	When I delete Education
	Then i should not see deleted education displayed on my listings
