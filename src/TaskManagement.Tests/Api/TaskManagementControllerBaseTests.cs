using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Output;
using TaskManagement.Tests.Api;

namespace TeskManagement.Tests.Api;

public class TaskManagementControllerBaseTests
{
    private TestExampleController _controller;

    public TaskManagementControllerBaseTests()
    {
        _controller = new TestExampleController();
    }

    [Fact]
    public async Task WhenResultIsSuccess_ShouldReturn_OkObjectResult()
    {
        var result = Result<TestExampleModel>.Success(new());

        var response = _controller.SendResponseTestMethod(result);

        Assert.NotNull(response);
        Assert.IsType<OkObjectResult>(response);
    }

    [Fact]
    public async Task WhenResultIsClientError_ShouldReturn_BadRequestObjectResult()
    {
        var result = Result<TestExampleModel>.ClientError([new("Test Error")]);

        var response = _controller.SendResponseTestMethod(result);

        Assert.NotNull(response);
        Assert.IsType<BadRequestObjectResult>(response);
    }

    [Fact]
    public async Task WhenResultIsServerError_ShouldReturn_InternalServerErrorObjectResult()
    {
        var result = Result<TestExampleModel>.ServerError("Test Server Error");

        var response = _controller.SendResponseTestMethod(result);

        Assert.NotNull(response);
        Assert.IsType<ObjectResult>(response);
        var objectResult = response as ObjectResult;
        Assert.Equal(500, objectResult.StatusCode);
        Assert.Equal("Test Server Error", objectResult.Value);
    }

    [Fact]
    public async Task WhenResultIsNotFound_ShouldReturn_NotFoundObjectResult()
    {
        var result = Result<TestExampleModel>.NotFound();

        var response = _controller.SendResponseTestMethod(result);

        Assert.NotNull(response);
        Assert.IsType<NotFoundResult>(response);
    }

    [Fact]
    public async Task WhenResultIsCreated_ShouldReturn_CreatedObjectResult()
    {
        var result = Result<TestExampleModel>.Created(new(),"/api/teste/123");

        var response = _controller.SendResponseTestMethod(result);

        Assert.NotNull(response);
        Assert.IsType<CreatedResult>(response);
    }

    [Fact]
    public async Task WhenResultIsNoContent_ShouldReturn_NoContentResult()
    {
        var result = Result<TestExampleModel>.NoContent();

        var response = _controller.SendResponseTestMethod(result);

        Assert.NotNull(response);
        Assert.IsType<NoContentResult>(response);
    }
}
