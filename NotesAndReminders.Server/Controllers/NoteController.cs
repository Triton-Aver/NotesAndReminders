using Microsoft.AspNetCore.Http;
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
    }
}
