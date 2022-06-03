USE `shizzle`;

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
    `id` INT unsigned NOT NULL AUTO_INCREMENT,
    `name` VARCHAR(24) NOT NULL,
    `email` VARCHAR(32) NOT NULL,
    `password` VARCHAR(64) NOT NULL,
    `biography` TEXT CHARACTER SET utf32 COLLATE utf32_unicode_520_ci,
    PRIMARY KEY (`id`),
    UNIQUE KEY `id` (`name`,`email`)
);