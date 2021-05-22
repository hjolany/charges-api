using System.Collections.Generic;
using BaseApi.V1.Domain;

namespace BaseApi.V1.Gateways
{
    public interface IChargeApiGateway
    {
        public Charge GetEntityById(int id);

        public List<Charge> GetAll();

        public void Add(Charge entity);
        public void Remove(Charge entity);
        public void Update(Charge entity);
        public void SaveChanges();
    }
}
