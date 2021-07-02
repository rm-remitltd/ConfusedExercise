Feature: Manage Computers
	In order to maintain a database of Computer hardware
	As a Computer Database User
	I want to be able to view, add and delete computers in the database

Scenario: User can view a computer in the list after adding it
	Given the user adds a new computer
	When they view the list of computers in the system
	Then the new computer will be shown

Scenario: User can delete a computer removing it from the list
	Given the user selects a computer 
	When they delete the selected computer
	Then the computer will no longer show in the list

Scenario: User searches for and finds a computer they are looking for in the system
	When the user uses the filter to search for a computer that exists in the system
	Then the computer will be displayed in the list of filtered results

Scenario: User searches for a computer that doesn't exist and finds no results
	When the user uses the filter to search for a computer that doesn't exist in the system
	Then no results will be displayed