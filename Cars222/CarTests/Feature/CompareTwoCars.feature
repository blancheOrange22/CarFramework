Feature: CompareTwoCars

@mytag
Scenario: Compare two cars
	Given I have expected mainPage title 'New Cars, Used Cars, Trucks For Sale, Auto Reviews | Cars.com'
	When I go to baseUrl 'http://www.cars.com'
	Then the expected title is equal the actual title

	Given I have expected homePage title 'New Car Reviews | Cars.com'
	When I choose inset 'Buy' in menu and inset 'Review a Car' in submenu
	Then the expected homePage title is equal the actual title

	Given I have expected choosePage title '2010 Ford Explorer Reviews, Specs and Prices | Cars.com'
	And I have make 'Ford', model 'Explorer', year '2010' of the first car
	When I choose all these characteristics
	Then the expected choosePage title is equal the actual title

	Given I have expected modPage title '2010 Ford Explorer XLT 4dr 4x2 | Cars.com'
	When I press Trims and View Details
	Then the expected modPage title is equal the actual title

	Given I have expected engine '210-hp, 4.0-liter V-6 (regular gas)', transmission '5-speed automatic w/OD' of the first car
	When I take actual values of engine and transmission of the first car from the page
	Then the expected and actual values are the same

	Given I have the expected choosePage title '2015 BMW 228 Reviews, Specs and Prices | Cars.com'
	And I have make 'BMW', model '228', year '2015' of the second car
	When I go to car catalogue
	And choose all options of the second car
	Then the expected choosePage title is equal the actual

	Given I have expected engine '240-hp, 2.0-liter I-4 (premium)', transmission '6-speed manual w/OD' of the second car
	When I take actual values of engine and transmission of the second car from the page
	Then the expected and actual values are equal

	When I click inset Trims, choose View Details
	And I click Add another car
	And I choose all characteristics of the first car to compare
	Then there are two prices of these cars on the page

	When I compare actual and expected values of engine, transmission of both cars
	Then the values are the same
