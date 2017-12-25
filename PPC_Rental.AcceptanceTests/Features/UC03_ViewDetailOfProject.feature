@automated
@web
Feature: UC03_ViewDetailOfProject
	As a potential customer
	I want to see the details of a property
	So that I can better decide to buy it.

Background:
	Given the following properties
	| PropertyName        | Avatar| Images    | Property Type | Content                                                                                | Street         | Ward        | District | Price | UnitPrice | Area  | BedRoom | BathRoom | ParkingPlace | Owner                      | Created_at | Created_post | Status   | Note | Updated_at |
	| PIS Top Apartment 1 | 1.png | test.jpg, | Apartment     | The surrounding neighborhood is very much localized with a great number of local shops | Điền Viên Thôn | TT Tây Đằng | Ba Vì    | 10000 | USD       | 120m2 | 3       | 3        | 1            | lythihuyenchau@gmail.com   | 2017-11-09 | 2017-11-09   | Đã duyệt | Done | 2017-11-09 |
	| PIS Top Apartment 2 | 2.png | test.jpg, | Apartment     | The surrounding neighborhood is very much localized with a great number of local shops | Điền Viên Thôn | TT Tây Đằng | Ba Vì    | 10000 | USD       | 120m2 | 3       | 3        | 1            | lythihuyenchau@gmail.com   | 2017-11-09 | 2017-11-09   | Đã duyệt | Done | 2017-11-09 |
	| PIS Top Apartment 3 | 3.png | test.jpg, | Apartment     | The surrounding neighborhood is very much localized with a great number of local shops | Điền Viên Thôn | TT Tây Đằng | Ba Vì    | 10000 | USD       | 120m2 | 3       | 3        | 1            | lythihuyenchau@gmail.com   | 2017-11-09 | 2017-11-09   | Đã duyệt | Done | 2017-11-09 |

Scenario:The propertyname,the avatar,owner,content,price of a property can be seen
	When  I open the details of 'PIS Top Apartment 1'
	Then  the property details should show
	| PropertyName        | Avatar| Owner                    | Price | Content                                                                                |
	| PIS Top Apartment 1 | 1.png | lythihuyenchau@gmail.com  | 10000 | The surrounding neighborhood is very much localized with a great number of local shops |
		
