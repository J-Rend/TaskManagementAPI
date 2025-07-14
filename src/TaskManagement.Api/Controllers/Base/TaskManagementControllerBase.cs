using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Output;

namespace TaskManagement.Api.Controllers.Base;

public abstract class TaskManagementControllerBase : ControllerBase
{
    protected IActionResult SendResponse<T>(Result<T> result) where T : class
    {
        switch (result.Status)
        {
            case ResultStatus.Success:
                return Ok(result.Data);
            case ResultStatus.Created:
                return Created(result.ResourcePath, result.Data);
            case ResultStatus.NoContent:
                return NoContent();
            case ResultStatus.NotFound:
                return NotFound();
            case ResultStatus.ClientError:
                return BadRequest(result.Errors);
            case ResultStatus.ServerError:
                return StatusCode(500, result.ServerErrorMessage);
            case ResultStatus.Forbidden:
                return Unauthorized();
            default:
                return StatusCode(500, "An unexpected error occurred.");
        }
    }
}
