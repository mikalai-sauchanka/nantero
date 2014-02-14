using MongoDB.Bson;
using Nantero.Global;

namespace Nantero.Models
{
    public class ApiSettings : IDatabaseObject
    {
        public ObjectId Id { get; set; }
        public string AccessToken { get; set; }
    }
}