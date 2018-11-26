﻿#if Movie
#region snippet_1
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BookMongo.Models
{
    public class Book
    {
        public ObjectId Id { get; set; }
        [BsonElement("BookId")]
        public int BookId { get; set; }
        [BsonElement("BookName")]
        public string BookName { get; set; }
        [BsonElement("Price")]
        public int Price { get; set; }
        [BsonElement("Category")]
        public string Category { get; set; }
        [BsonElement("Author")]
        public  string Author { get; set; }
    }
}
#endregion
#endif
