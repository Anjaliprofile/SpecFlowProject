Feature: ManageListing
	  As a Skill Trader
      I want to be able to edit, delete, view Services in Managelisting page 
      In order to managing ManageListing

@automation
Scenario:1.View Service in ManageListing
	Given Click on Manage Listings tab
	When I click on View icon
	Then Service details should be displayed

@automation
Scenario:2.Edit Service in ManageListing
	Given Click on Manage Listings tab
	When I click on edit icon and able to update all details
	Then Updated Service list should be displayed on managelisting page

@automation
Scenario:3.Delete Service in ManageListing
	Given Click on Manage Listings tab
	When I click on delete icon and able to delete service
	Then Popup message should be displayed
