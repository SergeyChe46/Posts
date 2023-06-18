CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

DROP TABLE IF EXISTS Post, Author, Post_Author;

CREATE TABLE IF NOT EXISTS Post(
	Id uuid PRIMARY KEY DEFAULT gen_random_uuid() NOT NULL,
	Title text NOT NULL,
	Content text NOT NULL,
	CreatedAt timestamp DEFAULT current_timestamp,
	UpdatedAt timestamp DEFAULT current_timestamp
);

CREATE TABLE IF NOT EXISTS Author(
	Id uuid PRIMARY KEY DEFAULT gen_random_uuid() NOT NULL,
	Email varchar(100),
	Name varchar(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS Post_Author(
	Post_id uuid REFERENCES Post(Id),
	Author_id uuid REFERENCES Author(Id)
)






