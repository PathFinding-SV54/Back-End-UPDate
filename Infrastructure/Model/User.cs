﻿namespace Infrastructure.Model;

public class User: BaseModel
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Roles { get; set; }
    
}