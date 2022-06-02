DROP DATABASE IF EXISTS `shizzle`;

CREATE DATABASE `shizzle`;

source install/install_table_user.sql;
source install/install_table_post.sql;
source install/install_table_group.sql;
source install/install_table_comment.sql;

source install/install_user_root.sql;