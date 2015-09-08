Feature: Convert IDictionary to KeyValueList

Scenario: Dictionary has values
	Given a dictionary with values
		| Key | Value |
		| a   | 1     |
		| b   | 2     |
	When I call ToKeyValueList
	Then a name value list should be returned with values
		| Key | Value |
		| a   | 1     |
		| b   | 2     |

Scenario: Dictionary is empty
	Given an empty dictionary
	When I call ToKeyValueList
	Then an empty name value list should be returned

Scenario: Complex values
	Given a dictionary with values
		| Key | Value                            |
		| a   | 1                                |
		| b   | string value                     |
		| c   | new Exception("dummy exception") |
	When I call ToKeyValueList
	Then a name value list should be returned with values
		| Key | Value                |
		| a   | 1                    |
		| b   | string value         |
		| c   | exception collection |
