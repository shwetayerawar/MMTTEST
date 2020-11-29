CREATE TABLE dbo.Product (
    ID int NOT NULL PRIMARY KEY,
    ProductName varchar(255),
    ProductDescription varchar(255),
    SKU varchar(255),
	price decimal(10,2),
	CategoryID int FOREIGN KEY REFERENCES dbo.Category(ID)
);


CREATE TABLE dbo.Category (
    ID int NOT NULL PRIMARY KEY,
    CategoryName varchar(255),
	CategoryDescription varchar(255),	
	CategoryMinSKURange int ,
	CategoryMaxSKURange int ,
	Featured bit default(0)
);



Insert into Category (ID , CategoryName , CategoryDescription , CategoryMinSKURange , CategoryMaxSKURange ,featured )
values (1, 'HOME' , 'Products Related to HOME' , '10000' ,'19999'  , 1 );

Insert into Category (ID , CategoryName , CategoryDescription , CategoryMinSKURange , CategoryMaxSKURange ,featured  )
values(2, 'Garden' , 'Products Related to Garden' , '20000' , '29999' , 1);

Insert into Category (ID , CategoryName , CategoryDescription , CategoryMinSKURange , CategoryMaxSKURange ,featured )
values(3, 'Electronics' , 'Products Related to Electronics' , '30000' , '39999' , 1);

Insert into Category (ID , CategoryName , CategoryDescription , CategoryMinSKURange , CategoryMaxSKURange  )
values(4, 'Fitness' , 'Products Related to Fitness' , '40000' , '49999')
;
Insert into Category (ID , CategoryName , CategoryDescription , CategoryMinSKURange , CategoryMaxSKURange  )
values(5, 'Toys' , 'Products Related to Toys' , '50000' ,'59999');




insert into Product (ID , ProductName , ProductDescription , SKU , price ,CategoryID  )
values ( 1 , 'Sofa' , 'Home Sofas' ,10000 , 1999.90 , 1 ) ;

insert into Product (ID , ProductName , ProductDescription , SKU , price ,CategoryID  )
values ( 2 , 'Fountain' , 'Garden Fountain' ,20003 , 199.00 , 2 ) ;

insert into Product (ID , ProductName , ProductDescription , SKU , price ,CategoryID  )
values ( 3 , 'Laptops' , 'Laptops and tablets ' ,30060 , 1235.00 , 3 ) ;

insert into Product (ID , ProductName , ProductDescription , SKU , price ,CategoryID  )
values ( 4 , 'Trade Mill' , 'Gym equipment' ,40600 , 1579.90 , 4 ) ;

insert into Product (ID , ProductName , ProductDescription , SKU , price ,CategoryID  )
values ( 5 , 'Drone' , 'Toys' ,56000 , 499.50 , 5 ) ;


---------select--------------


select * from Product

select * from Category
