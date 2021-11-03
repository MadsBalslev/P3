DELETE FROM `database`.`users`;
INSERT INTO `database`.`users` (`id`, `first_name`, `last_name`, `email`, `phone_number`, `institution`, `role`) VALUES ('1', 'Christian', 'Hove', 'k@k.dk', '1', NULL, '3');
INSERT INTO `database`.`users` (`id`, `first_name`, `last_name`, `email`, `phone_number`, `institution`, `role`) VALUES ('2', 'Mads', 'Balslev', 'k@k.dk', '1', NULL, '2');
INSERT INTO `database`.`users` (`id`, `first_name`, `last_name`, `email`, `phone_number`, `institution`, `role`) VALUES ('3', 'Simon', 'Andersen', 'k@k.dk', '1', NULL, '2');

DELETE FROM `database`.`institutions`;
INSERT INTO `database`.`institutions` (`id`, `name`, `admin`) VALUES ('1', 'Nordkraft', '1');
INSERT INTO `database`.`institutions` (`id`, `name`, `admin`) VALUES ('2', 'DGI Huset', '2');
INSERT INTO `database`.`institutions` (`id`, `name`, `admin`) VALUES ('3', 'Azzura', '3');

DELETE FROM `database`.`zones`;
INSERT INTO `database`.`zones` (`id`, `name`) VALUES ('1', 'Indgang');
INSERT INTO `database`.`zones` (`id`, `name`) VALUES ('2', 'Biffen_gang');
INSERT INTO `database`.`zones` (`id`, `name`) VALUES ('3', 'Skråen');

DELETE FROM `database`.`posters`;
INSERT INTO `database`.`posters` (`id`, `name`, `start_date`, `end_date`, `image_url`, `created_by`) VALUES ('1', 'Poster1', '2021-10-26 13:30:45', '2022-10-26 13:30:47', 'ww.gg.dk', '1');
INSERT INTO `database`.`posters` (`id`, `name`, `start_date`, `end_date`, `image_url`, `created_by`) VALUES ('2', 'Poster2', '2021-10-26 13:30:45', '2022-10-26 13:30:47', 'ww.gg.dk', '2');
INSERT INTO `database`.`posters` (`id`, `name`, `start_date`, `end_date`, `image_url`, `created_by`) VALUES ('3', 'Poster3', '2021-10-26 13:30:45', '2022-10-26 13:30:47', 'ww.gg.dk', '3');

DELETE FROM `database`.`screens`;
INSERT INTO `database`.`screens` (`id`, `name`, `zone`) VALUES ('1', 'Screen1', '1');
INSERT INTO `database`.`screens` (`id`, `name`, `zone`) VALUES ('2', 'Screen2', '2');
INSERT INTO `database`.`screens` (`id`, `name`, `zone`) VALUES ('3', 'Screen3', '2');
INSERT INTO `database`.`screens` (`id`, `name`, `zone`) VALUES ('4', 'Screen4', '3');

UPDATE `users` SET `institution` = 1 WHERE `id` = 1;
UPDATE `users` SET `institution` = 2 WHERE `id` = 2;
UPDATE `users` SET `institution` = 3 WHERE `id` = 3;
