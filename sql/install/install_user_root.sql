DROP USER IF EXISTS 'shizzleRoot'@'localhost';

CREATE USER 'shizzleRoot'@'localhost' IDENTIFIED WITH mysql_native_password BY 'r00t';

GRANT ALL PRIVILEGES ON `shizzle`.* TO 'shizzleRoot'@'localhost';