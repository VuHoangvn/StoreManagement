use[Store Management]

go
-- Tạo bảng loại tài khoản
create table AccountType
(
	id int identity primary key,
	name nvarchar(100)
)

go

-- Tạo bảng tài khoản
create table Account
(
	username nvarchar(100) primary key,
	DisPlayName nvarchar(100) not null,
	PassWord nvarchar(100) not null,
	Type int not null,

	foreign key(Type) references AccountType(id)
)

go

-- Tạo thủ tục thêm loại tài khoản
create proc add_account_type @name nvarchar(100)
as
begin
	insert AccountType(name) values (@name)		
end

go

-- Tạo thủ tục sửa tên loại
create proc edit_type_name @id int, @name nvarchar(100)
as
begin
	update AccountType set name = @name where id=@id
end

go

-- Tạo thủ tục xóa loại tài khoản
create or alter proc delete_account_type @id int
as
begin
	delete from Account where type=@id
	delete from AccountType where id=@id
end

go
-- Tạo thủ tục thêm tài khoản
create proc add_account 
@userName nvarchar(100), @displayName nvarchar(100), @passWord nvarchar(100), @type int
as
begin
	insert Account(username, DisPlayName, PassWord, Type) values (@userName, @displayName, @passWord, @type)
end

go

-- Tạo thủ tục sửa tài khoản
create proc edit_account 
@userName nvarchar(100), @displayName nvarchar(100), @passWord nvarchar(100), @type int
as
begin
	update Account set username=@userName, DisPlayName=@displayName, PassWord=@passWord, Type=@type
end

go

-- Tạo thủ tục xóa tài khoản
create proc delete_account
@userName nvarchar(100)
as
begin 
	delete from Account where username=@userName
end

go


---------------------------------------------
---------------------------------------------

-- Tạo bảng loại mặt hàng
create table Category
(
	idCategory int identity primary key,
	name nvarchar(100) not null
)

go

-- Tạo bảng khách hàng
create table Customer
(
	idCustomer int identity primary key,
	name nvarchar(50) not null,
	address nvarchar(100),
	telephone varchar(10) check(telephone like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
)

go

-- Tạo bảng nhà cung cấp
create table Producer
(
	idProducer int identity primary key,
	name nvarchar(50),
	address nvarchar(100),
	telephone varchar(10) check(telephone like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
)

go

-- Tạo bảng hàng hóa
create table Goods
(
	idGoods int identity primary key,
	idCategory int,
	idProducer int,
	amount int,
	name nvarchar(100),
	price int,

	foreign key(idCategory) references Category(idCategory),
	foreign key(idProducer) references Producer(idProducer) 
)

go

-- Tạo bảng hóa đơn xuất
create table IssueBill
(
	idIssueBill int identity primary key,
	idCustomer int,
	issueDate date,
	issueTotal int,

	foreign key(idCustomer) references Customer(idCustomer)
)

go

-- Tạo bảng chi tiết hóa đơn xuất
create table IssueBillInfo
(
	idIssueBillInfo int identity primary key,
	idIssueBill int,
	idCategory int,
	idGoods int,
	amount int,
	discount int,
	price int,

	foreign key(idIssueBill) references IssueBill(idIssueBill),
	foreign key(idCategory) references Category(idCategory),
	foreign key(idGoods) references Goods(idGoods)
)

-- Tạo bảng hóa đơn nhập
create table ReceiptBill
(
	idReceiptBill int identity primary key,
	idProducer int,
	receiptDate date,
	receiptTotal int,

	foreign key(idProducer) references Producer(idProducer) 
)

go

-- Tạo bảng chi tiết hóa đơn nhập
create table ReceiptBillInfo
(
	idReceiptBillInfo int identity primary key,
	idReceiptBill int,
	idGoods int,
	idCategory int,
	amount int, 
	discount int,
	price int,

	foreign key(idReceiptBill) references ReceiptBill(idReceiptBill),
	foreign key(idGoods) references Goods(idGoods),
	foreign key(idCategory) references Category(idCategory)
)

go


