Feature: ChargingPoint
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowProject.Specs/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Add correct point of charge
	Given the identificator is 1234
	And the name is Electric Charge
	And the address is Rambla Wilson
	And the region is 1
	And the description is Full charge quickly
	When the create button is pressed
	Then the result should be Point of charge added

@mytag
Scenario: Non 4digits numeric identificator
	Given the identificator is 123
	And the name is Electric Charge
	And the address is Rambla Wilson
	And the region is 1
	And the description is Full charge quickly
	When the create button is pressed
	Then the result should be Charging point identificator must be 4 digits


@mytag
Scenario: Name greater than 20 characters
	Given the identificator is 1234
	And the name is High power electric charger 
	And the address is Rambla Wilson
	And the region is 1
	And the description is Full charge quickly
	When the create button is pressed
	Then the result should be Charging point name must be less than 20 letters and contain only alphabetical characters

@mytag
Scenario: Description greater than 60 characters
	Given the identificator is 1234
	And the name is Electric Charge
	And the address is Rambla Wilson
	And the region is 1
	And the description is This high power electric charger is highly recommended. It will charge your car in just 1 hour and 30 minutes. It is also located in a region worth visiting
	When the create button is pressed
	Then the result should be Charging point description must be less than 60 letters

@mytag
Scenario: Address greater than 30 characters
	Given the identificator is 1234
	And the name is Electric Charge
	And the address is Advenir at University Park Apartments, 10495 SW 14th Ter, Miami, FL 33174
	And the region is 1
	And the description is Full charge quickly
	When the create button is pressed
	Then the result should be Charging point address must be less than 20 letters and contain only alphabetical characters

@mytag
Scenario: Null field
	Given the identificator is 1234
	And the name is Electric Charge
	And the region is 1
	And the description is Full charge quickly
	When the create button is pressed
	Then the result should be All charging point fields are mandatory

