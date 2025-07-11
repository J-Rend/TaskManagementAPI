using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using TaskManagement.Application.UseCases.Project.CreateProject;
using TaskManagement.Application.UseCases.Project.GetUserProjects;
using TaskManagement.Application.UseCases.Project.RemoveProject;
using TaskManagement.Application.UseCases.Task.CreateTask;
using TaskManagement.Application.UseCases.Task.GetProjectTasks;
using TaskManagement.Application.UseCases.Task.RemoveTask;
using TaskManagement.Application.UseCases.Task.UpdateTaskComments;
using TaskManagement.Application.UseCases.Task.UpdateTaskStatus;

namespace TaskManagement.IoC.Injection;

[ExcludeFromCodeCoverage]
public static class ApplicationDependencyResolver
{
    public static IServiceCollection ConfigureApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped<ICreateProjectHandler, CreateProjectHandler>();
        services.AddScoped<IGetUserProjectsHandler, GetUserProjectsHandler>();
        services.AddScoped<IRemoveProjectHandler, RemoveProjectHandler>();

        services.AddScoped<ICreateTaskHandler, CreateTaskHandler>();
        services.AddScoped<IGetProjectTasksHandler, GetProjectTasksHandler>();
        services.AddScoped<IRemoveTaskHandler, RemoveTaskHandler>();
        services.AddScoped<IUpdateTaskCommentsHandler, UpdateTaskCommentsHandler>();
        services.AddScoped<IUpdateTaskStatusHandler, UpdateTaskStatusHandler>();

        return services;
    }
}
