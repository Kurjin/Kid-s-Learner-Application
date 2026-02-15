create database kla;

SELECT * FROM kla.users;

CREATE TABLE users (
id int auto_increment primary key,
username varchar(255) not null unique,
p_Hash varchar(255) not null,
p_Salt varchar(255) not null,
created_At datetime not null
);

create table account_Logs (
id int auto_increment primary key,
user_Id int not null,
user_Action varchar(50) not null,
timestamp_Date datetime not null,
foreign key (user_Id) references users(id) on delete cascade

);



