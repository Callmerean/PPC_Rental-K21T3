#add @web tag to run the search tests with Selenium automation

#@web
@automated
Feature: US04 - property details
	As a potential customer
	I want to see the details of a property
	So that I can better decide to buy it.

Background:
	Given the following propertys
		| PropertyName                                 | Area  | Price  |
		| PIS Top Apartment                            | 120m2 | 10000  |
		| ICON 56 – Modern Style Apartment             | 130m2 | 30000  |
		| PIS Serviced Apartment – Boho Style          | 120m2 | 70000  |
		| Bigroom with Riverview                       | 200m2 | 90000  |
		| PIS Serviced Apartment – Style 3             | 130m2 | 30000  |
		| Vinhomes Central Park L2 – Duong’s Apartment | 150m2 | 110000 |
		| Saigon Pearl Ruby Block                      | 130m2 | 30000  |
		| Nguyen Dinh Chinh – Duplex with Balcony      | 120m2 | 200000 |
		| Sunshine Ben Thanh                           | 130m2 | 40000  |
		| Cosiana Apartment with Balcony			   | 500m2 | 990000 |


Scenario: The property detail be showed
	When I open the details of 'Analysis Patterns'
	Then the property details should show
		| PropertyName                                 | Area  | Price  |
		| Cosiana Apartment with Balcony			   | 500m2 | 990000 |