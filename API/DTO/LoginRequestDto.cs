using System;

namespace API.DTO;

public class LoginRequestDto
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}
