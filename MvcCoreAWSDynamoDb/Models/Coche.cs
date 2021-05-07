using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSDynamoDb.Models
{
    [DynamoDBTable("coches")]
    public class Coche
    {
        [DynamoDBProperty("IdCoche")]
        [DynamoDBHashKey]
        public int Id { get; set; }
        [DynamoDBProperty("Marca")]
        public String Marca { get; set;}
        [DynamoDBProperty("Modelo")]
        public String Modelo { get; set; }
        [DynamoDBProperty("VelocidadMaxima")]
        public int VelocidadMax { get; set; }
    }
}
