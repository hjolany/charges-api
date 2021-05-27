using BaseApi.V1.Boundary.Response;
using BaseApi.V1.Domain;
using BaseApi.V1.UseCase.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> GetChargeByIdAsunc(Guid id)
        {
            var charge = await _getByIdUseCase.ExecuteAsync(id).ConfigureAwait(false);
            if (charge == null)
                return NotFound(id);
            return Ok(charge);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> PostCharge(Charge charge)
        {
            await _addUseCase.ExecuteAsync(charge).ConfigureAwait(false);
            return CreatedAtAction("GetChargeByIdAsunc", new { id = charge.Id }, charge);
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<IActionResult> PutCharge([FromRoute]Guid id,[FromBody]Charge charge)
        {
            if (id != charge.Id)
                return NotFound(id);

            await _updateUseCase.ExecuteAsync(charge).ConfigureAwait(false);
            return CreatedAtAction("GetChargeByIdAsunc", new { id = charge.Id }, charge);
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> RemoveCharge([FromRoute]Guid id) {

            ChargeResponseObject charge = await _getByIdUseCase.ExecuteAsync(id).ConfigureAwait(false);
            if (charge == null)
                return NotFound(id);

            await _removeUseCase.ExecuteAsync(id).ConfigureAwait(false);
            return NoContent();
        }

    }
}
