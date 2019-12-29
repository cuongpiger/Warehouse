CREATE TABLE [dbo].[Brand] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (255) NULL,
    [ImagePath] NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Category] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (255) NULL,
    [ParentId]  INT            NULL,
    [Order]     INT            NULL,
    [ImagePath] NVARCHAR (255) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Category_ToCategory] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Category] ([Id])
);
GO

CREATE TABLE [dbo].[ContactMessage] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (255) NULL,
    [Email]          NVARCHAR (255) NULL,
    [Message]        NVARCHAR (MAX) NULL,
    [SubmitDatetime] DATETIME       NULL,
    [CheckStatus]    BIT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[UserAddress] (
    [UserId]          UNIQUEIDENTIFIER NOT NULL,
    [Fullname]        NVARCHAR (255)   NULL,
    [PhoneNumber]     NVARCHAR (50)    NULL,
    [ShippingAddress] NVARCHAR (255)   NULL,
    [ShippingCity]    NVARCHAR (255)   NULL,
    [ImagePath]       NVARCHAR (255)   NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_UserAddress_ToUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId])
);

CREATE TABLE [dbo].[Product] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [Name]               NVARCHAR (255) NULL,
    [Price]              FLOAT (53)     NULL,
    [OldPrice]           FLOAT (53)     NULL,
    [Description]        NVARCHAR (MAX) NULL,
    [ImagePath]          NVARCHAR (255) NULL,
    [AverageRating]      FLOAT (53)     NULL,
    [EndOfferDatetime]   DATETIME       NULL,
    [CategoryId]         INT            NULL,
    [BrandId]            INT            NULL,
    [Summary]            NVARCHAR (255) NULL,
    [TotalReviews]       INT            NULL,
    [StartOfferDatetime] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Product_ToCategory] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id]),
    CONSTRAINT [FK_Product_ToBrand] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brand] ([Id])
);
GO

CREATE TABLE [dbo].[Review] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Username]       NVARCHAR (MAX) NULL,
    [Rating]         INT            NULL,
    [Subject]        NVARCHAR (MAX) NULL,
    [Comment]        NVARCHAR (MAX) NULL,
    [PostedDatetime] DATETIME       NULL,
    [ProductId]      INT            NULL,
[Approved]       BIT            DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Review_ToProduct] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id])
);
GO

CREATE TABLE [dbo].[OrderStatus] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[Order] (
    [Id]            INT              IDENTITY (1, 1) NOT NULL,
    [UserId]        UNIQUEIDENTIFIER NULL,
    [OrderDatetime] DATETIME         NULL,
    [OrderTotal]    FLOAT (53)       NULL,
    [StatusId]      INT              DEFAULT ((1)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Order_ToUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId]),
    CONSTRAINT [FK_Order_ToStatus] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[OrderStatus] ([Id])
);
GO

CREATE TABLE [dbo].[OrderDetail] (
    [Id]         INT        IDENTITY (1, 1) NOT NULL,
    [ProductId]  INT        NULL,
    [Quantity]   INT        NULL,
    [UnitPrice]  FLOAT (53) NULL,
    [TotalPrice] FLOAT (53) NULL,
    [OrderId]    INT        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderDetail_ToProduct] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]),
    CONSTRAINT [FK_OrderDetail_ToOrder] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id])
);

GO