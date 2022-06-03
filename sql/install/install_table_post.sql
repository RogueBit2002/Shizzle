USE `shizzle`;

DROP TABLE IF EXISTS `post`;

CREATE TABLE `post` (
    `id` INT unsigned NOT NULL AUTO_INCREMENT,
    `title` VARCHAR(48) NOT NULL,
    `content` TEXT NOT NULL,
    `date` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `edited` TINYINT DEFAULT(0) NOT NULL,
    `author_id` INT unsigned NOT NULL,
    `group_id` INT unsigned,
    PRIMARY KEY (`id`),
    FOREIGN KEY (`author_id`) REFERENCES `user`(`id`)
);