CREATE OR REPLACE FUNCTION AddCardToBinder(_UserId INT, _CardId INT)
    RETURNS VOID AS $$
BEGIN

    IF NOT EXISTS (SELECT 1 FROM "CollectionCards" WHERE "UserId" = _UserId AND "CardId" = _CardId) THEN
        INSERT INTO "CollectionCards" ("UserId", "CardId") VALUES (_UserId, _CardId);
    END IF;
END;
$$ LANGUAGE plpgsql;
