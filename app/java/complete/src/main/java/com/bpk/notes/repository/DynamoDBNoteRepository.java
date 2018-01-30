package com.bpk.notes.repository;

import com.amazonaws.services.dynamodbv2.datamodeling.DynamoDBMapper;
import com.amazonaws.services.dynamodbv2.datamodeling.DynamoDBScanExpression;
import com.bpk.notes.model.Note;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

@Repository
public class DynamoDBNoteRepository implements NoteRepository {

    @Autowired
    private DynamoDBMapper dbMapper;

    @Override
    public Iterable<Note> findAll() {
        return dbMapper.scan(Note.class, new DynamoDBScanExpression());
    }

    @Override
    public <S extends Note> S save(S entity) {
        dbMapper.save(entity);
        return entity;
    }
}
