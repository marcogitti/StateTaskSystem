using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StateTaskSystem.Data;
using StateTaskSystem.State;
using StateTaskSystem.State.Enum;
using System.Threading.Tasks;

namespace StateTaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CTaskController : ControllerBase
    {
        private readonly StateDBContext _context;
        public CTaskController(StateDBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StateTaskModel>> GetTask(int id)
        {
            var tasks = await _context.TasksModel.FindAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            return tasks;
        }

        [HttpPost]
        public async Task<ActionResult<StateTaskModel>> PostTask(StateTaskModel tasksModel)
        {
            tasksModel.State = State.Enum.StateTask.Created;
            _context.TasksModel.Add(tasksModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = tasksModel.Id }, tasksModel);
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> StartTask(int id)
        {
            var tasks = await _context.TasksModel.FindAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            if (tasks.State == State.Enum.StateTask.Created)
            {
                tasks.State = State.Enum.StateTask.InProgress;
                _context.Entry(tasks).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("The task cannot be completed");
            }

            return NoContent();
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteTask(int id)
        {
            var tasks = await _context.TasksModel.FindAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            if (tasks.State == State.Enum.StateTask.InProgress)
            {
                tasks.State = State.Enum.StateTask.Completed;
                _context.Entry(tasks).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("There was an error completing the task");
            }

            return NoContent();
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> CancelTask(int id)
        {
            var tasks = await _context.TasksModel.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }

            if (tasks.State == State.Enum.StateTask.Created || tasks.State == State.Enum.StateTask.InProgress)
            {
                tasks.State = State.Enum.StateTask.Canceled;
                _context.Entry(tasks).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                return BadRequest("There was an error completing the task");
            }

            return NoContent();
        }
    }
}
