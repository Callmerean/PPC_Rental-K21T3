@automated
#@web
Feature: UC1_Filter
	In order to search project
	As a user of the website
	I want to search project

Background: 
	Given the following project
	| PropertyName                                 | Avarta                                           | Images                                                                             | PropertyType | Content                                                                                                      | Street         | Ward        | District  | Price  | UnitPrice | Area  | BedRoom | BathRoom | PackingPlace | Agency | Create_at  | Create_post | Status   | Note | Update_at  | Sale	  |
	| Sunshine Ben Thanh                           | PIS_6656-Edit-stamp.jpg                          | a17584387317552326.jpg,AvatarNone17100766117552327.png,images1709523917552328.jpg, | Office	      | The surrounding neighborhood is very much localized with a great number of local shops.                      | Thôn Chúc Đồng | Đại Yên     | Chương Mỹ | 40000  | VND       | 120m2 | 2       | 2        | 1            | Ly Chau| 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 | Ly Chau |
	| ViLa Q7                                      | images172300301.jpg                              | images172300301.jpg                                                                | Villa        | Brand new apartments with unbelievable river and city view, completely renovated and tastefully furnished.   | Số 39          | TT Xuân Mai | Chương Mỹ | 70000  | VND       | 120m2 | 3       | 4        | 1            | Ly Chau| 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 | Ly Chau |
	| PIS Serviced Apartment – Style               | sunshine-benthanh-cityhome-10-stamp174228283.jpg | a - Copy17095239.jpg,images (1) - Copy17095242.jpg,images17095242.jpg,             | Office       | The well equipped kitchen is opened on a cozy living room and a dining area with table and chairs..          | Thôn Chúc Đồng | Đại Yên     | Chương Mỹ | 30000  | VND       | 130m2 | 2       | 3        | 1            | Ly Chau| 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 | Ly Chau |
	| Vinhomes Central Park L2 – Duong’s Apartment | PIS_7389-Edit-stamp.jpg                          | images1702244617042862.jpg,                                                        | Villa        | Vinhomes Central Park is a new development that is in the heart of everything that Ho Chi Minh has to offer. | Số 39          | TT Xuân Mai | Chương Mỹ | 110000 | VND       | 150m2 | 4       | 2        | 1            | Ly Chau| 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 | Ly Chau |
	| Saigon Pearl Ruby Block                      | PIS_7319-Edit-stamp.jpg                          | images17423697317334243.jpg,PIS_4622-Edit17463610217334244.jpg,                    | Apartment    | Studio apartment at central of CBD, nearby Ben Thanh market, Bui Vien Backpacker Area, 23/9 park…            | Thôn Chúc Đồng | Đại Yên     | Chương Mỹ | 30000  | VND       | 130m2 | 3       | 5        | 1            | Ly Chau| 2017-11-09 | 2017-11-09  | Đã duyệt | Done | 2017-11-23 | Ly Chau |

Scenario: Filter Project
	When I search for projects by the phrase 'Chương Mỹ','Office','2','2','30000-60000'
	Then project should display project with projectname follow 'Sunshine Ben Thanh'
	