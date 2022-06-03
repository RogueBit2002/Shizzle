USE `shizzle`;

DROP TABLE IF EXISTS `group_member_link`;

CREATE TABLE `group_member_link` (
    `group_id` INT unsigned NOT NULL,
    `member_id` INT unsigned NOT NULL,
    FOREIGN KEY (`group_id`) REFERENCES `group`(`id`),
	FOREIGN KEY (`member_id`) REFERENCES `user`(`id`)
);