CREATE OR REPLACE PROCEDURE AddCardToBinder(_UserId INT, _CardId INT)
    LANGUAGE plpgsql
AS $$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM "CollectionCards" WHERE "UserId" = _UserId AND "CardId" = _CardId) THEN
        INSERT INTO "CollectionCards" ("UserId", "CardId") VALUES (_UserId, _CardId);

        CALL LogUserAction(_UserId, 'Added card ID ' || _CardId || ' to binder.');
    END IF;
END;
$$;
