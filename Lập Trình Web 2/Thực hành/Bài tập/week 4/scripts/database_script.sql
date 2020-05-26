create database if not exists registerevents;

use registerevents;

SET
  NAMES utf8mb4;

SET
  FOREIGN_KEY_CHECKS = 0;

create table events (
	id int unsigned auto_increment primary key,
    title varchar(50),
    briefdes varchar(255),
    fulldes varchar (255),
    dateheld date
);

create table participants (
	id int unsigned auto_increment primary key,
    name varchar(30),
    email varchar(50)
);

create table admins (
  email varchar(50) primary key,
  name varchar(30) not null,
  password varchar(100),
  phone varchar(15),
  avatar varchar(100)
);

create table users (
  email varchar(50) primary key,
  name varchar(30) not null,
  password varchar(100),
  avatar varchar(100)
);

create table users_events(
	email varchar(50),
    event_id int,
    attend bool,
    primary key (email, event_id)
);

create table sys(
	id int primary key,
	home varchar(255),
    thanks varchar(255)
);

insert into admins (email, name, password, phone, avatar)
values ('mc@email', N'Dương Mạnh Cường', 'a1d0c6e83f027327d8461063f4ac58a6', '07539512486', '/public/imgs/avatars/admins/1.png');

insert into users (email, name, password, avatar)
values ('hl@email', N'Phan Hữu Lộc', 'a1d0c6e83f027327d8461063f4ac58a6', '/public/imgs/avatars/users/1.jpg');

insert into events (title, briefdes, fulldes, dateheld)
values (N'Hội nghị cho những người vừa chia tay người yêu', N'FA muôn năm', N'Cho ai mới chia tay người yêu', '2020-04-28');

insert into users_events (email, event_id, attend)
values ('hl@emai', 1, true);