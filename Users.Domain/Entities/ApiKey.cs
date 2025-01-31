﻿namespace Users.Domain.Entities;

public class ApiKey
{
    public int Id { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
