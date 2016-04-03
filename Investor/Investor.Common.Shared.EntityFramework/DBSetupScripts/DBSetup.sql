USE Investor;

IF EXISTS (select * from sys.objects where name = 'CompanyAddressJoin' and type = 'u') 
	DROP TABLE [dbo].[CompanyAddressJoin];
IF EXISTS (select * from sys.objects where name = 'ClientAddressJoin' and type = 'u') 
	DROP TABLE [dbo].[ClientAddressJoin];

IF EXISTS (select * from sys.objects where name = 'CompanyAddress' and type = 'u') 
	DROP TABLE [dbo].[CompanyAddress];
IF EXISTS (select * from sys.objects where name = 'ClientAddress' and type = 'u') 
	DROP TABLE [dbo].[ClientAddress];

IF EXISTS (select * from sys.objects where name = 'CompanyPhoneNumberJoin' and type = 'u') 
	DROP TABLE [dbo].[CompanyPhoneNumberJoin];
IF EXISTS (select * from sys.objects where name = 'ClientPhoneNumberJoin' and type = 'u') 
	DROP TABLE [dbo].[ClientPhoneNumberJoin];

IF EXISTS (select * from sys.objects where name = 'CompanyPhoneNumber' and type = 'u') 
	DROP TABLE [dbo].[CompanyPhoneNumber];
IF EXISTS (select * from sys.objects where name = 'ClientPhoneNumber' and type = 'u') 
	DROP TABLE [dbo].[ClientPhoneNumber];

IF EXISTS (select * from sys.objects where name = 'InvestmentClient' and type = 'u') 
	DROP TABLE [dbo].[InvestmentClient];
IF EXISTS (select * from sys.objects where name = 'Client' and type = 'u') 
	DROP TABLE [dbo].[Client];
IF EXISTS (select * from sys.objects where name = 'Investment' and type = 'u') 
	DROP TABLE [dbo].[Investment];
IF EXISTS (select * from sys.objects where name = 'Company' and type = 'u') 
	DROP TABLE [dbo].[Company];


CREATE TABLE [dbo].[Client] (
    [Id]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (MAX) NULL,
    [LastName]  NVARCHAR (MAX) NULL,
    [DoB]       DATETIME2 (7)  NULL,
    [SocialIns] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Client] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[ClientAddress](
	[AddressId] [bigint] IDENTITY(1,1) NOT NULL,
	[Street] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Province] [nvarchar](max) NULL,
	[Postal_Code] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.ClientAddress] PRIMARY KEY CLUSTERED 
	(
		[AddressId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	CREATE TABLE [dbo].[ClientAddressJoin](
	[ClientId] [bigint] NOT NULL,
	[AddressId] [bigint] NOT NULL,
	CONSTRAINT [PK_dbo.ClientAddressJoin] PRIMARY KEY CLUSTERED 
	(
		[ClientId] ASC,
		[AddressId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

ALTER TABLE [dbo].[ClientAddressJoin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClientAddressJoin_dbo.Client_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[ClientAddressJoin] CHECK CONSTRAINT [FK_dbo.ClientAddressJoin_dbo.Client_ClientId]

ALTER TABLE [dbo].[ClientAddressJoin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClientAddressJoin_dbo.ClientAddress_AddressId] FOREIGN KEY([AddressId])
REFERENCES [dbo].[ClientAddress] ([AddressId])
ON DELETE CASCADE

ALTER TABLE [dbo].[ClientAddressJoin] CHECK CONSTRAINT [FK_dbo.ClientAddressJoin_dbo.ClientAddress_AddressId]

CREATE TABLE [dbo].[ClientPhoneNumber](
	[PhoneNumberId] [bigint] IDENTITY(1,1) NOT NULL,
	[PhoneNo] [nvarchar](max) NULL,
	[PhoneType] [int] NOT NULL,
	
 CONSTRAINT [PK_dbo.ClientPhoneNumber] PRIMARY KEY CLUSTERED 
	(
		[PhoneNumberId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE TABLE [dbo].[ClientPhoneNumberJoin](
	[ClientId] [bigint] NOT NULL,
	[PhoneNumberId] [bigint] NOT NULL,
	CONSTRAINT [PK_dbo.ClientPhoneNumberJoin] PRIMARY KEY CLUSTERED 
	(
		[ClientId] ASC,
		[PhoneNumberId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

ALTER TABLE [dbo].[ClientPhoneNumberJoin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClientPhoneNumberJoin_dbo.Client_ClientId] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Client] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[ClientPhoneNumberJoin] CHECK CONSTRAINT [FK_dbo.ClientPhoneNumberJoin_dbo.Client_ClientId]

ALTER TABLE [dbo].[ClientPhoneNumberJoin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ClientPhoneNumberJoin_dbo.ClientPhoneNumber_PhoneNumberId] FOREIGN KEY([PhoneNumberId])
REFERENCES [dbo].[ClientPhoneNumber] ([PhoneNumberId])
ON DELETE CASCADE


ALTER TABLE [dbo].[ClientPhoneNumberJoin] CHECK CONSTRAINT [FK_dbo.ClientPhoneNumberJoin_dbo.ClientPhoneNumber_PhoneNumberId]

CREATE TABLE [dbo].[Company] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [CompanyName] NVARCHAR (MAX) NULL,
    [ContactName] NVARCHAR (MAX) NULL,
    [PhoneNumber] NVARCHAR (MAX) NULL,
    [AgentId]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Company] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[CompanyAddress](
	[AddressId] [bigint] IDENTITY(1,1) NOT NULL,
	[Street] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Province] [nvarchar](max) NULL,
	[Postal_Code] [nvarchar](max) NULL,
	CONSTRAINT [PK_dbo.CompanyAddress] PRIMARY KEY CLUSTERED 
	(
		[AddressId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

	CREATE TABLE [dbo].[CompanyAddressJoin](
	[CompanyId] [bigint] NOT NULL,
	[AddressId] [bigint] NOT NULL,
	CONSTRAINT [PK_dbo.CompanyAddressJoin] PRIMARY KEY CLUSTERED 
	(
		[CompanyId] ASC,
		[AddressId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

ALTER TABLE [dbo].[CompanyAddressJoin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CompanyAddressJoin_dbo.Company_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[CompanyAddressJoin] CHECK CONSTRAINT [FK_dbo.CompanyAddressJoin_dbo.Company_CompanyId]

ALTER TABLE [dbo].[CompanyAddressJoin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CompanyAddressJoin_dbo.CompanyAddress_AddressId] FOREIGN KEY([AddressId])
REFERENCES [dbo].[CompanyAddress] ([AddressId])
ON DELETE CASCADE

ALTER TABLE [dbo].[CompanyAddressJoin] CHECK CONSTRAINT [FK_dbo.CompanyAddressJoin_dbo.CompanyAddress_AddressId]

CREATE TABLE [dbo].[CompanyPhoneNumber](
	[PhoneNumberId] [bigint] IDENTITY(1,1) NOT NULL,
	[PhoneNo] [nvarchar](max) NULL,
	[PhoneType] [int] NOT NULL,
	CONSTRAINT [PK_dbo.CompanyPhoneNumber] PRIMARY KEY CLUSTERED 
	(
		[PhoneNumberId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


CREATE TABLE [dbo].[CompanyPhoneNumberJoin](
	[CompanyId] [bigint] NOT NULL,
	[PhoneNumberId] [bigint] NOT NULL,
	CONSTRAINT [PK_dbo.CompanyPhoneNumberJoin] PRIMARY KEY CLUSTERED 
	(
		[CompanyId] ASC,
		[PhoneNumberId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]


ALTER TABLE [dbo].[CompanyPhoneNumberJoin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CompanyPhoneNumberJoin_dbo.Company_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Company] ([Id])
ON DELETE CASCADE

ALTER TABLE [dbo].[CompanyPhoneNumberJoin] CHECK CONSTRAINT [FK_dbo.CompanyPhoneNumberJoin_dbo.Company_CompanyId]

ALTER TABLE [dbo].[CompanyPhoneNumberJoin]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CompanyPhoneNumberJoin_dbo.CompanyPhoneNumber_PhoneNumberId] FOREIGN KEY([PhoneNumberId])
REFERENCES [dbo].[CompanyPhoneNumber] ([PhoneNumberId])
ON DELETE CASCADE

ALTER TABLE [dbo].[CompanyPhoneNumberJoin] CHECK CONSTRAINT [FK_dbo.CompanyPhoneNumberJoin_dbo.CompanyPhoneNumber_PhoneNumberId]


CREATE TABLE [dbo].[Investment] (
    [Id]             BIGINT IDENTITY (1, 1) NOT NULL,
	[CompanyId]		 BIGINT NOT NULL,
    [InvestmentType] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Investment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Investment_dbo.Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[Company] ([Id]) ON DELETE CASCADE,
);

CREATE TABLE [dbo].[InvestmentClient] (
	[ClientId]		BIGINT NOT NULL,
	[InvestmentId]  BIGINT NOT NULL,
	[ClientOrder] 	TINYINT NOT NULL
    CONSTRAINT [PK_dbo.InvestmentClient] PRIMARY KEY CLUSTERED ([ClientId] ASC, [InvestmentId] ASC)
    CONSTRAINT [FK_dbo.InvestmentClient_dbo.Client_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.InvestmentClient_dbo.Invesetment_InvestmentId] FOREIGN KEY ([InvestmentId]) REFERENCES [dbo].[Investment] ([Id]) ON DELETE CASCADE,
);

SET IDENTITY_INSERT [dbo].[Client] ON;
INSERT INTO CLIENT (Id, FirstName, LastName, DoB, SocialIns)
	VALUES (1, 'Joe', 'Smith', '12/15/1993', '111-111-111');
INSERT INTO CLIENT (Id, FirstName, LastName, DoB, SocialIns)
	VALUES (2, 'Sally', 'Jones', '1/23/1987', '222-222-222');
INSERT INTO CLIENT (Id, FirstName, LastName, DoB, SocialIns)
	VALUES (3, 'Rick', 'James', '2/15/1973', '333-333-333');
SET IDENTITY_INSERT [dbo].[Client] OFF;

SET IDENTITY_INSERT [dbo].[ClientAddress] ON;
INSERT INTO ClientAddress (AddressId, Street, City, Province, Postal_Code)
	VALUES (1, '123 Some Street', 'Toronto', 'Ontario', 'N5A2H8');
INSERT INTO ClientAddress (AddressId, Street, City, Province, Postal_Code)
	VALUES (2, '345 Mill Street', 'Kitchener', 'Ontario', 'M5R3H9');
INSERT INTO ClientAddress (AddressId, Street, City, Province, Postal_Code)
	VALUES (3, '250 Humber Blvd.', 'Brampton', 'Ontario', 'X5R6H8');
SET IDENTITY_INSERT [dbo].[ClientAddress] OFF;




INSERT INTO ClientAddressJoin (ClientId, AddressId)
	VALUES (1,1);
INSERT INTO ClientAddressJoin (ClientId, AddressId)
	VALUES (1,2);
INSERT INTO ClientAddressJoin (ClientId, AddressId)
	VALUES (2,2);
INSERT INTO ClientAddressJoin (ClientId, AddressId)
	VALUES (3,3);

	SET IDENTITY_INSERT [dbo].[ClientPhoneNumber] ON;
INSERT INTO ClientPhoneNumber (PhoneNumberId, PhoneNo, PhoneType)
	VALUES (1, '905-908-5566', 3);
INSERT INTO ClientPhoneNumber (PhoneNumberId, PhoneNo, PhoneType)
	VALUES (2, '222-333-4444', 0);
INSERT INTO ClientPhoneNumber (PhoneNumberId, PhoneNo, PhoneType)
	VALUES (3, '888-908-4456', 1);
SET IDENTITY_INSERT [dbo].[ClientPhoneNumber] OFF;

INSERT INTO ClientPhoneNumberJoin (ClientId, PhoneNumberId)
	VALUES (1,1);
INSERT INTO ClientPhoneNumberJoin (ClientId, PhoneNumberId)
	VALUES (1,2);
INSERT INTO ClientPhoneNumberJoin (ClientId, PhoneNumberId)
	VALUES (2,2);
INSERT INTO ClientPhoneNumberJoin (ClientId, PhoneNumberId)
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

INSERT INTO INVESTMENTCLIENT (ClientId, InvestmentId, ClientOrder)
	VALUES (1, 1, 1);

	GO