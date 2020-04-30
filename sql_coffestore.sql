CREATE DATABASE CoffeStoreManagement
use CoffeStoreManagement

CREATE table Product(
	Product_ID char(5) primary key,
	Product_Price int,
	Product_Name char(10),
	Product_State bit,
	Product_Cost_good_sold int,
	Product_Profit int
)


CREATE table Detail_Product(
	Product_ID char (5) references Product(Product_ID),
	Resource_ID char(5),
	AmongResource_PerUnit int,
	Primary key (Product_ID, Resource_ID)
)

CREATE table Resource(
	Resource_ID char(5) primary key,
	Resource_Stock int,
	Resource_Price int,
	Resource_Name char(10),
	Resource_Unit char(5),
	Resource_State bit
)

Alter table Detail_Product WITH CHECK ADD FOREIGN KEY(Resource_ID) REFERENCES Resource(Resource_ID)


Create table Employee(
	Employee_ID char (5) primary key,
	Employee_Salary int,
	Employee_Name char (30),
	Employee_Birthday date,
	Employee_ManagerID char(5),
	Employee_State bit
)
Alter table Employee WITH CHECK ADD FOREIGN KEY(Employee_ManagerID) REFERENCES Employee(Employee_ID)


Create table Bill(
	Bill_ID char(5),
	Bill_Date date,
	Bill_TotalPrice int,
	Bill_Maker char (5) references Employee(Employee_ID),
	Primary key (Bill_ID)
)

Create table Bill_detail(
	Bill_ID char(5) references Bill(Bill_ID),
	Product_ID char (5) references Product(Product_ID),
	Among int,
	Primary key (Bill_ID, Product_ID)
)

