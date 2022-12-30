using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using CallCenter.Models.ResponseModels;
using CallCenter.Services;

namespace CallCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
        public class ClientesController : ControllerBase
    {
        private readonly ClientesService _clienteServices;

        public ClientesController(ClientesService clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpGet]
        [Route("GetByCedula/{cedula}/{page}/{cantity}")]
        public async Task<ActionResult> GetByCedula([FromRoute] string cedula,int page, int cantity)
        {
            try
            {
                var result = (await _clienteServices.GetFilter(cedula,page,cantity).ConfigureAwait(false)) as GenericResponse;
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(new GenericResponse
                {
                    ErrorMessage=$"{e.Message?? string.Empty}",
                    OperationSucces=false
                });
            }
        }
    }
}
