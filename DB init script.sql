CREATE TABLE [Product] (
  [id] nvarchar(50) PRIMARY KEY,
  [Name] nvarchar(35),
  [Price] float
)
GO

CREATE TABLE [User] (
  [id] nvarchar(50) PRIMARY KEY,
  [RoleId] nvarchar(50) NOT NULL,
  [Name] nvarchar(35),
  [Login] nvarchar(35) NOT NULL,
  [Password] nvarchar(35) NOT NULL
)
GO

CREATE TABLE [Role] (
  [id] nvarchar(50) PRIMARY KEY,
  [Name] nvarchar(35) NOT NULL
)
GO

CREATE TABLE [Order] (
  [id] nvarchar(50) PRIMARY KEY,
  [UserId] nvarchar(50) NOT NULL,
  [Order_Date] datetime,
  [Total_Order_Price] float
)
GO

CREATE TABLE [OrderItem] (
  [id] nvarchar(50) PRIMARY KEY,
  [ProductId] nvarchar(50) NOT NULL,
  [OrderId] nvarchar(50) NOT NULL,
  [Item_Count] int,
  [Price] float
)
GO

ALTER TABLE [User] ADD FOREIGN KEY ([RoleId]) REFERENCES [Role] ([id]) ON DELETE CASCADE
GO

ALTER TABLE [Order] ADD FOREIGN KEY ([UserId]) REFERENCES [User] ([id]) ON DELETE CASCADE
GO

ALTER TABLE [OrderItem] ADD FOREIGN KEY ([ProductId]) REFERENCES [Product] ([id]) ON DELETE CASCADE
GO

ALTER TABLE [OrderItem] ADD FOREIGN KEY ([OrderId]) REFERENCES [Order] ([id]) ON DELETE CASCADE
GO

INSERT [dbo].[Role] ([Id],[Name]) 
VALUES('58d82a71-762d-4749-8444-dfef3e3287ef','Administrator'),
('d2dc6fd0-3274-4fea-911d-4cb3723c7f1e','Customer')
GO

INSERT [dbo].[User] ([Id],[RoleId],[Name],[Login],[Password]) 
VALUES('b12f998c-875b-48c2-b6d3-d2d470d5ae25','58d82a71-762d-4749-8444-dfef3e3287ef','Mike','admin','admin'),
('4ea6dd1f-59b2-4b27-a586-bbfc4708a65b','d2dc6fd0-3274-4fea-911d-4cb3723c7f1e','Ivan','user1','password'),
('7f36ff02-f0a4-4a6c-b41f-a6af10205f08','d2dc6fd0-3274-4fea-911d-4cb3723c7f1e','July','user2','password')
GO

INSERT INTO [dbo].[Product]([id], [Name], [Price])
VALUES('1c57149a-bf72-4086-a403-cab237e59952','Coffee',330),
('414bb3ed-8a4c-4897-893b-671145a1846a','Tea',280),
('d616a388-2e43-4003-8375-ead5a1ad55fd','Icecream', 65.5)
GO