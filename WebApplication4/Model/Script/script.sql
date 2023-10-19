CREATE TABLE IF NOT EXISTS `person` (
    `id` BIGINT(20) NOT NULL AUTO_INCREMENT,
    `first_name` VARCHAR(80) NOT NULL,
    `last_name` VARCHAR(80) NOT NULL,
    `description` VARCHAR(80) NOT NULL,
    PRIMARY KEY (`id`)
);
