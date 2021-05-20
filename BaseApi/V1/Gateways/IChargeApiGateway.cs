using System.Collections.Generic;
using BaseApi.V1.Domain;

namespace BaseApi.V1.Gateways
{
    public interface IChargeApiGateway
    {
        public Charge GetEntityById(int id);

        public List<Charge> GetAll();

        /*void Add(Charge entity);
        void Remove(Charge entity);
        void Update(int id, Charge entity);*/
    }
}
