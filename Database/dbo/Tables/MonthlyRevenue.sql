CREATE TABLE [dbo].[MonthlyRevenue] (
    [_record_number]                 INT              IDENTITY (1, 1) NOT NULL,
    [ReportDate]                     INT              NULL,
    [DataYearMonth]                  INT              NULL,
    [CompanyCode]                    INT              NOT NULL,
    [CompanyName]                    NVARCHAR (8)     NULL,
    [Industry]                       NVARCHAR (8)     NULL,
    [CurrentMonthRevenue]            BIGINT           NULL,
    [PreviousMonthRevenue]           BIGINT           NULL,
    [LastYearSameMonthRevenue]       BIGINT           NULL,
    [MonthComparisonPercentage]      NUMERIC (24, 18) NULL,
    [YearComparisonPercentage]       NUMERIC (24, 18) NULL,
    [CumulativeCurrentYearRevenue]   BIGINT           NULL,
    [CumulativeLastYearRevenue]      BIGINT           NULL,
    [CumulativeComparisonPercentage] NUMERIC (24, 18) NULL,
    [Notes]                          NVARCHAR (85)    NULL,
    PRIMARY KEY CLUSTERED ([CompanyCode] ASC)
);


GO
CREATE NONCLUSTERED INDEX [idx_CompanyCode]
    ON [dbo].[MonthlyRevenue]([CompanyCode] ASC);

