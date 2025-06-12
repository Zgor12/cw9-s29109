using CW_9_s29109.Exceptions;
using CW_9_s29109.Services;
using Microsoft.AspNetCore.Mvc;

namespace CW_9_s29109.Controllers;


[ApiController]
[Route("api/[controller]")]
public class PatientsController(IDbService service) : ControllerBase
{

    [HttpGet("id")]
    public async Task<IActionResult> GetPatientDetailsAsync([FromRoute] int id)
    {
        try
        {

            return Ok(await service.GetPatientDetailsByIdAsync(id));

        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
}