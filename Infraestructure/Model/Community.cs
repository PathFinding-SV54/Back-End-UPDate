﻿using System.Diagnostics.CodeAnalysis;

namespace Infrastructure.Model;

public class Community
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateOnly CreatedAt { get; set; }
    
    public  bool IsActive { get; set; }

}