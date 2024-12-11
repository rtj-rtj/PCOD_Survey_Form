CREATE DATABASE PCODSurvey
CREATE TABLE Questiontable (
    questionid int PRIMARY KEY,
    questionno int ,
    questionname varchar(255),
);

INSERT INTO Questiontable (questionid, questionno, questionname)
VALUES (1,1,'I experience irregular menstrual cycles.'),
(2,2,'I often notice symptoms like excessive hair growth or hair loss.'),
(3,3,'I feel fatigued or have low energy levels frequently.'),
(4,4,'I struggle with maintaining or losing weight despite efforts.'),
(5,5,'I have experienced skin issues such as acne or dark patches.'),
(6,6,'I believe regular exercise and a balanced diet can help manage PCOD symptoms.'),
(7,7,'I feel confident discussing my PCOD symptoms with a healthcare provider.');

CREATE TABLE Optiontable(
optionid int PRIMARY KEY,
optionvalue varchar(255),
optionname varchar(255),
);

INSERT INTO Optiontable (optionid, optionvalue, optionname)
VALUES (1,5,'Strongly Agree'),
(2,4,'Agree'),
(3,3,'Netural'),
(4,2,'Disagree'),
(5,1,'Strongly Disagree');

SELECT * from Questiontable;
SELECT * from Optiontable;

CREATE TABLE UserSurveyResults (
    userSurveyResultID INT PRIMARY KEY IDENTITY(1,1),
    userID INT,  -- If you are tracking users, or use a GUID if anonymous
    surveyDate DATE DEFAULT GETDATE(),
    totalScore INT

CREATE TABLE UserResDetails (
userresdetailsid INT primary key,
questionid INT FOREIGN KEY  REFERENCES Questiontable (questionid),
optionid INT FOREIGN KEY  REFERENCES Optiontable (optionid)
);