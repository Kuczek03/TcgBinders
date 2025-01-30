CREATE OR REPLACE PROCEDURE RemoveCardFromCollection(_UserId INT, _CardId INT)
LANGUAGE plpgsql
AS $$
BEGIN
    IF EXISTS (SELECT 1 FROM "CollectionCards" WHERE "UserId" = _UserId AND "CardId" = _CardId) THEN
        
    DELETE FROM "CollectionCards" WHERE "UserId" = _UserId AND "CardId" = _CardId;

    CALL LogUserAction(_UserId, 'Removed card ID ' || _CardId || ' from collection.');
    END IF;
END;
$$;
