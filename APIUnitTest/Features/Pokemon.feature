Feature: Pokemon

@mytag
Scenario: Get all pokemons created
	Given I have access to the API /pokemon/
	When I send the request of api
	Then the result should be the information about the pokemons created

