﻿using OutlookFW.EntityFramework;
using EntityFramework.DynamicFilters;

namespace OutlookFW.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly OutlookFWDbContext _context;

        public InitialHostDbBuilder(OutlookFWDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
