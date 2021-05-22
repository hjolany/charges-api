using System.Collections.Generic;
using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Infrastructure;

namespace BaseApi.V1.Gateways
{
    //TODO: Rename to match the data source that is being accessed in the gateway eg. MosaicGateway
    public class ChargeApiGateway : IChargeApiGateway
    {
        private readonly ChargeContext _chargeDbContext;

        public ChargeApiGateway(ChargeContext chargeDbContext)
        {
            _chargeDbContext = chargeDbContext;
        }

        public Charge GetEntityById(int id)
        {
            var result = _chargeDbContext.ChargeEntities.Find(id);

            return result?.ToDomain();
        }

        public List<Charge> GetAll()
        {
            return new List<Charge>();
        }

        public void Add(Charge entity)
        {
            _chargeDbContext.ChargeEntities.Add(entity.ToDatabase());
        }

        public void Remove(Charge entity)
        {
            _chargeDbContext.ChargeEntities.Remove(entity.ToDatabase());
        }

        public void Update(Charge entity)
        {
            _chargeDbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void SaveChanges()
        {
            _chargeDbContext.SaveChanges();
        }
    }
}
