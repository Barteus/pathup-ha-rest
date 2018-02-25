using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotesApp.Complete.Model;
using NotesApp.Complete.Repository;

namespace NotesApp.Complete.Controllers
{
    [Route("api/[controller]")]    
    [Produces("application/json")]
    public class NoteController : Controller
    {
        private readonly INoteRepository _noteRepository;

        public NoteController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Note>> Get()
        {
            return await _noteRepository.GetNotes();
        }
       
        [HttpPost]
        public async Task Post([FromBody] Note model)
        {
            await _noteRepository.Save(model);
        }
    }
}
