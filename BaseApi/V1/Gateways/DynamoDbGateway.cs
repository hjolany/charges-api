using Amazon.DynamoDBv2.DataModel;
using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseApi.V1.Gateways
{
    public class DynamoDbGateway : IChargeApiGateway
    {
        private readonly IDynamoDBContext _dynamoDbContext;

        public DynamoDbGateway(IDynamoDBContext dynamoDbContext)
        {
            _dynamoDbContext = dynamoDbContext;
        }

        public void Add(Charge charge)
        {
            _dynamoDbContext.SaveAsync<ChargeDbEntity>(charge.ToDatabase());
        }

        public async Task AddAsync(Charge charge)
        {
            await _dynamoDbContext.SaveAsync<ChargeDbEntity>(charge.ToDatabase()).ConfigureAwait(false);
        }

        public void AddRange(List<Charge> charges)
        {
            charges.ForEach(e =>
            {
                _dynamoDbContext.SaveAsync<ChargeDbEntity>(e.ToDatabase());
            });
        }

        public async Task AddRangeAsync(List<Charge> charges)
        {
            foreach (Charge charge in charges)
            {
                await _dynamoDbContext.SaveAsync<ChargeDbEntity>(charge.ToDatabase()).ConfigureAwait(false);
            }
        }

        public List<Charge> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Charge>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Charge GetEntityById(Guid id)
        {
            var result = _dynamoDbContext.LoadAsync<ChargeDbEntity>(id).GetAwaiter().GetResult();
            return result?.ToDomain();
        }

        public async Task<Charge> GetEntityByIdAsync(Guid id)
        {
            var result = await _dynamoDbContext.LoadAsync<ChargeDbEntity>(id).ConfigureAwait(false);
            return result?.ToDomain();
        }

        public void Remove(Charge charge)
        {
            _dynamoDbContext.DeleteAsync<ChargeDbEntity>(charge.ToDatabase());
        }

        public async Task RemoveAsync(Charge charge)
        {
            await _dynamoDbContext.DeleteAsync(charge.ToDatabase()).ConfigureAwait(false);
        }

        public void RemoveRange(List<Charge> charges)
        {
            charges.ForEach(c =>
            {
                Remove(c);
            });
        }

        public async Task RemoveRangeAsync(List<Charge> charges)
        {
            foreach (Charge c in charges)
            {
                await RemoveAsync(c).ConfigureAwait(false);
            }
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Charge charge)
        {
            _dynamoDbContext.SaveAsync<ChargeDbEntity>(charge.ToDatabase()).ConfigureAwait(false);
        }

        public async Task UpdateAsync(Charge charge)
        {
            await _dynamoDbContext.SaveAsync<ChargeDbEntity>(charge.ToDatabase()).ConfigureAwait(false);
        }
    }
}
