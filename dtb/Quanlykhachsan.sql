-- Tạo bảng cho Room
CREATE TABLE Room (
    RoomId INT PRIMARY KEY IDENTITY(1,1),
    RoomType NVARCHAR(255) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Status NVARCHAR(50),
    Amenities NVARCHAR(MAX)
);

-- Tạo bảng cho Customer
CREATE TABLE Customer (
    CustomerId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255),
    PhoneNumber NVARCHAR(20)
);

-- Tạo bảng cho Admin
CREATE TABLE Admin (
    AdminId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(255) NOT NULL
);

-- Tạo bảng cho Reservation
CREATE TABLE Reservation (
    ReservationId INT PRIMARY KEY IDENTITY(1,1),
    RoomId INT,
    CheckInDate DATETIME NOT NULL,
    CheckOutDate DATETIME NOT NULL,
    NumberOfRooms INT,
    CustomerId INT,
    ContactInformation NVARCHAR(255),
    PaymentStatus NVARCHAR(50),
    FOREIGN KEY (RoomId) REFERENCES Room(RoomId),
    FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId)
);

-- Tạo bảng cho BookingHistory
CREATE TABLE BookingHistory (
    BookingHistoryId INT PRIMARY KEY IDENTITY(1,1),
    ReservationId INT,
    BookingTime DATETIME NOT NULL,
    TotalPrice DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (ReservationId) REFERENCES Reservation(ReservationId)
);
