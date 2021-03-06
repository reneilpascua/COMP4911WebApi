﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using COMP4911WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP4911WebAPI.Repository
{
    public class TimesheetRowRepository : IDataRepository<TimesheetRow>
    {
        private readonly ApplicationDbContext _timesheetRowContext;

        public TimesheetRowRepository(ApplicationDbContext context)
        {
            this._timesheetRowContext = context;
        }

        public async Task<bool> Add(TimesheetRow entity)
        {
            try
            {
                await _timesheetRowContext.AddAsync(entity);
                await _timesheetRowContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Failed to add timesheetrow: " + e.ToString());
            }
        }

        public Task<bool> CheckIfExists(TimesheetRow entity)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(TimesheetRow entity)
        {
            _timesheetRowContext.Remove(entity);
            await _timesheetRowContext.SaveChangesAsync();
          //  _timesheetRowContext.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<TimesheetRow> Get(int id)
        {
            return await _timesheetRowContext.TimesheetRows.FindAsync(id);
        }

        public async Task<IEnumerable<TimesheetRow>> GetAll()
        {
            return await _timesheetRowContext.TimesheetRows.ToListAsync();
        }

        public Task<TimesheetRow> GetLastId()
        {
            throw new NotImplementedException();
        }

        public Task Update(TimesheetRow entity)
        {
            throw new NotImplementedException();
        }
    }
}
