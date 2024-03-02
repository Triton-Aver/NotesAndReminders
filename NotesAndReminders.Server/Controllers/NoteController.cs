﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesAndReminders.DataBase.Models;
using NotesAndReminders.Server.Interfaces;

namespace NotesAndReminders.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository _noteRepo;
        public NoteController(INoteRepository noteRepo)
        {
            _noteRepo = noteRepo;
        }

        [HttpGet]
        public IEnumerable<Note> Get()
        {           
            IEnumerable<Note> productDtos =  _noteRepo.GetAll();            
            return productDtos;
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
