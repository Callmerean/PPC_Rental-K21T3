Feature: Editofagencyproject
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Background: 
	Given  the following list
	|PropertyName					|Avatar	|ProertyType	|Price		|UnitPrice	|Area	 |District		  |Status        |Created			      |
	|Sunshine BenThanh				|		|Office			|400000	    |USD 		|130m2	 |Chương Mỹ		  |Đã Duyệt		 |9/11/2017 12:00:00 AM   |
	|Cosiana Apartment with Balcony |		|Villa			|990000		|USD		|500m2	 |Chương Mỹ		  |Đã Duyệt		 |9/11/2017 12:00:00 AM   |
Scenario: Successful Edit of Project
	Given Mở trang trủ
	When Bấm vào nút login
	When Nhập tài khoảng
	| UserName                 | PassWord     |
	| lythihuyenchau@gmail.com | 123456       |
	When Agency bấm vào Edit Agency project
	Then Agency bấm vào OK.
