using BaseApi.V1.Boundary.Response;
using System.Threading.Tasks;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IGetByIdUseCase
    {
        ChargeResponseObject Execute(int id);
        Task<ChargeResponseObject> ExecuteAsync(int id);
    }
}
