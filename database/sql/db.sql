-- ----------------------------
-- Table structure for `posters`
-- ----------------------------
DROP TABLE IF EXISTS `posters`;
CREATE TABLE `posters` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(999) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  `image_url` varchar(999) NOT NULL,
  'created_by' int NOT NULL,
  PRIMARY KEY(`id`),
  FOREIGN KEY('created_by') REFERENCES users('id')
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET utf8;

-- ----------------------------
-- Table structure for `users`
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(999) NOT NULL,
  `last_name` varchar(999) NOT NULL,
  `email` varchar(999) NOT NULL,
  `phone_number` int(255) NOT NULL,
  `institution` int NOT NULL,
  `role` int(5) NOT NULL,
  PRIMARY KEY (`id`),
  FOREIGN KEY ('institution') REFERENCES institutions('id')
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for `institutions`
-- ----------------------------
DROP TABLE IF EXISTS `institutions`;
CREATE TABLE `institutions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(999) NOT NULL,
  `admin_name` int NOT NULL,
  PRIMARY KEY (`id`),
  FOREIGN KEY ('admin_name') REFERENCES users('id')
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for `zones`
-- ----------------------------
DROP TABLE IF EXISTS `zones`;
CREATE TABLE `zones` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(999) NOT NULL, 
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for `screens`
-- ----------------------------
DROP TABLE IF EXISTS `screens`;
CREATE TABLE `screens` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(999) NOT NULL, 
  `zone` int NOT NULL,
  PRIMARY KEY (`id`),
  FOREIGN KEY ('zone') REFERENCES zones('id')
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;
