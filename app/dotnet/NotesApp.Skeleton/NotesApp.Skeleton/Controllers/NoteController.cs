using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NotesApp.Skeleton.Model;
using NotesApp.Skeleton.Repository;

namespace NotesApp.Skeleton.Controllers
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
        public IEnumerable<Note> Get()
        {
            return _noteRepository.GetNotes();
        }
       
        [HttpPost]
        public void Post(Note model)
        {
            _noteRepository.Save(model);
        }
    }
}
