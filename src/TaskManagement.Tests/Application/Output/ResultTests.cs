using TaskManagement.Application.Output;
using TaskManagement.Tests.Api;

namespace TeskManagement.Tests.Application.Output;

public class ResultTests
{
    [Fact]
    public async Task WhenResultSuccessMethodIsInvoked_ShouldReturnResultSuccessStatus()
    {
        var result = Result<TestExampleModel>.Success(new());

        Assert.NotNull(result);
        Assert.Equal(ResultStatus.Success, result.Status);
    }

    [Fact]
    public async Task WhenResultErrorMethodIsInvoked_ShouldReturnResultErrorStatus()
    {
        var result = Result<TestExampleModel>.ClientError([new("Error test")]);

        Assert.NotNull(result);
        Assert.Equal(ResultStatus.ClientError, result.Status);
        Assert.NotEmpty(result.Errors);
    }
    [Fact]
    public async Task WhenResultServerErrorMethodIsInvokedWithException_ShouldReturnResultErrorStatus()
    {
        var result = Result<TestExampleModel>.ServerError("Test Server Error");

        Assert.NotNull(result);
        Assert.Equal(ResultStatus.ServerError, result.Status);
        Assert.Equal("Test Server Error", result.ServerErrorMessage);
    }

    [Fact]
    public async Task WhenResultCreatedMethodIsInvoked_ShouldReturnResultCreatedStatus()
    {
        var result = Result<TestExampleModel>.Created(new(), "test/resource/path");

        Assert.NotNull(result);
        Assert.Equal(ResultStatus.Created, result.Status);
        Assert.Equal("test/resource/path", result.ResourcePath);
    }

    [Fact]
    public async Task WhenResultNoContentMethodIsInvoked_ShouldReturnResultNoContentStatus()
    {
        var result = Result<TestExampleModel>.NoContent();

        Assert.NotNull(result);
        Assert.Equal(ResultStatus.NoContent, result.Status);
        Assert.Null(result.Data);
    }

    [Fact]
    public async Task WhenResultNotFoundMethodIsInvoked_ShouldReturnResultNotFoundStatus()
    {
        var result = Result<TestExampleModel>.NotFound();

        Assert.NotNull(result);
        Assert.Equal(ResultStatus.NotFound, result.Status);
        Assert.Null(result.Data);
    }
}
