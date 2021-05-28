using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public List<Charge> GetAllCharges()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Charge>> GetAllChargesAsync()
        {
            ScanCondition scanCondition = new ScanCondition("Id", Amazon.DynamoDBv2.DocumentModel.ScanOperator.GreaterThan, new Guid("00000000-0000-0000-0000-000000000000"));

            List<ScanCondition> scanConditions = new List<ScanCondition>() {
                scanCondition
            };
            //List<ChargeDbEntity> data = await _dynamoDbContext.ScanAsync<ChargeDbEntity>(scanConditions).GetRemainingAsync().ConfigureAwait(false);

            ScanFilter scanFilter = new ScanFilter();
            scanFilter.AddCondition("Id", ScanOperator.GreaterThan, new Guid("00000000-0000-0000-0000-000000000000"));

            ScanOperationConfig scanOperationConfig = new ScanOperationConfig() {
                Limit = 2/*,
                Filter=scanFilter*/
            };

            List<ChargeDbEntity> data =
                await _dynamoDbContext
                .FromScanAsync<ChargeDbEntity>(scanOperationConfig)
                .GetRemainingAsync()
                .ConfigureAwait(false);

            return data.Select(p=>p.ToDomain()).ToList();
        }

        public Charge GetChargeById(Guid id)
        {
            var result = _dynamoDbContext.LoadAsync<ChargeDbEntity>(id).GetAwaiter().GetResult();
            return result?.ToDomain();
        }

        public async Task<Charge> GetChargeByIdAsync(Guid id)
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
