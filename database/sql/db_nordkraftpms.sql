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
CREATE SCHEMA IF NOT EXISTS `NordkraftPMS` DEFAULT CHARACTER SET utf8 ;
USE `NordkraftPMS` ;


-- -----------------------------------------------------
-- Table `NordkraftPMS`.`users`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `NordkraftPMS`.`users` ;

CREATE TABLE IF NOT EXISTS `NordkraftPMS`.`users` (
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
    REFERENCES `NordkraftPMS`.`institutions` (`id`)
    ON DELETE SET NULL
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = DEFAULT
AUTO_INCREMENT=1;


-- -----------------------------------------------------
-- Table `NordkraftPMS`.`institutions`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `NordkraftPMS`.`institutions` ;

CREATE TABLE IF NOT EXISTS `NordkraftPMS`.`institutions` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(256) NOT NULL,
  `admin` INT,
  PRIMARY KEY (`id`),
  CONSTRAINT `admin`
    FOREIGN KEY (`admin`)
    REFERENCES `NordkraftPMS`.`users` (`id`)
    ON DELETE SET NULL
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = DEFAULT
AUTO_INCREMENT=1;


-- -----------------------------------------------------
-- Table `NordkraftPMS`.`posters`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `NordkraftPMS`.`posters` ;

CREATE TABLE IF NOT EXISTS `NordkraftPMS`.`posters` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(256) NOT NULL,
  `image_url` VARCHAR(256) NOT NULL,
  `created_by` INT,
  PRIMARY KEY (`id`),
  CONSTRAINT `created_by`
    FOREIGN KEY (`created_by`)
    REFERENCES `NordkraftPMS`.`users` (`id`)
    ON DELETE SET NULL
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = DEFAULT
AUTO_INCREMENT=1;


-- -----------------------------------------------------
-- Table `NordkraftPMS`.`zones`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `NordkraftPMS`.`zones` ;

CREATE TABLE IF NOT EXISTS `NordkraftPMS`.`zones` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`id`))
PACK_KEYS = Default
ENGINE = InnoDB
DEFAULT CHARACTER SET = DEFAULT
AUTO_INCREMENT=1;


-- -----------------------------------------------------
-- Table `NordkraftPMS`.`screens`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `NordkraftPMS`.`screens` ;

CREATE TABLE IF NOT EXISTS `NordkraftPMS`.`screens` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(255) NOT NULL,
  `zone` INT,
  PRIMARY KEY (`id`),
  CONSTRAINT `zone`
    FOREIGN KEY (`zone`)
    REFERENCES `NordkraftPMS`.`zones` (`id`)
    ON DELETE SET NULL
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = DEFAULT
AUTO_INCREMENT=1;


-- -----------------------------------------------------
-- Table `NordkraftPMS`.`metadata`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `NordkraftPMS`.`metadata` ;

CREATE TABLE IF NOT EXISTS `NordkraftPMS`.`metadata` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `timer` INT NOT NULL,
  PRIMARY KEY (`id`))
PACK_KEYS = Default
ENGINE = InnoDB
DEFAULT CHARACTER SET = DEFAULT
AUTO_INCREMENT=1;

-- -----------------------------------------------------
-- Table `NordkraftPMS`.`schedules`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `NordkraftPMS`.`schedules` ;

CREATE TABLE IF NOT EXISTS `NordkraftPMS`.`schedules` (
    `id` INT NOT NULL AUTO_INCREMENT,
    `poster_id` INT,
    `name` VARCHAR(255) NOT NULL,
    `start_date` DATETIME NOT NULL,
    `end_date` DATETIME NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `poster_id`
    FOREIGN KEY (`poster_id`)
    REFERENCES `NordkraftPMS`.`posters` (`id`)
    ON DELETE SET NULL
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = DEFAULT
AUTO_INCREMENT=1;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;