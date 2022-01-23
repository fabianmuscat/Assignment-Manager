USE master;
GO

CREATE DATABASE Assignments;
GO

USE Assignments;
GO

CREATE TABLE dbo.Course (
    [CourseID] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT as_co_pk PRIMARY KEY
        DEFAULT NEWID(),
    [CourseName] NVARCHAR(50) NOT NULL
        CONSTRAINT as_co_na_un UNIQUE,
    [EnrollmentYear] NUMERIC(4,0) NOT NULL,
    [FinalYear] NUMERIC(4,0) NOT NULL
);
GO

CREATE TABLE dbo.Module (
    [ModuleID] NVARCHAR(30) NOT NULL
        CONSTRAINT as_mo_pk PRIMARY KEY,
    [ModuleName] NVARCHAR(50) NOT NULL
        CONSTRAINT as_mo_na_un UNIQUE,
    [SemesterNumber] TINYINT NOT NULL,
    [CourseID] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT as_mo_co_fk FOREIGN KEY REFERENCES dbo.Course(CourseID)
);
GO

CREATE TABLE dbo.Student (
    [StudentID] NVARCHAR(8) NOT NULL
        CONSTRAINT as_st_pk PRIMARY KEY,
    [FirstName] NVARCHAR(30) NOT NULL,
    [LastName] NVARCHAR(30) NOT NULL,
    [SchoolEmail] NVARCHAR(255) NOT NULL
        CONSTRAINT as_st_em_un UNIQUE,
    [CourseID] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT as_st_co_fk FOREIGN KEY REFERENCES dbo.Course(CourseID)
);
GO

CREATE TABLE dbo.Grades (
    [Grade] NVARCHAR(2) NOT NULL
        CONSTRAINT as_gr_pk PRIMARY KEY,
    [MinimumMark] TINYINT NOT NULL,
    [MaximumMark] TINYINT NOT NULL
);
GO

CREATE TABLE dbo.Type (
    [TypeID] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT as_ty_pk PRIMARY KEY
        DEFAULT NEWID(),
    [AssignmentType] NVARCHAR(20) NOT NULL
        CONSTRAINT as_ty_un UNIQUE
);
GO

CREATE TABLE dbo.Assignment (
    [AssignmentID] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT as_as_pk PRIMARY KEY
        DEFAULT NEWID(),
    [AssignmentName] NVARCHAR(100) NOT NULL
        CONSTRAINT as_na_un UNIQUE,
    [ModuleID] NVARCHAR(30) NOT NULL
        CONSTRAINT as_as_mo_fk FOREIGN KEY REFERENCES dbo.Module(ModuleID),
    [MaxMark] TINYINT NOT NULL,
    [DateIssued] DATE NOT NULL,
    [DeadlineDate] DATE NOT NULL,
    [TypeID] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT as_as_ry_fk FOREIGN KEY REFERENCES dbo.Type(TypeID)
);
GO

CREATE TABLE dbo.StudentAssignment (
    [StudentID] NVARCHAR(8) NOT NULL
        CONSTRAINT as_stAs_st_fk FOREIGN KEY REFERENCES dbo.Student(StudentID),
    [AssignmentID] UNIQUEIDENTIFIER NOT NULL
        CONSTRAINT as_stAs_mo_fk FOREIGN KEY REFERENCES dbo.Assignment(AssignmentID),
    
    [Points] TINYINT NOT NULL,

    CONSTRAINT as_stAs_st_as_comp_pk PRIMARY KEY (StudentID, AssignmentID)
);
GO