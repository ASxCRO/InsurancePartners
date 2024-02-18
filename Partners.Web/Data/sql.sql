--docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=P@ssw0rd" -p 1433:1433 --name sql_server_container -d mcr.microsoft.com/mssql/server:latest

CREATE SCHEMA dbo;
-- partners.dbo.Partners definition

-- Drop table

-- DROP TABLE partners.dbo.Partners;

CREATE TABLE partners.dbo.Partners (
Id int IDENTITY(1,1) NOT NULL,
FirstName nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
LastName nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
Address nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
PartnerNumber nvarchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
CroatianPIN nvarchar(11) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
PartnerTypeId int NOT NULL,
CreatedAtUtc datetime DEFAULT getutcdate() NOT NULL,
CreateByUser nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
IsForeign bit NOT NULL,
ExternalCode nvarchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
Gender char(1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
CONSTRAINT PK__Partners__3214EC07282236F7 PRIMARY KEY (Id),
CONSTRAINT UQ__Partners__A93D26345D8FD434 UNIQUE (ExternalCode)
);


-- partners.dbo.Policies definition

-- Drop table

-- DROP TABLE partners.dbo.Policies;

CREATE TABLE partners.dbo.Policies (
Id int IDENTITY(1,1) NOT NULL,
PartnerId int NULL,
PolicyNumber nvarchar(20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
PolicyAmount decimal(18,2) NOT NULL,
CONSTRAINT PK__Policies__3214EC0726E7EB1D PRIMARY KEY (Id),
CONSTRAINT FK__Policies__Partne__3B75D760 FOREIGN KEY (PartnerId) REFERENCES partners.dbo.Partners(Id)
);