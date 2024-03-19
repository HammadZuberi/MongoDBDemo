// See https://aka.ms/new-console-template for more information
using MongoDB.Driver;
using MongoDBDemo;

Console.WriteLine("Hello, World!");

string ConnectionString = "mongodb://127.0.0.1:27017";
string databaseName = "simple_db";
string collectionName = "people";

var client = new MongoClient(ConnectionString);
var db = client.GetDatabase(databaseName); //db
										   //table
var collection = db.GetCollection<PersonModel>(collectionName);

var person = new PersonModel { FirstName = "Tim ", LastName = "Corry" };

await collection.InsertOneAsync(person);
//find qall in the query 
var results = await collection.FindAsync(_ => true);

foreach (var result in results.ToList())

{
	Console.WriteLine($"Name {result.FirstName} and Lastname {result.LastName}");
}