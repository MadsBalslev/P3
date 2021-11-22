DELETE FROM `NordkraftPMS`.`users`;
INSERT INTO `NordkraftPMS`.`users` (`id`, `first_name`, `last_name`, `email`, `password`, `phone_number`, `institution`, `role`)
VALUES (1, 'Christian', 'Hove', 'k@k.dk', 'testpw', 1, NULL, 3);
INSERT INTO `NordkraftPMS`.`users` (`id`, `first_name`, `last_name`, `email`, `password`, `phone_number`, `institution`, `role`)
VALUES (2, 'Mads', 'Balslev', 'k@k.dk', 'testpw', 1, NULL, 2);
INSERT INTO `NordkraftPMS`.`users` (`id`, `first_name`, `last_name`, `email`, `password`, `phone_number`, `institution`, `role`)
VALUES (3, 'Simon', 'Andersen', 'k@k.dk', 'testpw', 1, NULL, 2);

DELETE FROM `NordkraftPMS`.`institutions`;
INSERT INTO `NordkraftPMS`.`institutions` (`id`, `name`, `admin`) VALUES ('1', 'Nordkraft', '1');
INSERT INTO `NordkraftPMS`.`institutions` (`id`, `name`, `admin`) VALUES ('2', 'DGI Huset', '2');
INSERT INTO `NordkraftPMS`.`institutions` (`id`, `name`, `admin`) VALUES ('3', 'Azzura', '3');

DELETE FROM `NordkraftPMS`.`zones`;
INSERT INTO `NordkraftPMS`.`zones` (`id`, `name`) VALUES ('1', 'Indgang');
INSERT INTO `NordkraftPMS`.`zones` (`id`, `name`) VALUES ('2', 'Biffen_gang');
INSERT INTO `NordkraftPMS`.`zones` (`id`, `name`) VALUES ('3', 'Skråen');

DELETE FROM `NordkraftPMS`.`posters`;
INSERT INTO `NordkraftPMS`.`posters` (`id`, `name`, `start_date`, `end_date`, `image_url`, `created_by`) VALUES ('1', 'Poster1', '2021-10-26 13:30:45', '2022-10-26 13:30:47', 'ww.gg.dk', '1');
INSERT INTO `NordkraftPMS`.`posters` (`id`, `name`, `start_date`, `end_date`, `image_url`, `created_by`) VALUES ('2', 'Poster2', '2021-10-26 13:30:45', '2022-10-26 13:30:47', 'ww.gg.dk', '2');
INSERT INTO `NordkraftPMS`.`posters` (`id`, `name`, `start_date`, `end_date`, `image_url`, `created_by`) VALUES ('3', 'Poster3', '2021-10-26 13:30:45', '2022-10-26 13:30:47', 'ww.gg.dk', '3');

DELETE FROM `NordkraftPMS`.`screens`;
INSERT INTO `NordkraftPMS`.`screens` (`id`, `name`, `zone`) VALUES ('1', 'Screen1', '1');
INSERT INTO `NordkraftPMS`.`screens` (`id`, `name`, `zone`) VALUES ('2', 'Screen2', '2');
INSERT INTO `NordkraftPMS`.`screens` (`id`, `name`, `zone`) VALUES ('3', 'Screen3', '2');
INSERT INTO `NordkraftPMS`.`screens` (`id`, `name`, `zone`) VALUES ('4', 'Screen4', '3');

DELETE FROM `NordkraftPMS`.`metadata`;
INSERT INTO `NordkraftPMS`.`metadata` (`id`, `timer`) VALUES ('1', '10');

DELETE FROM `NordkraftPMS`.`schedules`;
INSERT INTO `NordkraftPMS`.`schedules` (`id`, `poster_id`, `start_date`, `end_date`, `daily`, `weekday`) VALUES ('1', '1', '2021-10-26 13:30:45', '2022-10-26 13:30:47', '0', '{0, 0, 0, 1, 0, 0, 1}');
INSERT INTO `NordkraftPMS`.`schedules` (`id`, `poster_id`, `start_date`, `end_date`, `daily`, `weekday`) VALUES ('2', '2', '2021-10-26 13:30:45', '2022-12-26 13:30:47', '1', '{0, 0, 0, 0, 0, 0, 0}');
INSERT INTO `NordkraftPMS`.`schedules` (`id`, `poster_id`, `start_date`, `end_date`, `daily`, `weekday`) VALUES ('3', '3', '2021-10-26 13:30:45', '2022-12-26 13:30:47', '0', '{1, 1, 0, 0, 0, 0, 0}');

UPDATE `users` SET `institution` = 1 WHERE `id` = 1;
UPDATE `users` SET `institution` = 2 WHERE `id` = 2;
UPDATE `users` SET `institution` = 3 WHERE `id` = 3;
