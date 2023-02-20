Feature: Create User

Create user via Create user form and check that new user added to the table

@tag1
Scenario: Create a new user
	Given I login to a course page
	When I click Create User left menu item
	Then Page with create user form opens
	When I enter "<email>", "<password>", "<address1>", "<address2>", "<city>", "<zip>", "<annualPayment"> and "<description>"
	And I click Create button
	Then List of Users page with table opens
	And New user with "<email>", "<address1>", "<address2>", "<city>", "<zip>", "<description>" and "<annualPayment"> added to the table

	
	Examples: 
	| email            | password | address1    | address2 | city    | zip   | annualPayment | description     |
	| example@mail.com | pass1234 | 123 New St. | Apt 4    | NewCity | 00001 | 1000          | new description |
