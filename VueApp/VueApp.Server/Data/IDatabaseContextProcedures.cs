﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using VueApp.Server.Data;

namespace VueApp.Server.Data
{
    public partial interface IDatabaseContextProcedures
    {
        Task<List<DataInitializeResult>> DataInitializeAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<InsertMonthlyRevenueResult>> InsertMonthlyRevenueAsync(int? ReportDate, int? DataYearMonth, int? CompanyCode, string CompanyName, string Industry, long? CurrentMonthRevenue, long? PreviousMonthRevenue, long? LastYearSameMonthRevenue, decimal? MonthComparisonPercentage, decimal? YearComparisonPercentage, long? CumulativeCurrentYearRevenue, long? CumulativeLastYearRevenue, decimal? CumulativeComparisonPercentage, string Notes, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<SelectMonthlyRevenueResult>> SelectMonthlyRevenueAsync(string CompanyCode, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
