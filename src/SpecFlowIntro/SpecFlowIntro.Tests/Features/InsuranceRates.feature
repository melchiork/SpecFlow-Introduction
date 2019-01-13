Feature: Insurance Rates
	In order to know what can be offered to a client
	As an agent
	I'd like to be albe to calculate insurance rate

@LifeInsurance
Scenario Outline: Calculate life rates
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
		| Gender   | Age   | Health Rate  | Education   | Rate   |
		| <Gender> | <Age> | <HealthRate> | <Education> | <Rate> |
	Then the life insurance calculation is as follows
		| Name   | Yearly           | Monthly          |
		| <Rate> | <ExpectedYearly> | <ExpectedMontly> |

Examples: 
	| Gender | Age | Health Rate | Education | Rate     | ExpectedYearly | ExpectedMontly |
	| Male   | 32  | A           | Higher    | Premium  | 225            | 20.62          |
	| Female | 32  | A           | Higher    | Premium  | 230            | 21.08          |
	| Female | 32  | A           | Higher    | Standard | 80             | 7.33           |
	| Female | 52  | C           | Higher    | Premium  | 198            | 18.15          |