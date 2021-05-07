using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using MvcCoreAWSDynamoDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreAWSDynamoDb.Services
{
    public class ServiceAWSDynamoDb
    {
        private DynamoDBContext context;
        public ServiceAWSDynamoDb()
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            this.context = new DynamoDBContext(client);
        }
        public async Task CreateCoche(Coche car)
        {
            await this.context.SaveAsync<Coche>(car);
        }
        public async Task<List<Coche>> GetCoches()
        {
            var tabla = this.context.GetTargetTable<Coche>();
            var scanOptions = new ScanOperationConfig();
            //scanOptions.PaginationToken = "";
            var results = tabla.Scan(scanOptions);
            List<Document> data = await results.GetNextSetAsync();
            IEnumerable<Coche> cars = this.context.FromDocuments<Coche>(data);
            return cars.ToList();
        }
        public async Task<Coche> FindCoche(int id)
        {
            return await this.context.LoadAsync<Coche>(id);
        }
        public async Task DeleteCoche(int id)
        {
            await this.context.DeleteAsync<Coche>(id);
        }
    }
}
