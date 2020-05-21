create database if not exists registerevents;

use registerevents;

SET
  NAMES utf8mb4;

SET
  FOREIGN_KEY_CHECKS = 0;

create table admins (
  id int unsigned auto_increment primary key,
  fullname varchar(30) not null,
  username varchar(20),
  pass varchar(100),
  email varchar(50),
  phone varchar(15),
  avatar blob
);

create table users (
  id int unsigned auto_increment primary key,
  fullname varchar(30) not null,
  pass varchar(100),
  email varchar(50),
  attend boolean,
  avatar longblob
);

insert into
  admins (fullname, username, pass, email, phone, avatar)
values
  (
    N'Dương Mạnh Cường',
    'mc',
    N'123',
    'mc@email',
    '07531596842',
    LOAD_FILE('D:\\1.png')
  );

insert into
  admins (fullname, username, pass, email, phone, avatar)
values
  (
    N 'Trịnh Nhã Hồng',
    'nh',
    N'123',
    'nh@email',
    '01593578426',
    LOAD_FILE('D:\\2.jpg')
  );

insert into
  users (fullname, pass, email, attend, avatar)
values
  (
    N'Dương Mạnh Cường',
    '123',
    'mc@email',
    true,
    LOAD_FILE('D:\\1.png')
  );

insert into
  users (fullname, pass, email, attend, avatar)
values
  (
    N 'Trịnh Nhã Hồng',
    '123',
    'nh@email',
    false,
    LOAD_FILE('D:\\2.jpg')
  );