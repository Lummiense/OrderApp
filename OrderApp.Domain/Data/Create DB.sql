CREATE TABLE [Product] (
  [id] nvarchar(50) PRIMARY KEY,
  [Name] nvarchar(35),
  [Price] float
)
GO

CREATE TABLE [User] (
  [id] nvarchar(50) PRIMARY KEY,
  [RoleId] nvarchar(50),
  [Name] nvarchar(35),
  [Login] nvarchar(35),
  [Password] nvarchar(35)
)
GO

CREATE TABLE [Role] (
  [id] nvarchar(50) PRIMARY KEY,
  [Name] nvarchar(35)
)
GO

CREATE TABLE [Order] (
  [id] nvarchar(50) PRIMARY KEY,
  [UserId] nvarchar(50),
  [Order_Date] datetime,
  [Total_Order_Price] float
)
GO

CREATE TABLE [OrderItem] (
  [id] nvarchar(50) PRIMARY KEY,
  [ProductId] nvarchar(50),
  [OrderId] nvarchar(50),
  [Item_Count] int,
  [Price] float
)
GO

ALTER TABLE [User] ADD FOREIGN KEY ([RoleId]) REFERENCES [Role] ([id])
GO

ALTER TABLE [Order] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([id])
GO

ALTER TABLE [OrderItem] ADD FOREIGN KEY ([ProductId]) REFERENCES [Product] ([id])
GO

ALTER TABLE [OrderItem] ADD FOREIGN KEY ([OrderId]) REFERENCES [Order] ([id])
GO
