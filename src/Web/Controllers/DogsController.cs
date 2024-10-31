using Core.Contracts;
using Core.Entities;
using Core.Exceptions;
using Core.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Constants;

namespace Web.Controllers
{
    [ApiController]
    public class DogsController(
        IDoggieService _doggieService,
        ILogger<DogsController> _logger) : ControllerBase
    {
        [HttpGet("dogs")]
        public async Task<IActionResult> GetDogs(
            [FromQuery] string attribute = Sorting.Name,
            [FromQuery] string order = Sorting.Ascending,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = Pagination.PageSize)
        {
            try
            {
                var response = await _doggieService.GetDoggies(attribute, order, pageNumber, pageSize);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Get dogs request failed");
                throw;
            }
        }

        [HttpPost("dog")]
        public async Task<IActionResult> AddDog(AddDogRequest request)
        {
            try
            {
                await _doggieService.AddDoggie(request);
                return Ok();
            }
            catch (Exception ex) when (ex 
                is EmptyNameException 
                or NameTooLongException 
                or EmptyColorException 
                or ColorTooLongException 
                or InvalidTailLengthException 
                or InvalidWeightException
                or NameTakenException)
            {
                _logger.LogWarning(ex,
                    "Add dog request for {request} failed", request);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                    "Add dog request for {request} failed", request);
                throw;
            }
        }
    }
}
