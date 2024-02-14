CREATE TABLE Delivery
(
Order_chip int NOT NULL ,
Courier varchar(50) NULL ,
Delivery_date date NULL ,
Delivery_name varchar(18) NULL ,
Delivery_adress varchar(50) NULL
)
go


ALTER TABLE Delivery
ADD CONSTRAINT XPKDelivery PRIMARY KEY CLUSTERED (Order_chip ASC)
go


CREATE TABLE Magazine
(
Shop_chip int NOT NULL ,
Product_chip int NOT NULL
)
go


ALTER TABLE Magazine
ADD CONSTRAINT XPKMagazine PRIMARY KEY CLUSTERED (Shop_chip ASC,Product_chip ASC)
go


CREATE TABLE Orders
(
Order_chip int NOT NULL ,
Shop_chip int NULL ,
Product_name varchar(50) NULL ,
Order_quantity int NULL ,
Order_confirmation varchar(18) NULL ,
Order_date date NULL ,
Order_time varchar(18) NULL ,
Client varchar(30) NULL ,
Phone varchar(30) NULL
)
go


ALTER TABLE Orders
ADD CONSTRAINT XPKOrder PRIMARY KEY CLUSTERED (Order_chip ASC)
go


CREATE TABLE Product
(
Product_chip int NOT NULL ,
Product_name varchar(18) NULL ,
Product_price int NULL ,
Product_img varchar(18) NULL ,
Product_firm varchar(18) NULL ,
Product_model varchar(18) NULL ,
Product_description varchar(100) NULL ,
Product_warrantly varchar(18) NULL ,
Order_chip int NULL
)
go


ALTER TABLE Product
ADD CONSTRAINT XPKProduct PRIMARY KEY CLUSTERED (Product_chip ASC)
go


CREATE TABLE Shop
(
Shop_email varchar(50) NULL ,
Shop_purchase varchar(18) NULL ,
Shop_chip int NOT NULL
)
go


ALTER TABLE Shop
ADD CONSTRAINT XPKShop PRIMARY KEY CLUSTERED (Shop_chip ASC)
go



ALTER TABLE Delivery
ADD CONSTRAINT R_8 FOREIGN KEY (Order_chip) REFERENCES Orders(Order_chip)
ON DELETE NO ACTION
ON UPDATE NO ACTION
go



ALTER TABLE Magazine
ADD CONSTRAINT R_6 FOREIGN KEY (Shop_chip) REFERENCES Shop(Shop_chip)
ON DELETE NO ACTION
ON UPDATE NO ACTION
go

ALTER TABLE Magazine
ADD CONSTRAINT R_7 FOREIGN KEY (Product_chip) REFERENCES Product(Product_chip)
ON DELETE NO ACTION
ON UPDATE NO ACTION
go



ALTER TABLE Orders
ADD CONSTRAINT R_1 FOREIGN KEY (Shop_chip) REFERENCES Shop(Shop_chip)
ON DELETE NO ACTION
ON UPDATE NO ACTION
go



ALTER TABLE Product
ADD CONSTRAINT R_3 FOREIGN KEY (Order_chip) REFERENCES Orders(Order_chip)
ON DELETE NO ACTION
ON UPDATE NO ACTION
go