﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ExpenseRecord.Models
{
    [BsonIgnoreExtraElements]
    public class ExpenseRecords
    {
        [BsonId]
        /*        public string Id { get; set; } = Guid.NewGuid().ToString();*/
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Amount { get; set; }

        [BsonRepresentation(BsonType.String)]
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
    }
}
