USE Investor;

DROP TABLE [dbo].[ClientAddresses];
DROP TABLE [dbo].[Address];
DROP TABLE [dbo].[Client];
DROP TABLE [dbo].[Company];
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

GO
CREATE NONCLUSTERED INDEX [IX_ClientId]
    ON [dbo].[ClientAddresses]([ClientId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_AddressId]
    ON [dbo].[ClientAddresses]([AddressId] ASC);

CREATE TABLE [dbo].[Company] (
    [Id]          BIGINT         IDENTITY (1, 1) NOT NULL,
    [CompanyName] NVARCHAR (MAX) NULL,
    [ContactName] NVARCHAR (MAX) NULL,
    [PhoneNumber] BIGINT         NOT NULL,
    [AgentID]     BIGINT         NOT NULL,
    CONSTRAINT [PK_dbo.Company] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Investment] (
    [Id]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [InvestmentType] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Investment] PRIMARY KEY CLUSTERED ([Id] ASC)
);

