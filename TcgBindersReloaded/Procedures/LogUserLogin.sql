CREATE OR REPLACE PROCEDURE LogUserLogin(_UserId INT)
LANGUAGE plpgsql
AS $$
BEGIN
INSERT INTO "UserLogs" ("UserId", "Message", "ActionDate")
VALUES (_UserId, 'User '|| _UserId ||' logged in', NOW());
COMMIT;
END;
$$;
