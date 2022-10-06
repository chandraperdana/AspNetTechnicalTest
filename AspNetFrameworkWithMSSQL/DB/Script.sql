USE [TESTDB]
GO

/****** Object:  Table [dbo].[TEST_SCHEDULE_TBL]    Script Date: 29/07/2021 10:40:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TEST_SCHEDULE_TBL](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TITLE] [varchar](40) NOT NULL,
	[CATEGORY] [varchar](20) NOT NULL,
	[TESTDATE] [date] NOT NULL,
	[LOCATION] [varchar](50) NULL,
	[DESCRIPTION] [varchar](100) NULL,
 CONSTRAINT [PK_TEST_SCHEDULE_TBL] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO test_schedule_tbl (TITLE, CATEGORY, TESTDATE, LOCATION, DESCRIPTION) VALUES('Online Psicotest Interview Phase 1','Online Test','2021-01-01','http://zoom.com/','Lorem ipsum lorem ipsum lorem ipsum.');
INSERT INTO TEST_SCHEDULE_TBL (TITLE, CATEGORY, TESTDATE, LOCATION, DESCRIPTION) VALUES('Online Technical Test Phase 1','Online Test','2021-01-11','http://zoom.com/','Loren ipsum dolor sit amet.');
INSERT INTO TEST_SCHEDULE_TBL (TITLE, CATEGORY, TESTDATE, LOCATION, DESCRIPTION) VALUES('Online Logical Test Phase 1','Online Test','2021-02-06','http://zoom.com/','Lorem ipsum.');
INSERT INTO TEST_SCHEDULE_TBL (TITLE, CATEGORY, TESTDATE, LOCATION, DESCRIPTION) VALUES('Offline Psicotest Interview Phase 1','Offline Test','2021-01-08','PT Berca Hardayaperkasa','Lorem ipsum lorem ipsum lorem ipsum.');
INSERT INTO TEST_SCHEDULE_TBL (TITLE, CATEGORY, TESTDATE, LOCATION, DESCRIPTION) VALUES('Offline Technical Test Phase 1','Offline Test','2021-01-14','PT Berca Hardayaperkasa','Loren ipsum dolor sit amet.');
INSERT INTO TEST_SCHEDULE_TBL (TITLE, CATEGORY, TESTDATE, LOCATION, DESCRIPTION) VALUES('Offline Logical Test Phase 1','Offline Test','2021-02-10','PT Berca Hardayaperkasa','Lorem ipsum.');
INSERT INTO TEST_SCHEDULE_TBL (TITLE, CATEGORY, TESTDATE, LOCATION, DESCRIPTION) VALUES('Online Psicotest Interview Phase 2','Online Test','2021-03-04','http://zoom.com/','Lorem ipsum lorem ipsum lorem ipsum.');
INSERT INTO TEST_SCHEDULE_TBL (TITLE, CATEGORY, TESTDATE, LOCATION, DESCRIPTION) VALUES('Online Technical Test Phase 2','Online Test','2021-03-17','http://zoom.com/','Loren ipsum dolor sit amet.');
INSERT INTO TEST_SCHEDULE_TBL (TITLE, CATEGORY, TESTDATE, LOCATION, DESCRIPTION) VALUES('Online Logical Test Phase 2','Online Test','2021-04-03','http://zoom.com/','Lorem ipsum.');
INSERT INTO TEST_SCHEDULE_TBL (TITLE, CATEGORY, TESTDATE, LOCATION, DESCRIPTION) VALUES('Offline Psicotest Interview Phase 2','Offline Test','2021-03-07','PT Berca Hardayaperkasa','Lorem ipsum lorem ipsum lorem ipsum.');
INSERT INTO TEST_SCHEDULE_TBL (TITLE, CATEGORY, TESTDATE, LOCATION, DESCRIPTION) VALUES('Offline Technical Test Phase 2','Offline Test','2021-03-24','PT Berca Hardayaperkasa','Loren ipsum dolor sit amet.');
INSERT INTO TEST_SCHEDULE_TBL (TITLE, CATEGORY, TESTDATE, LOCATION, DESCRIPTION) VALUES('Offline Logical Test Phase 2','Offline Test','2021-04-26','PT Berca Hardayaperkasa','Lorem ipsum.');
GO
