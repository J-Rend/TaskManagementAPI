using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using TaskManagement.Api.Controllers.Base;
using TaskManagement.Api.Request.Reports;
using TaskManagement.Application.UseCases.Reports.TaskReportByUser;

namespace TaskManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[ExcludeFromCodeCoverage]
[Produces("application/json")]
[Tags("Reports")]
public class ReportsController : TaskManagementControllerBase
{
    /// <summary>
    /// Gera um relatório de tarefas por usuário dentro de um intervalo de datas.
    /// </summary>
    /// <param name="useCaseHandler">Handler responsável por executar o relatório.</param>
    /// <param name="request">Parâmetros do relatório (datas e identificador do usuário).</param>
    /// <param name="cancellationToken">Token de cancelamento.</param>
    /// <returns>Relatório de tarefas realizadas pelo usuário.</returns>
    [Authorize(Roles = "Manager,Gerente")]
    [HttpGet("tasks-by-user")]
    [ProducesResponseType(typeof(TaskReportByUserOutput), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GenerateTaskReportByUser(
        [FromServices] ITaskReportByUserHandler useCaseHandler,
        [FromQuery] TaskReportByUserRequest request,
        CancellationToken cancellationToken)
    {
        var input = new TaskReportByUserInput(
            request.StartDate,
            request.EndDate,
            request.UserIdentifier
        );

        var result = await useCaseHandler.ExecuteAsync(input, cancellationToken);

        return SendResponse(result);
    }
}
