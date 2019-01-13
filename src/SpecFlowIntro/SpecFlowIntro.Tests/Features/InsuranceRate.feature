Feature: Insurance Rate
	In order to know what can be offered to a client
	As an agent
	I'd like to be albe to calculate insurance rate

@LifeInsurance
Scenario: Calculate life rate
	Given following life expectancies exist
		| Gender | Expected Lifespan |
		| Male   | 75                |
		| Female | 82                |
	And following health rate expectancies exist
		| Health Rate | Expected Lifespan |
		| A           | 87                |
		| B           | 79                |
		| C           | 71                |
	When I submit following request for life insurance
		| Gender | Age | Health Rate | Education |
		| Male   | 33  | B           | Higher    |
	Then the life insurance calculation is as follows
		| Name     | Yearly | Monthly |
		| Standard | 73     | 6.69    |
		| Premium  | 223    | 20.44   |
	When I ask for discount for rate Premium for client Bob
	Then discount of 15% is returned
	When I ask for discount for rate Premium for client Owen
	Then discount of 8% is returned