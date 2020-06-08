Feature: ProfileCertificate
	  As a Skill Trader
      I want to be able to Add,update,delete Certifications 
      In order to update my profile details

@automation
Scenario Outline:1.Add Certification
    Given I clicked on the Certifcation tabunder Profile page
	When i add new certification 
	Then i should see  the certification displayed on my listings   

@automation
Scenario Outline:2.Update Certification
    Given I clicked on the Certifcation tabunder Profile page
	When i update certification 
	Then i should see updated certification displayed on my listings 

@automation
Scenario Outline:3.Delete Certification
    Given I clicked on the Certifcation tabunder Profile page
	When i delete certification 
	Then i should not see the deleted certification displayed on my listings

		
