Feature: Weather
	I order to know how to dress
	As a user
	I'd like to know what the weather will be in a place I plan to go to

@api
Scenario: Ask for the weather
	Given the location is 'Wroclaw'
	When I ask for the weather
	Then the result should be as follows
	| TemperatureC | Summary |
	| 26           | Hot     |
	| 27           | Hot     |
	| 28           | Hot     |

Scenario: Ask for different weather
	Given the location is 'Arctic'
	When I ask for the weather
	Then the result should be as follows
	| TemperatureC | Summary  |
	| -12          | Freezing |
	| -14          | Freezing |
	| -16          | Freezing |

@api
Scenario: Ask for certainty
	When I ask for certainty in '4' days
	Then the certainty is '70'%