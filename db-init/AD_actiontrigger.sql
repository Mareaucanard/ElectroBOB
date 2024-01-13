USE `AreaDB`;
 
CREATE TABLE `ActionTrigger`(
	`Id` int AUTO_INCREMENT NOT NULL,
	`Name` Longtext NOT NULL,
	`nbMin` int NOT NULL,
	`NextTrigger` Datetime(6) NOT NULL,
	`AreaId` int NOT NULL,
 CONSTRAINT `PK_ActionTrigger` PRIMARY KEY 
(
	`Id` ASC
) 
) ;

ALTER TABLE `ActionTrigger` ADD  CONSTRAINT `FK_ActionTrigger_Area_AreaId` FOREIGN KEY(`AreaId`)
REFERENCES `Area` (`Id`)
ON DELETE CASCADE;
