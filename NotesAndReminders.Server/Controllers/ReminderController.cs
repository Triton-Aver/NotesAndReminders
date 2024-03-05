using Microsoft.AspNetCore.Mvc;
using NotesAndReminders.DataBase.Models;
using NotesAndReminders.Server.Interfaces;
using System.Text.Json.Serialization;
using System.Text.Json;

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
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            IEnumerable<Reminder> reminders = _reminRepo.GetAll(includeProperties:"Note");
            var json = JsonSerializer.Serialize(reminders, jsonSerializerOptions);
            reminders = JsonSerializer.Deserialize<IEnumerable<Reminder>>(json, jsonSerializerOptions);

            return reminders;
        }
        
        [HttpPost]
        public IActionResult Post(Reminder reminder)
        {
            if (ModelState.IsValid)
            {
                _reminRepo.CreateReminder(reminder);                
                return Ok(reminder);
            }
            return BadRequest(ModelState);
        }        
    }
}
