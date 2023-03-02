using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoBackendBLL.DTO.Request;
using TodoBackendBLL.DTO.Response;
using TodoBackendBLL.Services.Interfaces;

namespace TodoBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoCollectionController : ControllerBase
    {
        private readonly IToDoCollectionService Service;
        //
        public ToDoCollectionController(IToDoCollectionService service)
        {
            Service = service;
        }

        [HttpGet("Id",Name = "Get collection by id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult<ToDoCollectionResponse>> GetCollectionById(int id)
        {
            try
            {
                var item = await Service.GetCollection(id);
                if (item != null)
                {
                    return Ok(item);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }
        //
        [HttpPost(Name = "Add Collection")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult> AddBook([FromQuery] ToDoCollectionRequest request)
        {
            try
            {
                await Service.AddCollection(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }
        //
        [HttpPut(Name = "Update Collection")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult> UpdateCollection([FromQuery] ToDoCollectionRequest request)
        {
            try
            {
                await Service.UpdateCollection(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }
        //
        [HttpDelete("Id", Name = "Delete collection by id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<ActionResult> DeleteCollectionById(int id)
        {
            try
            {
                await Service.DeleteCollection(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message });
            }
        }
    }
}
