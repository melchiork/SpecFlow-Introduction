Feature: Basics
	In order to know what can be insured
	As an agent
	I'd like to list all insurance types

Scenario: All insurance types
	Given I am logged in as John
	When I list all insurance types
	Then insurance types are as follows
	 | Name     |
	 | Mortgage |
	 | Life     |
	 | Property |
	 | Health   |

@Ignore
Scenario: All insurance claims
	Given I am logged in as John
	When I list all insurance claims for client Bob
	Then insurance claims are as follows
	 | Date       | Type     | Amount |
	 | 2018-10-10 | Property | 670    |