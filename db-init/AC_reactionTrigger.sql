USE `AreaDB`;

CREATE TABLE `ReactionTrigger`(
	`Id` int AUTO_INCREMENT NOT NULL,
	`Name` Longtext NOT NULL,
	`From` Longtext NOT NULL,
	`To` Longtext NOT NULL,
	`Message` Longtext NOT NULL,
	`AreaId` int NOT NULL,
 CONSTRAINT `PK_ReactionTrigger` PRIMARY KEY 
(
	`Id` ASC
) 
) ;

ALTER TABLE `ReactionTrigger` ADD  CONSTRAINT `FK_ReactionTrigger_Area_AreaId` FOREIGN KEY(`AreaId`)
REFERENCES `Area` (`Id`)
ON DELETE CASCADE;
