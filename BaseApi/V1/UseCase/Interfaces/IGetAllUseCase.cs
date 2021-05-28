using BaseApi.V1.Boundary.Response;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IGetAllUseCase
    {
        public ChargeResponseObjectList Execute();
        public Task<ChargeResponseObjectList> ExecuteAsync();
    }
}

