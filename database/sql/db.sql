-- MySQL Script generated by MySQL Workbench
-- Tue Oct 26 10:43:11 2021
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema database
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `database` DEFAULT CHARACTER SET utf8 ;
USE `database` ;


-- -----------------------------------------------------
-- Table `database`.`users`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `database`.`users` ;

CREATE TABLE IF NOT EXISTS `database`.`users` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `first_name` VARCHAR(256) NOT NULL,
  `last_name` VARCHAR(256) NOT NULL,
  `email` VARCHAR(256) NOT NULL,
  `password` VARCHAR(256) NOT NULL,
  `phone_number` VARCHAR(256) NOT NULL,
  `institution` INT,
  `role` INT NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `institution`
    FOREIGN KEY (`institution`)
    REFERENCES `database`.`institutions` (`id`)
    ON DELETE SET NULL
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = DEFAULT
AUTO_INCREMENT=1;


-- -----------------------------------------------------
-- Table `database`.`institutions`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `database`.`institutions` ;

CREATE TABLE IF NOT EXISTS `database`.`institutions` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(256) NOT NULL,
  `admin` INT,
  PRIMARY KEY (`id`),
  CONSTRAINT `admin`
    FOREIGN KEY (`admin`)
    REFERENCES `database`.`users` (`id`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = DEFAULT
AUTO_INCREMENT=1;


-- -----------------------------------------------------
-- Table `database`.`posters`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `database`.`posters` ;

CREATE TABLE IF NOT EXISTS `database`.`posters` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(256) NOT NULL,
  `image_url` VARCHAR(256) NOT NULL,
  `institution` INT,
  PRIMARY KEY (`id`),
  CONSTRAINT `institution_id`
    FOREIGN KEY (`institution`)
    REFERENCES `database`.`institutions` (`id`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = DEFAULT
AUTO_INCREMENT=1;


-- -----------------------------------------------------
-- Table `database`.`zones`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `database`.`zones` ;

CREATE TABLE IF NOT EXISTS `database`.`zones` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id`))
PACK_KEYS = Default
ENGINE = InnoDB
DEFAULT CHARACTER SET = DEFAULT
AUTO_INCREMENT=1;

-- -----------------------------------------------------
-- Table `database`.`metadata`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `database`.`metadata` ;

CREATE TABLE IF NOT EXISTS `database`.`metadata` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `timer` INT NOT NULL,
  PRIMARY KEY (`id`))
PACK_KEYS = Default
ENGINE = InnoDB
DEFAULT CHARACTER SET = DEFAULT
AUTO_INCREMENT=1;

-- -----------------------------------------------------
-- Table `database`.`schedules`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `database`.`schedules` ;

CREATE TABLE IF NOT EXISTS `database`.`schedules` (
    `id` INT NOT NULL AUTO_INCREMENT,
    `poster_id` INT,
    `name` VARCHAR(255) NOT NULL,
    `start_date` DATETIME NOT NULL,
    `end_date` DATETIME NOT NULL,
    `zone` INT,
  PRIMARY KEY (`id`),
  CONSTRAINT `poster_id`
    FOREIGN KEY (`poster_id`)
    REFERENCES `database`.`posters` (`id`)
    ON DELETE SET NULL
    ON UPDATE NO ACTION,
  CONSTRAINT `zone`
    FOREIGN KEY (`zone`)
    REFERENCES `database`.`zones` (`id`)
    ON DELETE SET NULL
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = DEFAULT
AUTO_INCREMENT=1;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

INSERT INTO `database`.`users` (`id`, `first_name`, `last_name`, `email`, `password`, `phone_number`, `institution`, `role`)
VALUES (1, 'Admin', 'Adminson', 'admin', '$2a$11$gXTWUmhjbhbjOqzT6AnfVORfPjVXT/w4UQhPXkr3G6vsVs7xQ3a/C', "", null, 3);

INSERT INTO `database`.`institutions` (`id`, `name`, `admin`) VALUES ('1', 'Nordkraft', '1');

UPDATE `users` SET `institution` = 1 WHERE `id` = 1;

INSERT INTO `database`.`metadata` (`id`, `timer`) VALUES ('1', '5000');

INSERT INTO `database`.`zones` (`id`, `name`) VALUES ('1', 'Nordkraft');