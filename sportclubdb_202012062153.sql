--
-- Скрипт сгенерирован Devart dbForge Studio 2020 for MySQL, Версия 9.0.435.0
-- Домашняя страница продукта: http://www.devart.com/ru/dbforge/mysql/studio
-- Дата скрипта: 06.12.2020 21:53:59
-- Версия сервера: 8.0.11
-- Версия клиента: 4.1
--

-- 
-- Отключение внешних ключей
-- 
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

-- 
-- Установить режим SQL (SQL mode)
-- 
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- 
-- Установка кодировки, с использованием которой клиент будет посылать запросы на сервер
--
SET NAMES 'utf8';

--
-- Установка базы данных по умолчанию
--
USE sportclubdb;

--
-- Удалить таблицу `event`
--
DROP TABLE IF EXISTS event;

--
-- Удалить таблицу `administrator`
--
DROP TABLE IF EXISTS administrator;

--
-- Удалить таблицу `client`
--
DROP TABLE IF EXISTS client;

--
-- Удалить таблицу `trainer`
--
DROP TABLE IF EXISTS trainer;

--
-- Удалить таблицу `phone`
--
DROP TABLE IF EXISTS phone;

--
-- Удалить таблицу `post`
--
DROP TABLE IF EXISTS post;

--
-- Установка базы данных по умолчанию
--
USE sportclubdb;

--
-- Создать таблицу `post`
--
CREATE TABLE post (
  id int(11) NOT NULL AUTO_INCREMENT,
  name varchar(50) NOT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 4,
AVG_ROW_LENGTH = 5461,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать таблицу `phone`
--
CREATE TABLE phone (
  id int(11) NOT NULL AUTO_INCREMENT,
  number varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 32,
AVG_ROW_LENGTH = 910,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать таблицу `trainer`
--
CREATE TABLE trainer (
  id int(11) NOT NULL AUTO_INCREMENT,
  name varchar(50) DEFAULT NULL,
  surname varchar(255) DEFAULT NULL,
  lastname varchar(255) DEFAULT NULL,
  id_post int(11) NOT NULL,
  login varchar(255) DEFAULT NULL,
  password varchar(255) DEFAULT NULL,
  id_phone int(11) NOT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 7,
AVG_ROW_LENGTH = 8192,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE trainer
ADD CONSTRAINT FK_trainer_id_phone FOREIGN KEY (id_phone)
REFERENCES phone (id);

--
-- Создать внешний ключ
--
ALTER TABLE trainer
ADD CONSTRAINT FK_trainer_id_post FOREIGN KEY (id_post)
REFERENCES post (id);

--
-- Создать таблицу `client`
--
CREATE TABLE client (
  id int(11) NOT NULL AUTO_INCREMENT,
  name varchar(255) DEFAULT NULL,
  surname varchar(255) DEFAULT NULL,
  lastname varchar(255) DEFAULT NULL,
  id_post int(11) NOT NULL,
  id_trainer int(11) NOT NULL,
  id_phone int(11) NOT NULL,
  created varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 20,
AVG_ROW_LENGTH = 4096,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE client
ADD CONSTRAINT FK_client_id_phone FOREIGN KEY (id_phone)
REFERENCES phone (id);

--
-- Создать внешний ключ
--
ALTER TABLE client
ADD CONSTRAINT FK_client_id_post FOREIGN KEY (id_post)
REFERENCES post (id);

--
-- Создать внешний ключ
--
ALTER TABLE client
ADD CONSTRAINT FK_client_id_trainer FOREIGN KEY (id_trainer)
REFERENCES trainer (id);

--
-- Создать таблицу `administrator`
--
CREATE TABLE administrator (
  id int(11) NOT NULL AUTO_INCREMENT,
  name varchar(255) DEFAULT NULL,
  surname varchar(255) DEFAULT NULL,
  lastname varchar(255) DEFAULT NULL,
  id_post int(11) NOT NULL,
  login varchar(255) DEFAULT NULL,
  password varchar(255) DEFAULT NULL,
  id_phone int(11) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 7,
AVG_ROW_LENGTH = 16384,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE administrator
ADD CONSTRAINT FK_administrator_id_phone FOREIGN KEY (id_phone)
REFERENCES phone (id);

--
-- Создать внешний ключ
--
ALTER TABLE administrator
ADD CONSTRAINT FK_administrator_id_post FOREIGN KEY (id_post)
REFERENCES post (id);

--
-- Создать таблицу `event`
--
CREATE TABLE event (
  id int(11) NOT NULL AUTO_INCREMENT,
  date varchar(255) DEFAULT NULL,
  name varchar(255) DEFAULT NULL,
  description varchar(255) DEFAULT NULL,
  id_trainer int(11) DEFAULT NULL,
  id_admin int(11) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 11,
AVG_ROW_LENGTH = 4096,
CHARACTER SET utf8,
COLLATE utf8_general_ci;

--
-- Создать внешний ключ
--
ALTER TABLE event
ADD CONSTRAINT FK_event_id_admin FOREIGN KEY (id_admin)
REFERENCES administrator (id);

--
-- Создать внешний ключ
--
ALTER TABLE event
ADD CONSTRAINT FK_event_id_trainer FOREIGN KEY (id_trainer)
REFERENCES trainer (id);

-- 
-- Вывод данных для таблицы post
--
INSERT INTO post VALUES
(1, 'Администратор'),
(2, 'Тренер'),
(3, 'Клиент');

-- 
-- Вывод данных для таблицы phone
--
-- Таблица sportclubdb.phone не содержит данных

-- 
-- Вывод данных для таблицы administrator
--
-- Таблица sportclubdb.administrator не содержит данных

-- 
-- Вывод данных для таблицы trainer
--
-- Таблица sportclubdb.trainer не содержит данных

-- 
-- Вывод данных для таблицы event
--
-- Таблица sportclubdb.event не содержит данных

-- 
-- Вывод данных для таблицы client
--
-- Таблица sportclubdb.client не содержит данных

-- 
-- Восстановить предыдущий режим SQL (SQL mode)
--
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

-- 
-- Включение внешних ключей
-- 
/*!40014 SET FOREIGN_KEY_CHECKS = @OLD_FOREIGN_KEY_CHECKS */;