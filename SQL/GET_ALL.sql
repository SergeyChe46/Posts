CREATE OR REPLACE FUNCTION get_all() RETURNING SETOF Post AS 
$$
	SELECT * FROM Post
$$
LANGUAGE SQL;