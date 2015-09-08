Feature: Convert IDictionary to KeyValueCollection

Scenario: Dictionary has values
	Given a dictionary with values
		| Key | Value |
		| a   | 1     |
		| b   | 2     |
	When I call ToKeyValueCollection
	Then a name value collection should be returned with values
		| Key | Value |
		| a   | 1     |
		| b   | 2     |

Scenario: Dictionary is empty
	Given an empty dictionary
	When I call ToKeyValueCollection
	Then an empty name value collection should be returned
