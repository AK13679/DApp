using Microsoft.AspNetCore.SignalR;

namespace API.Entities;

public class UserDto
{
    public required string Username { get; set; }
    public required string KnownAs { get; set; }
    public required string Token { get; set; } 
    public string? PhotoUrl { get; set; }
}