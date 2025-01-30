CREATE OR REPLACE PROCEDURE LogUserLogout(_UserId INT)
LANGUAGE plpgsql
AS $$
BEGIN
INSERT INTO "UserLogs" ("UserId", "Message", "ActionDate")
VALUES (_UserId, 'User '|| _UserId ||' logged out', NOW());
COMMIT;
END;
$$;
