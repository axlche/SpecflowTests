Feature: Create User

Create user via Create user form and check that new user added to the table

Background:
    Given I login to a course page

Scenario: Create a new user
    When I click Create User left menu item
    Then Page with create user form opens
    When I enter user information
    | email            | password | address1    | address2 | city    | zip   | annualPayment | description     |
    | example@mail.com | pass1234 | 123 New St. | Apt 4    | NewCity | 00001 | 1000          | new description |
    And I click Create button
    Then List of Users page with table opens
    And New user is added to the table
    | email            | address1    | address2 | city    | zip   | description     | annualPayment |
    | example@mail.com | 123 New St. | Apt 4    | NewCity | 00001 | new description | 1000          |
