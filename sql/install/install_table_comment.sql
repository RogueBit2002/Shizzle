USE `shizzle`;

DROP TABLE IF EXISTS `comment`;

CREATE TABLE `comment` (
    `id` INT unsigned NOT NULL AUTO_INCREMENT,
    `content` TEXT NOT NULL,
    `author_id` INT unsigned NOT NULL,
	`deleted` TINYINT NOT NULL DEFAULT(0), 
    PRIMARY KEY (`id`),
    FOREIGN KEY (`author_id`) REFERENCES `user`(`id`)
);