using TllApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace TllApi.Services
{
    public class SongService
    {
        private readonly IMongoCollection<Songs> _songs;

        public SongService(ITllApiDatabaseSettings settings)
        {   
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _songs = database.GetCollection<Songs>(settings.SongsCollectionName);
        }

        public List<Songs> Get() =>
            _songs.Find(song => true).ToList();

        public Songs Get(string id) =>
            _songs.Find<Songs>(song => song.Id == id).FirstOrDefault();

        public Songs Create(Songs song)
        {
            _songs.InsertOne(song);
            return song;
        }

        public void Update(string id, Songs songIn) =>
            _songs.ReplaceOne(song => song.Id == id, songIn);

        public void Remove(Songs songIn) =>
            _songs.DeleteOne(song => song.Id == songIn.Id);

        public void Remove(string id) => 
            _songs.DeleteOne(song => song.Id == id);
    }
}