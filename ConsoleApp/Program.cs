using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Get server handle
            var client = new MongoClient("mongodb://localhost:27017");

            // Get database handle
            var database = client.GetDatabase("MyDatabase");

            // get collection handle
            var collection = database.GetCollection<BsonDocument>("MyCollection");

            var document = new BsonDocument
            {
                { "name", "MongoDB" },
                { "type", "Database" },
                { "count", 1 },
                { "info", new BsonDocument
                   {
                      { "x", 203 },
                      { "y", 102 }
                   }
                }
            };

            collection.InsertOne(document);

            var ret_document = collection.Find(new BsonDocument()).ToList();

            foreach(var doc in ret_document)
            Console.WriteLine(doc.ToString() + "\n");
        }
    }
}