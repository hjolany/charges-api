using BaseApi.V1.Boundary.Response;
using BaseApi.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BaseApi.V1.Controllers
{
    [ApiController]
    //TODO: Rename to match the APIs endpoint
    [Route("api/v1/charges")]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    //TODO: rename class to match the API name
    public class ChargeApiController : BaseController
    {
        private readonly IGetAllUseCase _getAllUseCase;
        private readonly IGetByIdUseCase _getByIdUseCase;
        private readonly IAddUseCase _addUseCase;
        private readonly IRemoveUseCase _removeUseCase;
        private readonly IUpdateUseCase _updateUseCase;

        public ChargeApiController(
            IGetAllUseCase getAllUseCase,
            IGetByIdUseCase getByIdUseCase,
            IAddUseCase addUseCase,
            IRemoveUseCase removeUseCase,
            IUpdateUseCase updateUseCase
        )
        {
            _getAllUseCase = getAllUseCase;
            _getByIdUseCase = getByIdUseCase;
            _addUseCase = addUseCase;
            _removeUseCase = removeUseCase;
            _updateUseCase = updateUseCase;
        }
        /// <summary>
        /// Correspondig charge data according the id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ChargeResponseObject),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetChargeByIdAsunc(int id)
        {
            var charge = await _getByIdUseCase.ExecuteAsync(id).ConfigureAwait(false);
            if (charge == null)
                return NotFound(id);
            return Ok(charge);
        }


        //TODO: add xml comments containing information that will be included in the auto generated swagger docs (https://github.com/LBHackney-IT/lbh-base-api/wiki/Controllers-and-Response-Objects)
        /// <summary>
        /// ...
        /// </summary>
        /// <response code="200">...</response>
        /// <response code="400">Invalid Query Parameter.</response>
        [ProducesResponseType(typeof(ChargeResponseObjectList), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult ListContacts()
        {
            return Ok(_getAllUseCase.Execute());
        }

        /// <summary>
        /// ...
        /// </summary>
        /// <response code="200">...</response>
        /// <response code="404">No ? found for the specified ID</response>
        [ProducesResponseType(typeof(ChargeResponseObject), StatusCodes.Status200OK)]
        [HttpGet]
        //TODO: rename to match the identifier that will be used
        [Route("{yourId}")]
        public IActionResult ViewRecord(int yourId)
        {
            return Ok(_getByIdUseCase.Execute(yourId));
        }
    }
}
