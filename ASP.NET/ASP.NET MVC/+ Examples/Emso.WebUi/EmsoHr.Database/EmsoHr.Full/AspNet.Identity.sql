/*******************************************
 * ASP.NET Identity backend
 *******************************************/
 
IF EXISTS (
       SELECT *
       FROM   INFORMATION_SCHEMA.TABLES
       WHERE  TABLE_NAME = '__MigrationHistory'
   )
    DROP TABLE __MigrationHistory
GO
IF EXISTS (
       SELECT *
       FROM   INFORMATION_SCHEMA.TABLES
       WHERE  TABLE_NAME = 'AspNetUserRoles'
   )
    DROP TABLE AspNetUserRoles
GO
IF EXISTS (
       SELECT *
       FROM   INFORMATION_SCHEMA.TABLES
       WHERE  TABLE_NAME = 'AspNetRoles'
   )
    DROP TABLE AspNetRoles
GO
IF EXISTS (
       SELECT *
       FROM   INFORMATION_SCHEMA.TABLES
       WHERE  TABLE_NAME = 'AspNetUserClaims'
   )
    DROP TABLE AspNetUserClaims
GO
IF EXISTS (
       SELECT *
       FROM   INFORMATION_SCHEMA.TABLES
       WHERE  TABLE_NAME = 'AspNetUserLogins'
   )
    DROP TABLE AspNetUserLogins
GO
IF EXISTS (
       SELECT *
       FROM   INFORMATION_SCHEMA.TABLES
       WHERE  TABLE_NAME = 'AspNetUsers'
   )
    DROP TABLE AspNetUsers
GO

CREATE TABLE __MigrationHistory
(
	MigrationId        NVARCHAR(150) NOT NULL,
	ContextKey         NVARCHAR(300) NOT NULL,
	Model              VARBINARY(MAX) NOT NULL,
	ProductVersion     NVARCHAR(32) NOT NULL,
	CONSTRAINT PK___MigrationHistory PRIMARY KEY(MigrationId, ContextKey)
)
GO
CREATE TABLE AspNetRoles
(
	Id                NVARCHAR(128) NOT NULL,
	NAME              NVARCHAR(256) NOT NULL,
	Discriminator     NVARCHAR(128) NOT NULL,
	CONSTRAINT PK_AspNetRoles PRIMARY KEY(Id)
)
GO
CREATE TABLE AspNetUserClaims
(
	Id             INT IDENTITY(1, 1) NOT NULL,
	UserId         NVARCHAR(128) NOT NULL,
	ClaimType      NVARCHAR(MAX) NULL,
	ClaimValue     NVARCHAR(MAX) NULL,
	CONSTRAINT PK_AspNetUserClaims PRIMARY KEY(Id)
)
GO
CREATE TABLE AspNetUserLogins
(
	LoginProvider     NVARCHAR(128) NOT NULL,
	ProviderKey       NVARCHAR(128) NOT NULL,
	UserId            NVARCHAR(128) NOT NULL,
	CONSTRAINT PK_AspNetUserLogins PRIMARY KEY(LoginProvider, ProviderKey, UserId)
)
GO
CREATE TABLE AspNetUserRoles
(
	UserId     NVARCHAR(128) NOT NULL,
	RoleId     NVARCHAR(128) NOT NULL,
	CONSTRAINT PK_AspNetUserRoles PRIMARY KEY(UserId, RoleId)
)
GO
CREATE TABLE AspNetUsers
(
	Id                       NVARCHAR(128) NOT NULL,
	Email                    NVARCHAR(256) NULL,
	EmailConfirmed           BIT NOT NULL,
	PasswordHash             NVARCHAR(MAX) NULL,
	SecurityStamp            NVARCHAR(MAX) NULL,
	PhoneNumber              NVARCHAR(MAX) NULL,
	PhoneNumberConfirmed     BIT NOT NULL,
	TwoFactorEnabled         BIT NOT NULL,
	LockoutEndDateUtc        DATETIME NULL,
	LockoutEnabled           BIT NOT NULL,
	AccessFailedCount        INT NOT NULL,
	UserName                 NVARCHAR(256) NOT NULL,
	CONSTRAINT PK_AspNetUsers PRIMARY KEY(Id)
)
GO

/*******************************************
 * ALTER TABLE OPERATORS
 *******************************************/
 
 ALTER TABLE AspNetUserClaims  
WITH CHECK ADD CONSTRAINT FK_AspNetUserClaims_AspNetUsers_UserId FOREIGN KEY(UserId)
     REFERENCES AspNetUsers(Id)
     ON

DELETE CASCADE
GO

ALTER TABLE AspNetUserClaims CHECK CONSTRAINT FK_AspNetUserClaims_AspNetUsers_UserId
GO

ALTER TABLE AspNetUserLogins  
WITH CHECK ADD CONSTRAINT FK_AspNetUserLogins_AspNetUsers_UserId FOREIGN KEY(UserId)
     REFERENCES AspNetUsers(Id)
     ON

DELETE CASCADE
GO

ALTER TABLE AspNetUserLogins CHECK CONSTRAINT FK_AspNetUserLogins_AspNetUsers_UserId
GO

ALTER TABLE AspNetUserRoles  
WITH CHECK ADD CONSTRAINT FK_AspNetUserRoles_AspNetRoles_RoleId FOREIGN KEY(RoleId)
     REFERENCES AspNetRoles(Id)
     ON

DELETE CASCADE     
GO

ALTER TABLE AspNetUserRoles CHECK CONSTRAINT FK_AspNetUserRoles_AspNetRoles_RoleId
GO

ALTER TABLE AspNetUserRoles  
WITH CHECK ADD CONSTRAINT FK_AspNetUserRoles_AspNetUsers_UserId FOREIGN KEY(UserId)
     REFERENCES AspNetUsers(Id)
     ON

DELETE CASCADE
GO

ALTER TABLE AspNetUserRoles CHECK CONSTRAINT FK_AspNetUserRoles_AspNetUsers_UserId
GO