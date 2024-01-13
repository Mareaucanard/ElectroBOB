USE `AreaDB`;
 
CREATE TABLE `Area`(
	`Id` int AUTO_INCREMENT NOT NULL,
	`Name` Longtext NOT NULL,
	`Description` Longtext NOT NULL,
	`IsActive` Tinyint NOT NULL,
	`UsersId` int NOT NULL,
 CONSTRAINT `PK_Area` PRIMARY KEY 
(
	`Id` ASC
) 
) ;

ALTER TABLE `Area` ADD  CONSTRAINT `FK_Area_Users_UsersId` FOREIGN KEY(`UsersId`)
REFERENCES `Users` (`Id`)
ON DELETE CASCADE;
