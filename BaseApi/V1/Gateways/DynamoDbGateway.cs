using Amazon.DynamoDBv2.DataModel;
using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Infrastructure;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace BaseApi.V1.Gateways
{
    public class DynamoDbGateway : IChargeApiGateway
    {
        private readonly IDynamoDBContext _dynamoDbContext;

        public DynamoDbGateway(IDynamoDBContext dynamoDbContext)
        {
            _dynamoDbContext = dynamoDbContext;
        }

        public List<Charge> GetAll()
        {
            return new List<Charge>();
        }

        public Charge GetEntityById(int id)
        {
            var result = _dynamoDbContext.LoadAsync<ChargeDbEntity>(id).GetAwaiter().GetResult();
            return result?.ToDomain();
        }
    }
}
