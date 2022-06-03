USE `shizzle`;

DROP TABLE IF EXISTS `group`;

CREATE TABLE `group` (
    `id` INT unsigned NOT NULL AUTO_INCREMENT,
    `name` VARCHAR(48) NOT NULL,
    `owner_id` INT unsigned NOT NULL,
    PRIMARY KEY (`id`),
    FOREIGN KEY (`owner_id`) REFERENCES `user`(`id`),
    UNIQUE (`name`)
);