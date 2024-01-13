USE `AreaDB`;
 
CREATE TABLE `Users`(
	`Id` int AUTO_INCREMENT NOT NULL,
	`Login` Longtext NOT NULL,
	`Password` Longtext NOT NULL,
	`Salt` Longtext NOT NULL DEFAULT '',
 CONSTRAINT `PK_Users` PRIMARY KEY 
(
	`Id` ASC
) 
) ;
