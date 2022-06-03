USE `shizzle`;

DROP TABLE IF EXISTS `group_admin_link`;

CREATE TABLE `group_admin_link` (
    `group_id` INT unsigned NOT NULL,
    `admin_id` INT unsigned NOT NULL,
    FOREIGN KEY (`group_id`) REFERENCES `group`(`id`),
	FOREIGN KEY (`admin_id`) REFERENCES `user`(`id`)
);