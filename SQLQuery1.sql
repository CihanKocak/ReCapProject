CREATE TABLE [dbo].[Cars] (
    [CarId]       INT             IDENTITY(1,1) NOT NULL,
    [BrandId]     INT             NULL,
    [ColorId]     INT             NULL,
    [ModelYear]   VARCHAR (10)    NOT NULL,
    [Description] NTEXT           NOT NULL,
    [DailyPrice]  DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED ([CarId] ASC),
    CONSTRAINT [FK_Cars_Brands] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([BrandId]),
    CONSTRAINT [FK_Cars_Colors] FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([ColorId])
);

CREATE TABLE [dbo].[Brands] (
    [BrandId]   INT          IDENTITY(1,1) NOT NULL,
    [BrandName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED ([BrandId] ASC)
);

CREATE TABLE [dbo].[Colors] (
    [ColorId]   INT          IDENTITY(1,1) NOT NULL,
    [ColorName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED ([ColorId] ASC)
);
