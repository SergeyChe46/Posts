WITH insert_post AS(
	INSERT INTO Post (title, content)
	VALUES ('First title', 'First content')
	RETURNING id AS post_id
), insert_author AS(
	INSERT INTO Author (email, name)
	VALUES ('Sergey', 'Sergey@mail.ru')
	RETURNING id AS author_id
)
INSERT INTO Post_Author(post_id, author_id)
SELECT post_id, author_id FROM insert_post, insert_author;