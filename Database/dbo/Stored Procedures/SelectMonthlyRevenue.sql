CREATE PROCEDURE SelectMonthlyRevenue
    @CompanyCode nvarchar(8)
AS
BEGIN
    SELECT * 
    FROM MonthlyRevenue
    WHERE CompanyCode = @CompanyCode;
END;