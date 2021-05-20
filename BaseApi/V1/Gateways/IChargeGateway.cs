using System.Collections.Generic;
using BaseApi.V1.Domain;

namespace BaseApi.V1.Gateways
{
    public interface IChargeGateway
    {
        Charge GetEntityById(int id);

        List<Charge> GetAll();

        /*void Add(Charge entity);
        void Remove(Charge entity);
        void Update(int id, Charge entity);*/
    }
}
