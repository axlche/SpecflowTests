Feature: Login

Login to a course page

@tag1
Scenario: Login to Course Page
	Given Open page with login form
	When I enter "<username>" and "<password>"
	And I click login button
	Then Spinner appears
	When Spinner disappeared
	Then Course page displays

	Examples:
	| username      | password |
	| walker@jw.com | password |
