using AuthorizationExperiment.Api.Services.Application;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationExperiment.Api.Controllers
{
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;
        
        public TasksController(ILogger<TasksController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/task")]
        public async Task<IActionResult> GetTask([FromServices] TaskManager taskManager, [FromQuery(Name = "taskId")] int taskId, [FromQuery(Name = "userId")] int userId, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Loading Task {taskId} for User {userId}", taskId, userId);

            try
            {
                var task = await taskManager.ReadTaskAsync(taskId, userId, cancellationToken);

                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/tasks")]
        public async Task<IActionResult> GetTasks([FromServices] TaskManager taskManager, [FromQuery(Name = "userId")] int userId, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Loading Tasks for User {userId}", userId);

            try
            {
                var tasks = await taskManager.ReadTasksAsync(userId, cancellationToken);

                return Ok(tasks);
            } 
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}