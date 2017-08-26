
Feature: Person Creation
	In order to register a person details in the system
	User should be able to create and modify 
	an information about him/her

Scenario: Create a new person
	Given The system was launched
	And There is no any information about that person in the system
	When I fill the following mandatory fields: Name, Age
	And I fill the Address
	Then the system creates a new person 
	And saves an information about him/her as a first modification
	And displays Person Details information on the screen

Scenario: Enter an address of the person 
	Given I enter an address of the person (Scenarious: "Create a new person", "Modify the person")
	When I fill the following mandatory fields: House number
	And I fill necessary optional fields, possible optional fields: City, Street
	Then the system saves an address
	And displays it as an Address in Person Details information in a following format - <City>, <Street>, <House Number>

Scenario: Modify the person
	Given The system was launched
	And the person is created in the system
	And exists at least one modification of the person
	And any modification is displayed on the screen (we call it - the current modification)
	When I choose modify option 
	And I fill the following mandatory fields: Name, Age
	And I fill the Address 
	Then the system creates a new modification of the person
	And this modification is the next modification after the current modification
	And this modification is the last modification of the person
	And all modifications that were created before the new one and after the current one, have to be deleted 

Scenario: Exit from the application
	Given The system was launched
	And the person is created in the system
	When I choose exit option  
	Then the system closes the application  

Scenario: Choose Redo option
	Given The system was launched
	And the current (displayed) modification of the person is not a last one
	When I choose a Redo option
	Then the system displays the next modification for the current one

Scenario: Choose Undo option
	Given The system was launched
	And the current (displayed) modification of the person is not a first one
	When I choose an Undo option
	Then the system displays the previous modification for the current one
	
