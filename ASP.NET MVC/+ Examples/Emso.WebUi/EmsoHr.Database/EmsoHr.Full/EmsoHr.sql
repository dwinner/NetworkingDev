USE EmsoHr
GO

/*******************************************
 * EmsoHr CREATE TABLE OPERATORS
 *******************************************/

IF EXISTS (
       SELECT *
       FROM   INFORMATION_SCHEMA.TABLES
       WHERE  TABLE_NAME = 'JobVacancyWorkingConditions'
   )
    DROP TABLE JobVacancyWorkingConditions
    GO
IF EXISTS (
       SELECT *
       FROM   INFORMATION_SCHEMA.TABLES
       WHERE  TABLE_NAME = 'JobVacancyRestRequirements'
   )
    DROP TABLE JobVacancyRestRequirements
    GO
IF EXISTS (
       SELECT *
       FROM   INFORMATION_SCHEMA.TABLES
       WHERE  TABLE_NAME = 'JobVacancyRequirements'
   )
    DROP TABLE JobVacancyRequirements
GO
IF EXISTS (
       SELECT *
       FROM   INFORMATION_SCHEMA.TABLES
       WHERE  TABLE_NAME = 'JobVacancyMisc'
   )
    DROP TABLE JobVacancyMisc
GO
IF EXISTS (
       SELECT *
       FROM   INFORMATION_SCHEMA.TABLES
       WHERE  TABLE_NAME = 'JobVacancyMainResponsibilities'
   )
    DROP TABLE JobVacancyMainResponsibilities
GO
IF EXISTS (
       SELECT *
       FROM   INFORMATION_SCHEMA.TABLES
       WHERE  TABLE_NAME = 'JobVacancy'
   )
    DROP TABLE JobVacancy
GO
IF EXISTS (
       SELECT *
       FROM   INFORMATION_SCHEMA.TABLES
       WHERE  TABLE_NAME = 'NewsFeed'
   )
    DROP TABLE NewsFeed
    GO
IF EXISTS (
       SELECT *
       FROM   INFORMATION_SCHEMA.TABLES
       WHERE  TABLE_NAME = 'SpontaneousResume'
   )
    DROP TABLE SpontaneousResume
    GO

CREATE TABLE JobVacancy
(
	JobId              INT IDENTITY(1, 1) NOT NULL,
	JobTitle           NVARCHAR(256) NOT NULL,
	LocationCity       NVARCHAR(64) NOT NULL DEFAULT('вѓыр'),
	SalaryLevel        MONEY NOT NULL DEFAULT 50000,
	WorkExperience     CHAR(24) NOT NULL DEFAULT 'LessThanOne',
	EmploymentType     CHAR(8) NOT NULL DEFAULT 'Full',
	IsActive           BIT NOT NULL DEFAULT 1,
	CONSTRAINT PK_JobVacancy_JobId PRIMARY KEY(JobId),
	CONSTRAINT JobVacancy_JobTitle_UNIQUE UNIQUE(JobTitle)
)
GO
CREATE TABLE JobVacancyMainResponsibilities
(
	Id                     INT IDENTITY(1, 1) NOT NULL,
	JobId                  INT NULL,
	ResponsibilityItem     NVARCHAR(256) NOT NULL DEFAULT '',
	CONSTRAINT PK_JobVacancyMainResponsibilities_Id PRIMARY KEY(Id)
)
GO
CREATE TABLE JobVacancyMisc
(
	Id           INT IDENTITY(1, 1) NOT NULL,
	JobId        INT NULL,
	MiscItem     NVARCHAR(256) NULL,
	CONSTRAINT PK_JobVacancyMisc_Id PRIMARY KEY(Id)
)
GO
CREATE TABLE JobVacancyRequirements
(
	Id                  INT IDENTITY(1, 1) NOT NULL,
	JobId               INT NULL,
	RequirementItem     NVARCHAR(256) NOT NULL DEFAULT '',
	CONSTRAINT PK_JobVacancyRequirements_Id PRIMARY KEY(Id)
)
GO
CREATE TABLE JobVacancyRestRequirements
(
	Id                  INT IDENTITY(1, 1) NOT NULL,
	JobId               INT NULL,
	MiscRequirement     NVARCHAR(256) NOT NULL DEFAULT '',
	CONSTRAINT PK_JobVacancyRestRequirements_Id PRIMARY KEY(Id)
)
GO
CREATE TABLE JobVacancyWorkingConditions
(
	Id                INT IDENTITY(1, 1) NOT NULL,
	JobId             INT NULL,
	ConditionItem     NVARCHAR(256) NOT NULL,
	CONSTRAINT PK_JobVacancyWorkingConditions_Id PRIMARY KEY(Id)
)
GO
CREATE TABLE NewsFeed
(
	Id                INT IDENTITY(1, 1) NOT NULL,
	Title             NVARCHAR(64) NOT NULL,
	Details           NTEXT NOT NULL,
	NewsDate          DATETIME2(7) NOT NULL DEFAULT GETDATE(),
	RelatedLink       VARCHAR(1024) NULL,
	ImageData         VARBINARY(MAX) NULL,
	ImageMimeType     VARCHAR(64) NULL,
	CONSTRAINT PK_NewsFeed_Id PRIMARY KEY(Id)
)
GO
CREATE TABLE SpontaneousResume
(
	Id             INT IDENTITY(1, 1) NOT NULL,
	SessionId      VARCHAR(32) NOT NULL,
	[File]         VARBINARY(MAX) NOT NULL,
	[FileName]     NVARCHAR(256) NOT NULL,
	FileSize       DECIMAL(18, 0) NOT NULL,
	FileType       CHAR(3) NOT NULL,
	CONSTRAINT PK_SpontaneousResume_Id PRIMARY KEY(Id)
)
GO

/*******************************************
 * ALTER TABLE OPERATORS
 *******************************************/
ALTER TABLE JobVacancyMainResponsibilities  
WITH CHECK ADD CONSTRAINT FK_JobVacancyMainResponsibilities_JobId_JobVacancy FOREIGN KEY(JobId)
     REFERENCES JobVacancy(JobId)
     ON

UPDATE CASCADE
       ON

DELETE CASCADE
GO

ALTER TABLE JobVacancyMainResponsibilities CHECK CONSTRAINT FK_JobVacancyMainResponsibilities_JobId_JobVacancy
GO

ALTER TABLE JobVacancyMisc  
WITH CHECK ADD CONSTRAINT FK_JobVacancyMisc_JobId_JobVacancy FOREIGN KEY(JobId)
     REFERENCES JobVacancy(JobId)
     ON

UPDATE CASCADE
       ON

DELETE CASCADE
GO

ALTER TABLE JobVacancyMisc CHECK CONSTRAINT FK_JobVacancyMisc_JobId_JobVacancy
GO

ALTER TABLE JobVacancyRequirements  
WITH CHECK ADD CONSTRAINT FK_JobVacancyRequirements_JobId_JobVacancy FOREIGN KEY(JobId)
     REFERENCES JobVacancy(JobId)
     ON

UPDATE CASCADE
       ON

DELETE CASCADE
GO

ALTER TABLE JobVacancyRequirements CHECK CONSTRAINT FK_JobVacancyRequirements_JobId_JobVacancy
GO

ALTER TABLE JobVacancyRestRequirements  
WITH CHECK ADD CONSTRAINT FK_JobVacancyRestRequirements_JobId_JobVacancy FOREIGN KEY(JobId)
     REFERENCES JobVacancy(JobId)
     ON

UPDATE CASCADE
       ON

DELETE CASCADE
GO

ALTER TABLE JobVacancyRestRequirements CHECK CONSTRAINT FK_JobVacancyRestRequirements_JobId_JobVacancy
GO

ALTER TABLE JobVacancyWorkingConditions  
WITH CHECK ADD CONSTRAINT FK_JobVacancyWorkingConditions_JobId_JobVacancy FOREIGN KEY(JobId)
     REFERENCES JobVacancy(JobId)
     ON

UPDATE CASCADE
       ON

DELETE CASCADE
GO

ALTER TABLE JobVacancyWorkingConditions CHECK CONSTRAINT FK_JobVacancyWorkingConditions_JobId_JobVacancy
GO

ALTER TABLE JobVacancy  
WITH CHECK ADD CONSTRAINT ENUM_JobVacancy_EmploymentType CHECK(EmploymentType IN ('Remote', 'Flexible', 'Part', 'Full'))
GO

ALTER TABLE JobVacancy CHECK CONSTRAINT ENUM_JobVacancy_EmploymentType
GO

ALTER TABLE JobVacancy  
WITH CHECK ADD CONSTRAINT ENUM_JobVacancy_WorkExperience CHECK(
         WorkExperience IN ('MoreThanSix', 'MoreThanThreeLessThanSix', 'MoreThanOneLessThanThree', 'LessThanOne')
     )
GO

ALTER TABLE JobVacancy CHECK CONSTRAINT ENUM_JobVacancy_WorkExperience
GO

ALTER TABLE SpontaneousResume  
WITH CHECK ADD CONSTRAINT ENUM_SpontaneousResume_FileType CHECK(FileType IN ('Zip', 'Pdf'))
GO

ALTER TABLE SpontaneousResume CHECK CONSTRAINT ENUM_SpontaneousResume_FileType
GO
