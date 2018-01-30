package com.bpk.notes.repository;

import com.bpk.notes.model.Note;

public interface NoteRepository {

    Iterable<Note> findAll();

    <S extends Note> S save(S entity);
}
