using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Nantero.Global;

namespace Nantero.Models
{
    public class User : IDatabaseObject
    {
        public ObjectId Id { get; set; }

        /// <summary>
        /// Example for a specialized field that is not present in pactas.itero and needs further validation.
        /// </summary>
        public string Subdomain { get; set; }

        public bool IsActive { get; set; }

        [BsonIgnoreIfNull]
        public string PactasContractId { get; set; }
    }
}