using System.Collections;
using System.Collections.Generic;
using NotesApp.Skeleton.Model;

namespace NotesApp.Skeleton.Repository
{
    public interface INoteRepository
    {
        IEnumerable<Note> GetNotes();

        void Save(Note note);
    }
}