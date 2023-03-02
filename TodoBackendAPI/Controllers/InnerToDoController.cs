using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoBackendBLL.DTO.Request;
using TodoBackendBLL.Services.Interfaces;

namespace TodoBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InnerToDoController : ControllerBase
    {
        private readonly IInnerToDoService Service;

        public InnerToDoController(IInnerToDoService service)
        {
            Service = service;
        }
        //
        [HttpPost(Name = "Add InnerToDo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult> AddToDo([FromQuery] InnerToDoRequest request)
        {
            try
            {
                await Service.AddInnerToDo(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }
        //
        [HttpPut(Name = "Update InnerToDo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult> UpdateToDo([FromQuery] InnerToDoRequest request)
        {
            try
            {
                await Service.UpdateInnerToDo(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }
        //
        [HttpDelete("Id", Name = "Delete InnerToDo by id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult> DeleteInnerToDoById(int id)
        {
            try
            {
                await Service.DeleteInnerToDo(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }
    }
}
