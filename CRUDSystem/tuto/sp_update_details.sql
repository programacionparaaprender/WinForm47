CREATE PROCEDURE sp_update_details
    @ID INT,
    @Fname NVARCHAR(100),
    @Lname NVARCHAR(100),
    @Age INT,
    @Address NVARCHAR(200),
    @DOB DATE
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE [TEST].[dbo].[Details]
    SET 
        Fname = @Fname,
        Lname = @Lname,
        Age = @Age,
        Address = @Address,
        DOB = @DOB
    WHERE ID = @ID;
END
