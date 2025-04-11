CREATE PROCEDURE sp_insert_details
    @Fname NVARCHAR(100),
    @Lname NVARCHAR(100),
    @Age INT,
    @Address NVARCHAR(200),
    @DOB DATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [TEST].[dbo].[Details] ([Fname], [Lname], [Age], [Address], [DOB])
    VALUES (@Fname, @Lname, @Age, @Address, @DOB);
END