USE `shizzle`;

DROP TABLE IF EXISTS `group`;

CREATE TABLE `group` (
    `id` INT unsigned NOT NULL AUTO_INCREMENT,
    `name` VARCHAR(24) NOT NULL,
	`description` VARCHAR(128) NOT NULL,
    `owner_id` INT unsigned NOT NULL,
	`deleted` TINYINT NOT NULL DEFAULT(0), 
    PRIMARY KEY (`id`),
    FOREIGN KEY (`owner_id`) REFERENCES `user`(`id`),
    UNIQUE (`name`)
);