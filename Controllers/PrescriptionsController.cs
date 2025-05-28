using CW_9_s29109.DTOs;
using CW_9_s29109.Exceptions;
using CW_9_s29109.Services;
using Microsoft.AspNetCore.Mvc;

namespace CW_9_s29109.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionsController(IDbService service) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> CreatePrescription([FromBody] PrescriptionCreateDto dto)
    {
        try
        {

            var prescription = await service.CreatePrescriptionAsync(dto);

            return CreatedAtAction(nameof(PrescriptionGetDto), new { id = prescription.IdPrescription }, prescription);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        
    }
    
}