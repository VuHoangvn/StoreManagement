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

-- Tạo thủ tục tìm tài khoản theo tên
create proc USP_GetAccountByUserName
@userName nvarchar(100)
as
begin
	select * from Account where UserName = @userName 
end

go

-- Tạo thủ tục đăng nhập
create proc USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
as
begin
	select * from Account where UserName=@userName and PassWord=@passWord 
end

go

-- Tạo thủ tục thêm loại tài khoản
create or alter proc add_account_type @name nvarchar(100)
as
begin
	insert AccountType(name) values (@name)		
end

go

-- Tạo thủ tục sửa tên loại
create or alter proc edit_type_name @id int, @name nvarchar(100)
as
begin
	update AccountType set name = @name where id=@id
end

go

-- Tạo thủ tục xóa loại tài khoản
create or alter proc delete_account_type @id int
as
begin
	declare @isTrue int = 0

	select @isTrue = count(*) from AccountType where id = @id

	if (@isTrue = 1)
	begin
		delete from Account where type=@id
		delete from AccountType where id=@id
	end
end

go
-- Tạo thủ tục thêm tài khoản
create or alter proc add_account 
@userName nvarchar(100), @displayName nvarchar(100), @passWord nvarchar(100), @type int
as
begin
	insert Account(username, DisPlayName, PassWord, Type) values (@userName, @displayName, @passWord, @type)
end

go

-- Tạo thủ tục sửa tài khoản

create or alter proc USP_UpdateAccount
@username nvarchar(100), @displayName nvarchar(100), @passWord nvarchar(100), @newPassWord nvarchar(100)
as
begin
	declare @isRight int = 0

	select @isRight = count(*) from Account where UserName = @username and PassWord = @passWord

	if (@isRight = 1)
	begin
		if(@newPassWord = null or @newPassWord = '')
		begin
			update Account set DisPlayName = @displayName where UserName = @username
		end
		else
			update Account set DisPlayName = @displayName, PassWord = @newPassWord where UserName = @username
			
	end 
end

go

-- Tạo thủ tục xóa tài khoản
create or alter proc delete_account
@userName nvarchar(100)
as
begin 
	declare @isRight int = 0

	select @isRight = count(*) from Account where UserName = @username

	if (@isRight = 1)
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

-- Tạo thủ tục thêm mới loại
create or alter proc add_category
@name nvarchar(100)
as
begin
	insert Category(name) values (@name)
end

go

-- Tạo thủ tục sửa loại
create or alter proc update_category
@name nvarchar(100), @id int
as
begin
	declare @isRight int = 0

	select @isRight = count(*) from Category where idCategory=@id

	if (@isRight = 1)
	begin
		update Category set name = @name where idCategory=@id 
	end
end

go
-- Tạo thủ tục xóa loại
create or alter proc delete_category
@id int
as
begin
	declare @isRight int = 0

	select @isRight = count(*) from Category where idCategory=@id

	if (@isRight = 1)
	begin
		delete from Category where idCategory=@id
	end
end

go

-- Tạo thủ tục lấy ra loại theo id
create or alter proc get_category_by_id
@id int
as
begin
	declare @isRight int = 0

	select @isRight = count(*) from Category where idCategory=@id

	if (@isRight = 1)
	begin
		select * from Category where idCategory=@id
	end
end

go
---------------------------------------
---------------------------------------

-- Tạo bảng khách hàng
create table Customer
(
	idCustomer int identity primary key,
	name nvarchar(50) not null,
	address nvarchar(100),
	telephone varchar(10) check(telephone like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
)

go

-- Tạo thủ tục thêm khách hàng
create or alter proc add_Customer
@name nvarchar(50), @address nvarchar(100), @telephone varchar(10)
as
begin
	insert Customer(name,address, telephone) values (@name, @address, @telephone)
end

go

-- Tạo thủ tục sửa khách hàng
create or alter proc update_customer
@name nvarchar(50),@address nvarchar(100), @telephone varchar(10), @id int
as
begin
	declare @isRight int = 0

	select @isRight = count(*) from Customer where idCustomer=@id

	if (@isRight = 1)
	begin
		update Customer set name = @name, address=@address, telephone=@telephone where idCustomer=@id 
	end
end

go
-- Tạo thủ tục xóa khách hàng
create or alter proc delete_customer
@id int
as
begin
	declare @isRight int = 0

	select @isRight = count(*) from Customer where idCustomer=@id

	if (@isRight = 1)
	begin
		delete from Customer where idCustomer=@id
	end
end

go

-- Tạo thủ tục lấy ra khách hàng theo id
create or alter proc get_customer_by_id
@id int
as
begin
	declare @isRight int = 0

	select @isRight = count(*) from Customer where idCustomer=@id

	if (@isRight = 1)
	begin
		select * from Customer where idCustomer=@id
	end
end

go

-- Tạo thủ tục lấy ra khách hàng theo tên
	--Tạo hàm chuyển chuỗi có dấu, viết hoa về không dấu viết thường
	CREATE FUNCTION fuConvertToUnsign1 ( @strInput NVARCHAR(4000) ) 
	RETURNS NVARCHAR(4000) 
	AS 
	BEGIN 
		IF @strInput IS NULL 
			RETURN @strInput 
		IF @strInput = '' 
			RETURN @strInput 
		DECLARE @RT NVARCHAR(4000) 
		DECLARE @SIGN_CHARS NCHAR(136) 
		DECLARE @UNSIGN_CHARS NCHAR (136) 
		SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) 
		SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' 
		DECLARE @COUNTER int 
		DECLARE @COUNTER1 int 
		SET @COUNTER = 1 
		WHILE (@COUNTER <=LEN(@strInput)) 
		BEGIN
			SET @COUNTER1 = 1
			WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) 
			BEGIN 
				IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) )
					BEGIN 
						IF @COUNTER=1 
							SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
						ELSE 
							SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) 
							BREAK 
					END
					SET @COUNTER1 = @COUNTER1 +1 
			END 
			SET @COUNTER = @COUNTER +1 
		END
		SET @strInput = replace(@strInput,' ','-') 
		RETURN @strInput 
	END

	go
	--Tạo thủ tục
create or alter proc get_customer_by_name
@name nvarchar(50)
as
begin
	select * from Customer where dbo.fuConvertToUnsign1(name) like N'%' + dbo.fuConvertToUnsign1(@name)+'%'
end
go

-------------------------------------
-------------------------------------
-- Tạo bảng nhà cung cấp
create table Producer
(
	idProducer int identity primary key,
	name nvarchar(50),
	address nvarchar(100),
	telephone varchar(10) check(telephone like '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
)

go

-- Tạo thủ tục thêm nhà cung cấp
create or alter proc add_producer
@name nvarchar(50), @address nvarchar(100), @telephone varchar(10)
as
begin
	insert Producer(name,address, telephone) values (@name, @address, @telephone)
end

go

-- Tạo thủ tục sửa nhà cung cấp
create or alter proc update_producer
@name nvarchar(50),@address nvarchar(100), @telephone varchar(10), @id int
as
begin
	declare @isRight int = 0

	select @isRight = count(*) from Producer where idProducer=@id

	if (@isRight = 1)
	begin
		update Producer set name = @name, address=@address, telephone=@telephone where idProducer=@id 
	end
end

go
-- Tạo thủ tục xóa nhà cung cấp
create or alter proc delete_producer
@id int
as
begin
	declare @isRight int = 0

	select @isRight = count(*) from Producer where idProducer=@id

	if (@isRight = 1)
	begin
		delete from Producer where idProducer=@id
	end
end

go

-- Tạo thủ tục lấy ra nhà cung cấp theo id
create or alter proc get_producer_by_id
@id int
as
begin
	declare @isRight int = 0

	select @isRight = count(*) from Producer where idProducer=@id

	if (@isRight = 1)
	begin
		select * from Producer where idProducer=@id
	end
end

go

-- Tạo thủ tục lấy ra khách hàng theo tên
	--Tạo thủ tục
create or alter proc get_producer_by_name
@name nvarchar(50)
as
begin
	select * from Producer where dbo.fuConvertToUnsign1(name) like N'%' + dbo.fuConvertToUnsign1(@name)+'%'
end

go


---------------------------------------
---------------------------------------
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

-- Tạo thủ tục thêm mặt hàng
create proc add_goods
@idCategory int, @idProducer int, @amount int, @name nvarchar(100), @price int
as
begin
	
	insert Goods(idCategory, idProducer, amount,name, price) values (@idCategory, @idProducer, @amount, @name, @price)
end

go

-- Tạo thủ tục sửa mặt hàng
create or alter proc update_goods
@idGoods int, @idCategory int, @idProducer int, @amount int, @name nvarchar(100), @price int
as
begin
	declare @isRight int = 0

	select @isRight = count(*) from Goods where idGoods=@idGoods

	if (@isRight = 1)
	begin
		update Goods set idCategory=@idCategory,idProducer=@idProducer, amount=@amount, name=@name, price=@price where idGoods=@idGoods 
	end
end

go


-- Tạo thủ tục lấy ra mặt hàng theo id
create proc get_goods_by_id
@id int
as
begin
	declare @isRight int = 0

	select @isRight = count(*) from Goods where idGoods=@id

	if (@isRight = 1)
	begin
		select * from Goods where idGoods=@id
	end
end

go

-- Tạo thủ tục lấy ra khách hàng theo tên
	--Tạo thủ tục
create or alter proc get_goods_by_name
@name nvarchar(50)
as
begin
	select * from Goods where dbo.fuConvertToUnsign1(name) like N'%' + dbo.fuConvertToUnsign1(@name)+'%'
end

go

------------------------------------------
------------------------------------------


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

-------------------------------------------------
-------------------------------------------------
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


-------------------------------------------
-------------------------------------------
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


----------------------------------------------
----------------------------------------------
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

-------------------------------------------
-------------------------------------------
-- Tạo bảng nợ của khách hàng
create table CustomerDebt
(
	idCustomerDebt int primary key identity,
	idCustomer int,
	idIssueBill int,
	debt int default 0,
	payment int default 0,

	foreign key(idCustomer) references Customer(idCustomer),
	foreign key(idIssueBill) references IssueBill(idIssueBill) 
)

go
-------------------------------------------
-------------------------------------------
-- Tạo bảng nợ nhà cung cấp
create table ProducerDebt
(
	idProducerDebt int primary key identity,
	idProducer int,
	idReceiptBill int,
	debt int default 0,
	payment int default 0,

	foreign key(idProducer) references Producer(idProducer),
	foreign key(idReceiptBill) references ReceiptBill(idReceiptBill) 
)

go