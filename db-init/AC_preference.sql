USE `AreaDB`;

CREATE TABLE `Preference`(
	`Id` int AUTO_INCREMENT NOT NULL,
	`UserId` int NOT NULL,
	`ActiveNotifications` Tinyint NOT NULL,
	`ActiveEmail` Tinyint NOT NULL,
	`ActiveSMS` Tinyint NOT NULL,
 CONSTRAINT `PK_Preference` PRIMARY KEY 
(
	`Id` ASC
) 
);

ALTER TABLE `Preference` ADD  CONSTRAINT `FK_Preference_Users_UserId` FOREIGN KEY(`UserId`)
REFERENCES `Users` (`Id`)
ON DELETE CASCADE;
