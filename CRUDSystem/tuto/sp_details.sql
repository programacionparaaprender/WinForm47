CREATE PROCEDURE sp_details
--alter
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        [ID],
        [Fname],
        [Lname],
        [Age],
        [Address],
        [DOB]
    FROM [TEST].[dbo].[Details];
END
