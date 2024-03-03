using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesAndReminders.DataBase.Models;
using NotesAndReminders.Server.Interfaces;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;

namespace NotesAndReminders.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly ILogger<NoteController> _logger;        
        private readonly INoteRepository _noteRepo;
        public NoteController(INoteRepository noteRepo, ILogger<NoteController> logger)
        {
            _noteRepo = noteRepo;
            _logger = logger;
        }

        [HttpGet(Name = "GetNotes")]
        public IEnumerable<Note> Get()
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            IEnumerable<Note> notes =  _noteRepo.GetAll(includeProperties:"Tags");
            var json = JsonSerializer.Serialize(notes, jsonSerializerOptions);
            notes = JsonSerializer.Deserialize<IEnumerable<Note>>(json, jsonSerializerOptions);

            return notes;
        }
        [HttpGet("{id}")]
        public Note Get(int id)
        {
            Note note = _noteRepo.Find(id);
            return note;
        }

        [HttpPost]
        public IActionResult Post(Note note)
        {
            if (ModelState.IsValid)
            {
                _noteRepo.Add(note);
                _noteRepo.Save();
                return Ok(note);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Note note)
        {
            if (ModelState.IsValid)
            {
                _noteRepo.Update(note);
                _noteRepo.Save();
                return Ok(note);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Note note = _noteRepo.Find(id);
            if (note != null)
            {
                _noteRepo.Remove(note);
                _noteRepo.Save();
            }
            return Ok(note);
        }
    }
}
