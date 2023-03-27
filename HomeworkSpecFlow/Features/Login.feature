Feature: Login

Login to a course page

@tag1
Scenario: Login to Course Page
	Given Open page with login form
	When I enter the following credentials
	| Username      | Password |
	| walker@jw.com | password |
	And I click login button
	Then Waiting for spinner disappears
	Then Course page displays
