CREATE TABLE [Product] (
  [id] string PRIMARY KEY,
  [Name] string,
  [Price] float
)
GO

CREATE TABLE [User] (
  [id] string PRIMARY KEY,
  [RoleId] string,
  [Name] string,
  [Login] string,
  [Password] string
)
GO

CREATE TABLE [Role] (
  [id] string PRIMARY KEY,
  [Name] string
)
GO

CREATE TABLE [Order] (
  [id] string PRIMARY KEY,
  [UserId] string,
  [Order_Date] string,
  [Total_Order_Price] float
)
GO

CREATE TABLE [OrderItem] (
  [id] string PRIMARY KEY,
  [ProductId] string,
  [OrderId] string,
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
