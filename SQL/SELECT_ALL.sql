CREATE OR REPLACE FUNCTION returnallcolumns(IN sessionId character varying)
  RETURNS SETOF Post 
  LANGUAGE plpgsql
  AS
$$
  SELECT * FROM Post 
$$;