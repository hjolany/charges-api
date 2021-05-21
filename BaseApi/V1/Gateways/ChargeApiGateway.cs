using System.Collections.Generic;
using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Infrastructure;

namespace BaseApi.V1.Gateways
{
    //TODO: Rename to match the data source that is being accessed in the gateway eg. MosaicGateway
    public class ChargeApiGateway : IChargeApiGateway
    {
        private readonly ChargeContext _databaseContext;

        public ChargeApiGateway(ChargeContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Charge GetEntityById(int id)
        {
            var result = _databaseContext.ChargeEntities.Find(id);

            return result?.ToDomain();
        }

        public List<Charge> GetAll()
        {
            return new List<Charge>();
        }

        /*public void Add(Charge entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(Charge entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Charge entity)
        {
            throw new System.NotImplementedException();
        }*/
    }
}
