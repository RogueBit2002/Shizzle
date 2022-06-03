USE `shizzle`;

DROP TABLE IF EXISTS `comment`;

CREATE TABLE `comment` (
    `id` INT unsigned NOT NULL AUTO_INCREMENT,
    `content` TEXT NOT NULL,
    `author_id` INT unsigned NOT NULL,
    PRIMARY KEY (`id`),
    FOREIGN KEY (`author_id`) REFERENCES `user`(`id`)
);