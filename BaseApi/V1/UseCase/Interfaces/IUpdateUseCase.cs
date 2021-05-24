using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Domain;

namespace BaseApi.V1.UseCase.Interfaces
{
    public interface IUpdateUseCase
    {
        ChargeResponseObject Execute(Charge charge);
    }
}
