USE Investor;

IF EXISTS (select * from sys.objects where name = 'ClientAddresses' and type = 'u') 
	DROP TABLE [dbo].[ClientAddresses];
IF EXISTS (select * from sys.objects where name = 'Address' and type = 'u') 
	DROP TABLE [dbo].[Address];
IF EXISTS (select * from sys.objects where name = 'Client' and type = 'u') 
	DROP TABLE [dbo].[Client];
IF EXISTS (select * from sys.objects where name = 'Company' and type = 'u') 
	DROP TABLE [dbo].[Company];
IF EXISTS (select * from sys.objects where name = 'Investment' and type = 'u') 
	DROP TABLE [dbo].[Investment];

CREATE TABLE [dbo].[Address] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [Street]      NVARCHAR (MAX) NULL,
    [City]        NVARCHAR (MAX) NULL,
    [Province]    NVARCHAR (MAX) NULL,
    [Postal_Code] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Address] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Client] (
    [Id]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (MAX) NULL,
    [LastName]  NVARCHAR (MAX) NULL,
    [DoB]       DATETIME2 (7)  NULL,
    [SocialIns] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Client] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[ClientAddresses] (
    [ClientId]  BIGINT NOT NULL,
    [AddressId] BIGINT NOT NULL,
    CONSTRAINT [PK_dbo.ClientAddresses] PRIMARY KEY CLUSTERED ([ClientId] ASC, [AddressId] ASC),
    CONSTRAINT [FK_dbo.ClientAddresses_dbo.Client_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.ClientAddresses_dbo.Address_AddressId] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id]) ON DELETE CASCADE
);

CREATE NONCLUSTERED INDEX [IX_ClientId]
    ON [dbo].[ClientAddresses]([ClientId] ASC);

CREATE NONCLUSTERED INDEX [IX_AddressId]
    ON [dbo].[ClientAddresses]([AddressId] ASC);

CREATE TABLE [dbo].[Company] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [CompanyName] NVARCHAR (MAX) NULL,
    [ContactName] NVARCHAR (MAX) NULL,
    [PhoneNumber] NVARCHAR (MAX) NULL,
    [AgentId]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Company] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Investment] (
    [Id]             BIGINT IDENTITY (1, 1) NOT NULL,
	[CompanyId]		 BIGINT NOT NULL,
    [InvestmentType] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Investment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Investment_dbo.Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id]) ON DELETE CASCADE,
);

SET IDENTITY_INSERT [dbo].[Client] ON;
INSERT INTO CLIENT (Id, FirstName, LastName, DoB, SocialIns)
	VALUES (1, 'Joe', 'Smith', '12/15/1993', '111-111-111');
INSERT INTO CLIENT (Id, FirstName, LastName, DoB, SocialIns)
	VALUES (2, 'Sally', 'Jones', '1/23/1987', '222-222-222');
INSERT INTO CLIENT (Id, FirstName, LastName, DoB, SocialIns)
	VALUES (3, 'Rick', 'James', '2/15/1973', '333-333-333');
SET IDENTITY_INSERT [dbo].[Client] OFF;

SET IDENTITY_INSERT [dbo].[Address] ON;
INSERT INTO ADDRESS (Id, Street, City, Province, Postal_Code)
	VALUES (1, '123 Some Street', 'Toronto', 'Ontario', 'N5A2H8');
INSERT INTO ADDRESS (Id, Street, City, Province, Postal_Code)
	VALUES (2, '345 Mill Street', 'Kitchener', 'Ontario', 'M5R3H9');
INSERT INTO ADDRESS (Id, Street, City, Province, Postal_Code)
	VALUES (3, '250 Humber Blvd.', 'Brampton', 'Ontario', 'X5R6H8');
SET IDENTITY_INSERT [dbo].[Address] OFF;

INSERT INTO ClientAddresses (ClientId, AddressId)
	VALUES (1,1);
INSERT INTO ClientAddresses (ClientId, AddressId)
	VALUES (1,2);
INSERT INTO ClientAddresses (ClientId, AddressId)
	VALUES (2,2);
INSERT INTO ClientAddresses (ClientId, AddressId)
	VALUES (3,3);

SET IDENTITY_INSERT [dbo].[Company] ON;
INSERT INTO COMPANY (Id, CompanyName, ContactName, PhoneNumber, AgentId)
	VALUES (1, 'Investors Inc', 'Joe Smith', '416-998-7888 x123', '1234');
INSERT INTO COMPANY (Id, CompanyName, ContactName, PhoneNumber, AgentId)
	VALUES (2, 'Royal Bank', 'Sally Jones', '519-273-1633 x456', 'COMP');
SET IDENTITY_INSERT [dbo].[Company] OFF;


SET IDENTITY_INSERT [dbo].[Investment] ON;
INSERT INTO INVESTMENT (Id, CompanyId, InvestmentType)
	VALUES (1, 1, 'GIC');
SET IDENTITY_INSERT [dbo].[Investment] OFF;
