Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowProject.Specs/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Add correct point of charge
	Given the identificator is 1234
	And the name is Electric Charge
	And the address is Rambla Wilson
	And the region is Este
	And the description is Full charge quickly
	When the create button is pressed
	Then the result should be Point of charge added

Scenario: Non numeric ID
	Given the identificator is ABCD
	And the name is Electric Charge
	And the address is Rambla Wilson
	And the region is Este
	And the description is Full charge quickly
	When the create button is pressed
	Then the result should be The id must be numeric

Scenario: Non existent region
	Given the identificator is 1234
	And the name is Electric Charge
	And the address is Rambla Wilson
	And the region is Litoral Oeste
	And the description is Full charge quickly
	When the create button is pressed
	Then the result should be Inexistent region

Scenario: Name greater than 20 characters
	Given the identificator is 1234
	And the name is High power electric charger 
	And the address is Rambla Wilson
	And the region is Este
	And the description is Full charge quickly
	When the create button is pressed
	Then the result should be Name must be shorter than 20 characters

Scenario: Description greater than 60 characters
	Given the identificator is 1234
	And the name is Electric Charge
	And the address is Rambla Wilson
	And the region is Este
	And the description is This high power electric charger is highly recommended. It will charge your car in just 1 hour and 30 minutes. It is also located in a region worth visiting
	When the create button is pressed
	Then the result should be Description must be shorter than 60 characters

Scenario: Address greater than 30 characters
	Given the identificator is 1234
	And the name is Electric Charge
	And the address is Advenir at University Park Apartments, 10495 SW 14th Ter, Miami, FL 33174
	And the region is Este
	And the description is Full charge quickly
	When the create button is pressed
	Then the result should be Address must be shorter than 30 characters

Scenario: Null field
	Given the identificator is 1234
	And the name is Electric Charge
	And the region is Este
	And the description is Full charge quickly
	When the create button is pressed
	Then the result should be Every field is mandatory

Scenario: Repeated ID
	Given the identificator is 1234
	And the name is Electric Charge
	And the address is Rambla Wilson
	And the region is Este
	And the description is Full charge quickly
	When the create button is pressed
	Then the result should be The ID already exists
