package com.bpk.notes.rest;

import com.bpk.notes.model.Note;
import com.bpk.notes.repository.NoteRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.util.LinkedMultiValueMap;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import java.util.Collections;
import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.StreamSupport;

@RestController
@RequestMapping("/notes")
public class NoteRestController {

    @Qualifier("dynamoDBNoteRepository")
    @Autowired
    private NoteRepository repository;

    @Value("${server.name}")
    private String serverName;

    @CrossOrigin
    @RequestMapping(value = {""}, method = RequestMethod.GET, produces = "application/json")
    public ResponseEntity<List<Note>> getNotes() {
        final List<Note> notes = StreamSupport.stream(repository.findAll().spliterator(), false)
                                              .collect(Collectors.toList());

        return new ResponseEntity<>(notes, headers(), HttpStatus.OK);
    }

    @CrossOrigin
    @RequestMapping(value = "", method = RequestMethod.POST, consumes = "application/json", produces = "application/json")
    public ResponseEntity<Note> postNote(@RequestBody Note note) {
        final Note result = repository.save(note);
        return new ResponseEntity<>(result, headers(), HttpStatus.OK);
    }

    private LinkedMultiValueMap<String, String> headers() {
        final LinkedMultiValueMap<String, String> headers = new LinkedMultiValueMap<>();
        headers.put("server-name", Collections.singletonList(serverName));
        headers.put("app-version", Collections.singletonList("1.1"));
        return headers;
    }

}
