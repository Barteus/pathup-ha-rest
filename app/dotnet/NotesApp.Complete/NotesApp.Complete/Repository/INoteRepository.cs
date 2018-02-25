using System.Collections.Generic;
using System.Threading.Tasks;
using NotesApp.Complete.Model;

namespace NotesApp.Complete.Repository
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetNotes();

        Task Save(Note note);
    }
}