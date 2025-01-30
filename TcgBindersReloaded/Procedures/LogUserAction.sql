CREATE OR REPLACE PROCEDURE LogUserAction(_UserId INT, _Message TEXT)
LANGUAGE plpgsql
AS $$
BEGIN
INSERT INTO "UserLogs" ("UserId", "Message", "ActionDate")
VALUES (_UserId, _Message, NOW());
END;
$$;
