Feature: M and G Test

Scenario Outline: Null, empty string or string other than 7 characters long
Given I am on the SEDOL validation test page
When I set the IsValidSedol checkbox to '<IsValidSedol>'
And I set the IsUserDefined checkbox to '<IsUserDefined>'
And submit the test SEDOL '<InputString Test Value>'
Then the validation details shown are '<ValidationDetails>'
Examples: 
| InputString Test Value | IsValidSedol | IsUserDefined | ValidationDetails                       |
| Null                   | False        | False         | Input string was not 7-characters long. |
| 12                     | False        | False         | Input string was not 7-characters long. |
| 123456789              | False        | False         | Input string was not 7-characters long. |

Scenario Outline:  Invalid non user define SEDOL
Given I am on the SEDOL validation test page
When I set the IsValidSedol checkbox to '<IsValidSedol>'
And I set the IsUserDefined checkbox to '<IsUserDefined>'
And submit the test SEDOL '<InputString Test Value>'
Then the validation details shown are '<ValidationDetails>'
Examples: 
| InputString Test Value | IsValidSedol | IsUserDefined | ValidationDetails										      |
| 1234567                | False        | False         | Checksum digit does not agree with the first 6 characters.  |

Scenario Outline: Valid non user defined SEDOL
Given I am on the SEDOL validation test page
When I set the IsValidSedol checkbox to '<IsValidSedol>'
And I set the IsUserDefined checkbox to '<IsUserDefined>'
And submit the test SEDOL '<InputString Test Value>'
Then the validation details shown are '<ValidationDetails>'
Examples: 
| InputString Test Value | IsValidSedol | IsUserDefined | ValidationDetails |
| 0709954                | True         | False         | Null              |
| B0YBKJ7                | True         | False         | Null              |

Scenario Outline: Invalid user defined SEDOL
Given I am on the SEDOL validation test page
When I set the IsValidSedol checkbox to '<IsValidSedol>'
And I set the IsUserDefined checkbox to '<IsUserDefined>'
And submit the test SEDOL '<InputString Test Value>'
Then the validation details shown are '<ValidationDetails>'
Examples: 
| InputString Test Value | IsValidSedol | IsUserDefined | ValidationDetails                                          |
| 9123451                | False        | True          | Checksum digit does not agree with the first 6 characters. |
| 9ABCDE8                | False        | True          | Checksum digit does not agree with the first 6 characters. |

Scenario Outline: Valid user defined SEDOL
Given I am on the SEDOL validation test page
When I set the IsValidSedol checkbox to '<IsValidSedol>'
And I set the IsUserDefined checkbox to '<IsUserDefined>'
And submit the test SEDOL '<InputString Test Value>'
Then the validation details shown are '<ValidationDetails>'
Examples: 
| InputString Test Value | IsValidSedol | IsUserDefined | ValidationDetails |
| 9123458                | True         | True          | Null              |
| 9ABCDE1                | True         | True          | Null              |