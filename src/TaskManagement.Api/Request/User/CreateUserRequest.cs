﻿namespace TaskManagement.Api.Request.User;

public class CreateUserRequest
{
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}