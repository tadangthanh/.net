CREATE PROCEDURE SaveCustomer
    @Name nvarchar(255),
    @Address nvarchar(255),
    @PhoneNumber nvarchar(20),
    @CitizenIdNumber nchar(12)
AS
BEGIN
    DECLARE @CustomerId INT

    -- Thêm khách hàng vào bảng Customer và lấy giá trị mới của CustomerId
    INSERT INTO Customer (Name, Address, PhoneNumber, CitizenIdNumber)
    VALUES (@Name, @Address, @PhoneNumber, @CitizenIdNumber);

    -- Lấy giá trị mới của CustomerId
    SET @CustomerId = SCOPE_IDENTITY()

    -- Trả về giá trị CustomerId
    SELECT @CustomerId AS CustomerId
END
