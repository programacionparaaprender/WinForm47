CREATE PROCEDURE sp_delete_details
    @ID INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [TEST].[dbo].[Details]
    WHERE ID = @ID;
END
