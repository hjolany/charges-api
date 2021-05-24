using System.Collections.Generic;
using System.Threading.Tasks;
using BaseApi.V1.Domain;

namespace BaseApi.V1.Gateways
{
    public interface IChargeApiGateway
    {
        public Charge GetEntityById(int id);
        public Task<Charge> GetEntityByIdAsync(int id);

        public List<Charge> GetAll();
        public Task<List<Charge>> GetAllAsync();

        public void Add(Charge charge);
        public Task AddAsync(Charge charge);
        public void AddRange(List<Charge> charges);
        public Task AddRangeAsync(List<Charge> charges);

        public void Remove(Charge charge);
        public void RemoveRange(List<Charge> charges);

        public void Update(Charge charge);

        public void SaveChanges();
    }
}
