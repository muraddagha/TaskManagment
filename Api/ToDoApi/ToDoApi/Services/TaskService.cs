using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Data;
using ToDoApi.Data.Entities;
using ToDoApi.Infrasturcture.Exceptions;

namespace ToDoApi.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<Tasks>> GetTasks();
        Task<IEnumerable<Tasks>> TaskIsDone(bool isDone);
        Task<IEnumerable<Tasks>> GetTasksByCategoryId(int id);
        Task<Tasks> CreateTask(Tasks task);
        Task CompleteTask(int id);
        Task<Tasks> GetTasksById(int id);
        Task UpdateTask(Tasks task);
        Task RemoveTask(int id);
    }
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        public TaskService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CompleteTask(int id)
        {
            var task = await GetTasksById(id);
            if (task.IsDone) throw new HttpException(409, "Bu task artıq tamamlanmışdır");
            task.IsDone = true;
           await _context.SaveChangesAsync();
        }

        public async Task<Tasks> CreateTask(Tasks task)
        {
            bool checkNode = await _context.Tasks.AnyAsync(t => t.Node == task.Node);
            bool checkCategoryId = await _context.Categories.AnyAsync(c => c.Id == task.CategoryId);
            if (checkNode) throw new HttpException(409, "Bu adda task artıq mövcuddur");
            if (!checkCategoryId) throw new HttpException(404, "Belə kateqoriya mövcud deyil");
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }
        public async Task<IEnumerable<Tasks>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<IEnumerable<Tasks>> GetTasksByCategoryId(int categoryId)
        {
            bool check = await _context.Tasks.AnyAsync(t => t.CategoryId == categoryId);
            if (!check) throw new HttpException(404, "Bu kateqaoriyaya uyğun task yoxdur");
            return await _context.Tasks.Where(t => t.CategoryId == categoryId).ToListAsync();
        }

        public async Task<Tasks> GetTasksById(int id)
        {
            var tasks = await _context.Tasks.FindAsync(id);
            if (tasks == null) throw new HttpException(404, "Task tapılmadı");
            return tasks;
        }

        public async Task RemoveTask(int id)
        {
            var task = await this.GetTasksById(id);
             _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tasks>> TaskIsDone(bool isdone)
        {
            bool checkFalse = await _context.Tasks.AnyAsync(t => t.IsDone==isdone);
            bool checkTrue = await _context.Tasks.AnyAsync(t => t.IsDone==isdone);
            if (!checkFalse) throw new HttpException(404, "Tamamlanmamış task yoxdur");
            if (!checkTrue) throw new HttpException(404, "Tamamlanmış task yoxdur");
            return await _context.Tasks.Where(t => t.IsDone == isdone).ToListAsync();
        }

        public async Task UpdateTask(Tasks task)
        {
            bool check = await _context.Tasks.AnyAsync(t => t.Node == task.Node);
            bool checkCategoryId = await _context.Categories.AnyAsync(t => t.Id == task.CategoryId);
            if (check) throw new HttpException(409, "Bu adda task artıq mövcuddur");
            if (!checkCategoryId) throw new HttpException(404, "Belə kateqoriya mövcud deyil");

            await _context.SaveChangesAsync();
        }

    }
}
