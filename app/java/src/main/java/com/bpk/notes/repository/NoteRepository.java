package com.bpk.notes.repository;

import com.bpk.notes.model.Note;
import jdk.Exported;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.rest.core.annotation.RepositoryRestResource;

import javax.transaction.Transactional;

@RepositoryRestResource(exported = false)
@Transactional
public interface NoteRepository extends CrudRepository<Note, Integer> {

}
