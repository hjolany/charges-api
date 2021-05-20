using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways;
using BaseApi.V1.UseCase.Interfaces;

namespace BaseApi.V1.UseCase
{
    //TODO: Rename class name and interface name to reflect the entity they are representing eg. GetAllClaimantsUseCase
    public class GetAllUseCase : IGetAllUseCase
    {
        private readonly IChargeGateway _gateway;
        public GetAllUseCase(IChargeGateway gateway)
        {
            _gateway = gateway;
        }

        public ChargeResponseObjectList Execute()
        {
            return new ChargeResponseObjectList { ChargeResponseObjects = _gateway.GetAll().ToResponse() };
        }
    }
}
