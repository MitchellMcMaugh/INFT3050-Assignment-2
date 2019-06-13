-- SQL For INFT3050 Assignment 1
-- Created by Mitchell McMaugh, c3185423
-- 13/08/2016

-- Drop statements are for testing SQL code when developing. Should be commented out or removed in actual use.

-- CREATE THINGS HERE
--DROP DATABASE INFT3050MitchellMcMaugh3185423;
CREATE DATABASE INFT3050MitchellMcMaugh3185423;

--DROP TABLE Users;
CREATE TABLE Users
(
userId char(8),
email varchar(50),
userLogin varchar(20),
userPassword varchar(30),
firstName varchar(30),
lastName varchar(30),
dateOfBirth date,
PRIMARY KEY (userId)
);

--DROP TABLE Characters;
CREATE TABLE Characters
(
characterId char(8),
characterName varchar(50),
characterType varchar(30),
characterBaseHealth int,
characterBaseAttack int,
PRIMARY KEY (characterId)
);

--DROP TABLE UserCharacters;
CREATE TABLE UserCharacters
(
userCharacterId char(8),
userId char(8),
dateCreated date,
characterId char(8),
userCharacterLevel int,
userCharacterName varchar(30),
currentHealth int,
PRIMARY KEY (userCharacterId),
FOREIGN KEY (userId) REFERENCES Users(userId),
FOREIGN KEY (characterId) REFERENCES  Characters(characterId)
);

--DROP TABLE UserExercise;
CREATE TABLE UserExercise
(
userId char(8),
dateOfExercise date,
steps int,
PRIMARY KEY (userId, dateOfExercise),

);

--DROP TABLE Battles;
CREATE TABLE Battles
(
battleId char(8),
dateOfBattle date,
userOneCharacterId char(8),
userTwoCharacterId char(8),
winnerOfBattle char(8),
PRIMARY KEY (battleId),
FOREIGN KEY (userOneCharacterId) REFERENCES UserCharacters(userCharacterId),
FOREIGN KEY (userTwoCharacterId) REFERENCES UserCharacters(userCharacterId)
);

--DROP TABLE HallOfFame;
CREATE TABLE HallOfFame
(
userCharacterId char(8),
dateEntered date,
PRIMARY KEY (userCharacterId)
);

-- INSERT THINGS HERE

INSERT INTO Users(userId, email, userLogin, userPassword, firstName, lastName, dateOfBirth)
VALUES
('U1612688', 'Nunc.mauris@laciniaSedcongue.net', 'Nullam', 'utah', 'Kimberley', 'Bennett', '08-02-1990'),
('U9185119', 'fermentum.fermentum@musProin.org', 'justo', 'quis', 'Kelsie', 'Terry', '06-06-1924'),
('U9115837', 'Quisque.ornare.tortor@Duis.org', 'posuere', 'sed', 'Joelle', 'Cobb', '06-04-1922'),
('U2320304', 'Suspendisse.ac@Praesent.net', 'fringilla', 'nisl', 'Brynn', 'Crawford', '07-02-1928'),
('U1862035', 'odio.Aliquam@rhoncusDonec.co.uk', 'egestas', 'fermentum', 'Nichole', 'Nunez', '10-03-1918');

INSERT INTO Characters (characterId, characterName, characterType, characterBaseHealth, characterBaseAttack)
VALUES
('M0000001', 'Didgeridoomon', 'Fairy', '220', '220'),
('M0000002', 'Flyogre', 'Ogre', '300', '200'),
('M0000003', 'Liprasy', 'Ghost', '150', ' 160'),
('M0000004', 'Leprosy', 'Dragon', '250', '200'),
('M0000005', 'Boeing AH-64 Apache Attack Helicopter', 'Electric', '10000', '10000');

INSERT INTO UserCharacters (userCharacterId, userId, dateCreated, characterId, userCharacterLevel, userCharacterName, currentHealth)
VALUES
('C3746728', 'U1612688', '08/07/2016', 'M0000004', '22', 'Ash Ketchum', '3000'),
('C2940735', 'U9185119', '06/06/2013', 'M0000001', '99', 'Peter', '39902'),
('C0000236', 'U9115837', '02/10/2014', 'M0000003', '88', 'Weasel', '15000'),
('C8362780', 'U2320304', '08/12/2006', 'M0000002', '3', 'Shreek', '400'),
('C6363721', 'U1862035', '03/12/2011', 'M0000005', '27', 'Choppy', '27000');

INSERT INTO UserExercise (userId, dateOfExercise, steps)
VALUES
('U1612688', '07/12/2010', '9999'),
('U1612688', '02/05/2010', '3000'),
('U1612688', '12/03/2011', '14000'),
('U2320304', '07/05/2013', '5050'),
('U1862035', '03/07/2008', '3500');

INSERT INTO Battles (battleId, dateOfBattle, userOneCharacterId, userTwoCharacterId, winnerOfBattle)
VALUES
('B3847236', '09/04/2009', 'C3746728', 'C6363721', 'C3746728'),
('B4674893', '10/02/2012', 'C3746728', 'C2940735', 'C2940735'),
('B6465787', '08/17/2012', 'C3746728', 'C8362780', 'C3746728'),
('B4729876', '08/05/2015', 'C0000236', 'C6363721', 'C0000236'),
('B6787646', '10/11/2010', 'C0000236', 'C3746728', 'C3746728');

INSERT INTO HallOfFame (userCharacterId, dateEntered)
VALUES 
--Usually only once a certain level is reached the characters will be entered into the hall of fame. For simplicity and testing's sake they are added without reason.
('C3746728', '08-08-2015'),
('C2940735', '08-08-2015'),
('C0000236', '08-08-2015'),
('C8362780', '08-08-2015'),
('C6363721', '08-08-2015');

