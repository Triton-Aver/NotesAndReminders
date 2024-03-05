using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesAndReminders.DataBase.Models;
using NotesAndReminders.Server.Interfaces;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;
using System.Linq.Expressions;

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

            IEnumerable<Note> notes =  _noteRepo.GetAll(includeProperties: "Tags,ReminderNote");
            var json = JsonSerializer.Serialize(notes, jsonSerializerOptions);
            notes = JsonSerializer.Deserialize<IEnumerable<Note>>(json, jsonSerializerOptions);

            return notes;
        }
        [HttpGet("{id}")]
        public Note Get(int id)
        {
            // Создание параметра для выражения
            var noteParameter = Expression.Parameter(typeof(Note), "note");

            // Создание выражения сравнения Id записки с конкретным значением
            var comparison = Expression.Equal(
                Expression.Property(noteParameter, nameof(Note.NoteId)),
                Expression.Constant(id) // Предположим, что мы ищем записку с Id равным 1
            );

            // Создание выражения-делегата
            var lambda = Expression.Lambda<Func<Note, bool>>(comparison, noteParameter);

            Note note = _noteRepo.FirstOrDefault(filtr: lambda, includeProperties: "Tags,ReminderNote");

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };            
            var json = JsonSerializer.Serialize(note, jsonSerializerOptions);
            note = JsonSerializer.Deserialize<Note>(json, jsonSerializerOptions);
            return note;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Note note)
        {
            if (ModelState.IsValid)
            {
                //_noteRepo.Add(note);
                //_noteRepo.Save();
                _noteRepo.CreateNote(note);
                return Ok(note);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Note note)
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
