using Microsoft.AspNetCore.Mvc;
using NotesAndReminders.DataBase.Models;
using NotesAndReminders.Server.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NotesAndReminders.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TageController : ControllerBase
    {
        private readonly ILogger<TageController> _logger;
        private readonly ITageRepository _tageRepo;
        public TageController(ITageRepository tageRepo, ILogger<TageController> logger)
        {
            _tageRepo = tageRepo;
            _logger = logger;
        }

        // GET: api/<TageController>
        [HttpGet]
        public IEnumerable<Tage> Get()
        {
            IEnumerable<Tage> tage = _tageRepo.GetAll();
            return tage.ToArray();
        }
        
        // POST api/<TageController>
        [HttpPost]
        public IActionResult Post(Tage tage)
        {
            if (ModelState.IsValid)
            {
                _tageRepo.Add(tage);
                _tageRepo.Save();
                return Ok(tage);
            }
            return BadRequest(ModelState);
        }        

        // DELETE api/<TageController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Tage tage = _tageRepo.Find(id);
            if (tage != null)
            {
                _tageRepo.Remove(tage);
                _tageRepo.Save();
            }
            return Ok(tage);
        }
    }
}
