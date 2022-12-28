CREATE TABLE Brands(
BrandId int IDENTITY(1,1) NOT NULL primary key,
Name nvarchar(500) NULL,
)

CREATE TABLE Category(
CatId int IDENTITY(1,1) NOT NULL primary key,
CatName nvarchar(max) NULL,
)

CREATE TABLE SubCategory(
SubCatId int IDENTITY(1,1) NOT NULL primary key,
SubCatName nvarchar(max) NULL,
MainCatId int NULL,
CONSTRAINT [FK_SubCategory_Category] FOREIGN KEY([MainCatId]) REFERENCES Category ([CatId])
)

create table Users
(
Uid int identity(1,1) primary key not null,
Username nvarchar(100) Null, 
Password nvarchar(100) Null,
Email nvarchar(100) Null,
Name nvarchar(100) Null,
UserType nvarchar(50) default 'User'
)

create table ForgetPass
(
Id nvarchar (500)  not null,
Uid int null,
RequestDateTime DATETIME null,
Constraint [FK_ForgotPass_tblUsers] FOREIGN KEY ([Uid]) REFERENCES [Users] ([Uid])

)

CREATE TABLE Products(
Pid int IDENTITY(1,1) NOT NULL primary key,
PName nvarchar(max) NULL,
PPrice money NULL,
PSelPrice money NULL,
PBrandId int NULL,
PCategoryId int NULL,
PSubCategoryId int NULL,
PDescription varchar(max) NULL,
PDetails varchar(max) NULL,
PMaterial varchar(max) NULL,
FreeDelivery int NULL,
Return30day int NULL,
COD int NULL
Constraint [FK_Products_ToTable] FOREIGN KEY ([PBrandId]) REFERENCES [Brands] ([BrandId]),
Constraint [FK_Products_ToTable1] FOREIGN KEY ([PCategoryId]) REFERENCES [Category] ([CatId]),
Constraint [FK_Products_ToTable2] FOREIGN KEY ([PSubCategoryId]) REFERENCES [SubCategory] ([SubCatId]),
)

CREATE TABLE ProductImages(
PimgId int IDENTITY(1,1) NOT NULL,
Pid int NULL,
Name nvarchar(max) NULL,
Extention nvarchar(500) NULL,
Constraint [FK_ProductImages_ToTable] FOREIGN KEY ([Pid]) REFERENCES [Products] ([Pid])
)

create table ProdQuantity
(
ProdQuantityId int identity(1,1) primary key,
Pid int,
Quantity int,
Constraint [FK_ProductSizeQuantity_ToTable] FOREIGN KEY ([Pid]) REFERENCES [Products] ([Pid])
)