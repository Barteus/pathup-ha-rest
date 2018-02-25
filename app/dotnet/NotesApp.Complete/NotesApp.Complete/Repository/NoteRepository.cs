using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using NotesApp.Complete.Model;

namespace NotesApp.Complete.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly IAmazonDynamoDB _amazonDynamoDb;

        public NoteRepository(IAmazonDynamoDB amazonDynamoDb)
        {
            _amazonDynamoDb = amazonDynamoDb;
        }

        public async Task<IEnumerable<Note>> GetNotes()
        {
            var scanResponse = await _amazonDynamoDb.ScanAsync("Notes", new List<string>() { "Id", "Username", "Content" });
            return scanResponse.Items.Select(item =>
                new Note()
                {
                    Id = item["Id"].S,
                    Content = item["Content"].S,
                    Username = item["Username"].S
                });
        }

        public async Task Save(Note note)
        {
            var attributes = new Dictionary<string, AttributeValue>()
            {
                {"Id", new AttributeValue(note.Id)},
                {"Username", new AttributeValue(note.Username)},
                {"Content", new AttributeValue(note.Content)},
            };
            await _amazonDynamoDb.PutItemAsync("Notes", attributes);
        }

    }
}