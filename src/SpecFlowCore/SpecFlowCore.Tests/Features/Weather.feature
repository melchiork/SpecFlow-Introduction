Feature: Weather
	Weather should be reported


Scenario: Ask for certainty
	When I ask for certainty in '4' days
	Then the certainty is '70' %

@api
Scenario: Ask for the weather
	Given the location is 'Wroclaw'
	When I ask for the weather
	Then the result should be as follows
	| TemperatureC | Summary |
	| 26           | Hot     |
	| 27           | Hot     |
	| 28           | Hot     |

@api
Scenario: Ask for different weather
	Given the location is 'Arctic'
	When I ask for the weather
	Then the result should be as follows
	| TemperatureC | Summary  |
	| -12          | Freezing |
	| -14          | Freezing |
	| -16          | Freezing |