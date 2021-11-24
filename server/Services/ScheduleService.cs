using System.Collections.Generic;
using System;
using System.Linq;
using server.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace server.Services
{
    public class ScheduleService
    {
        public ScheduleService(databaseContext context)
        {
            _context = context;
        }

        private databaseContext _context;

        public async Task<IEnumerable<Schedule>> GetAllSchedules() => await _context.Schedules.ToListAsync();

        public async Task<IEnumerable<Object>> GetAllSchedulesJSON()
        {
            IEnumerable<Schedule> schedules = await GetAllSchedules();
            List<Object> response = new List<Object>();
            foreach (Schedule s in schedules)
            {
                response.Add(s.ToJSON());
            }

            return response;
        }

        public async Task<Schedule> GetSchedule(int id)
        {
            Schedule schedule = await _context.Schedules.FindAsync(id);

            if (schedule == null)
            {
                throw new NullReferenceException("Schedule was not found");
            }

            return schedule;
        }

        public async Task<Object> GetScheduleJSON(int id)
        {
            Schedule s = await GetSchedule(id);

            return s.ToJSON();
        }

        public async Task<Schedule> CreateSchedule(Schedule schedule)
        {
            await _context.Schedules.AddAsync(schedule);
            await _context.SaveChangesAsync();

            return await _context.Schedules.Where(s => s.Id == schedule.Id).FirstOrDefaultAsync();
        }

        public async Task<Schedule> DeleteSchedule(int id)
        {
            Schedule schedule = await _context.Schedules.FindAsync(id);
            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();

            return schedule;
        }

        //PUT request
        public async Task<Schedule> UpdateSchedule(int id, Schedule schedule)
        {
            Schedule s = await GetSchedule(id);
            s.PosterId = schedule.PosterId;
            s.Name = schedule.Name;
            s.StartDate = schedule.StartDate;
            s.EndDate = schedule.EndDate;

            await _context.SaveChangesAsync();

            return s;
        }

        public async Task<Object> UpdateScheduleJSON(int id, Schedule schedule)
        {
            Schedule s = await UpdateSchedule(id, schedule);
            return s.ToJSON();
        }
    }
}