package com.bpk.notes.rest;

import com.bpk.notes.model.Note;
import com.bpk.notes.repository.NoteRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping("/notes")
public class NoteRestController {

    @Autowired
    private NoteRepository noteRepository;

    @CrossOrigin
    @RequestMapping(value = {""}, method = RequestMethod.GET, produces = "application/json")
    public List<Note> getNotes() {
        Iterable<Note> all = noteRepository.findAll();
        List<Note> notes = new ArrayList<>();
        for (Note note : all) {
            notes.add(note);
        }
        return notes;
    }

    @CrossOrigin
    @RequestMapping(value = "", method = RequestMethod.POST, consumes = "application/json", produces = "application/json")
    public Note postNote(@RequestBody Note note) {
        Note saved = noteRepository.save(note);
        return saved;
    }
}
