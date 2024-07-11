CREATE PROCEDURE InsertMonthlyRevenue
    @ReportDate integer,
	@DataYearMonth integer,
	@CompanyCode integer,
	@CompanyName nvarchar(8),
	@Industry nvarchar(8),
	@CurrentMonthRevenue BIGINT,
	@PreviousMonthRevenue BIGINT,
	@LastYearSameMonthRevenue BIGINT,
	@MonthComparisonPercentage numeric(24,18),
	@YearComparisonPercentage numeric(24,18),
	@CumulativeCurrentYearRevenue BIGINT,
	@CumulativeLastYearRevenue BIGINT,
	@CumulativeComparisonPercentage numeric(24,18),
	@Notes nvarchar(85)
AS
BEGIN
    INSERT INTO MonthlyRevenue 
    (ReportDate, DataYearMonth, CompanyCode, CompanyName, Industry, CurrentMonthRevenue, PreviousMonthRevenue, LastYearSameMonthRevenue, MonthComparisonPercentage, YearComparisonPercentage, CumulativeCurrentYearRevenue, CumulativeLastYearRevenue, CumulativeComparisonPercentage, Notes)
    VALUES 
    (@ReportDate, @DataYearMonth, @CompanyCode, @CompanyName, @Industry, @CurrentMonthRevenue, @PreviousMonthRevenue, @LastYearSameMonthRevenue, @MonthComparisonPercentage, @YearComparisonPercentage, @CumulativeCurrentYearRevenue, @CumulativeLastYearRevenue, @CumulativeComparisonPercentage, @Notes);
END;