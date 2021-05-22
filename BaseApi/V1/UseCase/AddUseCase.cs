using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Domain;
using BaseApi.V1.Factories;
using BaseApi.V1.Gateways;
using BaseApi.V1.UseCase.Interfaces;

namespace BaseApi.V1.UseCase
{
    //TODO: Rename class name and interface name to reflect the entity they are representing eg. GetAllClaimantsUseCase
    public class AddUseCase : IAddUseCase
    {
        private readonly IChargeApiGateway _gateway;
        public AddUseCase(IChargeApiGateway gateway)
        {
            _gateway = gateway;
        }

        public ChargeResponseObjectList Execute(Charge charge)
        {
            return new ChargeResponseObjectList {
                ChargeResponseObjects = _gateway.Add(charge)
            };
        }
    }
}
