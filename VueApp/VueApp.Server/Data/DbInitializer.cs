﻿namespace VueApp.Server.Data
{
    public static class DbInitializer
    {
        public static async void Initialize(DatabaseContext context)
        {
            // Look for any data.
            if (context.MonthlyRevenues.Any())
            {
                return;   // DB has been seeded
            }

            await context.Procedures.DataInitializeAsync();
        }
    }
}
