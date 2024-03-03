using Microsoft.AspNetCore.Mvc;
using NotesAndReminders.DataBase.Models;
using NotesAndReminders.Server.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotesAndReminders.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        private readonly ILogger<ReminderController> _logger;
        private readonly IReminderRepository _reminRepo;
        public ReminderController(IReminderRepository reminRepo, ILogger<ReminderController> logger)
        {
            _reminRepo = reminRepo;
            _logger = logger;
        }

        // GET: api/<ReminderController>
        [HttpGet]
        public IEnumerable<Reminder> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ReminderController>/5
        [HttpGet("{id}")]
        public Reminder Get(int id)
        {
            Reminder reminder = _reminRepo.Find(id);
            return reminder;
        }

        [HttpPost]
        public IActionResult Post(Reminder reminder)
        {
            if (ModelState.IsValid)
            {
                _reminRepo.Add(reminder);
                _reminRepo.Save();
                //_noteRepo.CreateNote(note);
                return Ok(reminder);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Reminder reminder)
        {
            if (ModelState.IsValid)
            {
                _reminRepo.Update(reminder);
                _reminRepo.Save();
                return Ok(reminder);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Reminder reminder = _reminRepo.Find(id);
            if (reminder != null)
            {
                _reminRepo.Remove(reminder);
                _reminRepo.Save();
            }
            return Ok(reminder);
        }
    }
}
