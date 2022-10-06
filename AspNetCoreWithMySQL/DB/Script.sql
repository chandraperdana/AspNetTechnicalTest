CREATE TABLE TEST_SCHEDULE_TBL (
	ID int AUTO_INCREMENT PRIMARY KEY,
    TITLE varchar(40),
    CATEGORY varchar(20),
    TESTDATE date,
    LOCATION varchar(50),
    DESCRIPTION varchar(100)
);

INSERT INTO TEST_SCHEDULE_TBL (TITLE, CATEGORY, TESTDATE, LOCATION, DESCRIPTION) VALUES('Online Psicotest Interview Phase 1','Online Test','2021-01-01','http://zoom.com/','Lorem ipsum lorem ipsum lorem ipsum.');
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