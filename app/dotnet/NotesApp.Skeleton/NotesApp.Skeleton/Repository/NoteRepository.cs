using System.Collections.Generic;
using System.Linq;
using NotesApp.Skeleton.Model;

namespace NotesApp.Skeleton.Repository
{
    public class NoteRepository : INoteRepository
    {
        static List<Note> Notes = new List<Note>();

        public IEnumerable<Note> GetNotes()
        {
            return Notes.ToList();
        }

        public void Save(Note note)
        {
            Notes.Add(note);
        }
        
    }
}