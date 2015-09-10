Feature: Convert a NameValueCollection to a ToKeyValueCollection

Scenario: NameValueCollection has simple values
	Given a NameValueCollection with values
		| Key | Value           |
		| a   | 1               |
		| b   | hello           |
		| c   | SimpleObject    |
		| d   | RecursizeObject |
	When I call ToKeyValueCollection
	Then a name value list should be returned with values
		| Key | Value           |
		| a   | 1               |
		| b   | hello           |
		| c   | SimpleObject    |
		| d   | RecursizeObject |

Scenario: NameValueCollection is empty
	Given an empty NameValueCollection
	When I call ToKeyValueCollection
	Then an empty name value list should be returned
