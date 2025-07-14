using Microsoft.AspNetCore.Mvc;
using TaskManagement.Api.Controllers.Base;
using TaskManagement.Application.Output;

namespace TeskManagement.Tests.Api;

public class TestExampleController : TaskManagementControllerBase
{
    public IActionResult SendResponseTestMethod<T>(Result<T> result) where T : class
    {
        return SendResponse(result);
    }
}
