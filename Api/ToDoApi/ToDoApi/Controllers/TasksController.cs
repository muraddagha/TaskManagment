using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Data.Entities;
using ToDoApi.Infrasturcture.Exceptions;
using ToDoApi.Resources.TasksResource;
using ToDoApi.Services;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService,IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            try
            {
                var tasks = await _taskService.GetTasks();
                var tasksResource = _mapper.Map<IEnumerable<Tasks>, IEnumerable<TasksResource>>(tasks);
                return Ok(tasksResource);
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }
        }

        [Route("value")]
        [HttpGet]
        public async Task<IActionResult> GetTasksIsDoneOrNot(bool isDone)
        {
            try
            {
                var tasks = await _taskService.TaskIsDone(isDone);
                var tasksResource = _mapper.Map<IEnumerable<Tasks>, IEnumerable<TasksResource>>(tasks);
                return Ok(tasksResource);
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }
        }

        [Route("categoryId")]
        [HttpGet]
        public async Task<IActionResult> GetTasksByCategoryId([FromQuery]int categoryId)
        {
            try
            {
                var tasks = await _taskService.GetTasksByCategoryId(categoryId);
                var tasksResource = _mapper.Map<IEnumerable<Tasks>, IEnumerable<TasksResource>>(tasks);
                return Ok(tasksResource);
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var task = new Tasks()
                {
                    Node = resource.Node,
                    CategoryId = resource.CategoryId,
                    DoneNote = resource.DoneNote,
                    EndDate = resource.EndDate,
                    IsDone=resource.IsDone,
                    CompletedAt=resource.CompletedAt
                };
                await _taskService.CreateTask(task);
                return Ok(new { message="Task yaradıldı"});
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }
            
        }

        [Route("{id}")]
        [HttpPost]
        public async Task<IActionResult> CompleteTask(int id)
        {
            try
            {
                await _taskService.CompleteTask(id);
                return Ok(new { message = "Task tamamlandı" });
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }
        }

       [Route("{id}")]
       [HttpGet]

       public async Task<IActionResult> GetTasksById(int id)
        {
            try
            {
                var tasks=await _taskService.GetTasksById(id);
                var taskResources = _mapper.Map<Tasks, TasksResource>(tasks);
                return Ok(taskResources);
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.Message);
            }
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromRoute]int id,UpdateTaskResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var updatedTask = await _taskService.GetTasksById(id);
                updatedTask.Node = resource.Node;
                updatedTask.IsDone = resource.IsDone;
                updatedTask.EndDate = resource.EndDate;
                updatedTask.CompletedAt = resource.CompletedAt;
                updatedTask.DoneNote = resource.DoneNote;
                updatedTask.CategoryId = resource.CategoryId;
                await _taskService.UpdateTask(updatedTask);
                return Ok(new { message = "Task yeniləndi" });
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> RemoveTask(int id)
        {
            try
            {
                await _taskService.RemoveTask(id);
                return Ok(new { message = "Task silindi" });
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }
            
        }

    }
}
