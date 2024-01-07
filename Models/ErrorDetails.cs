﻿using System.Text.Json;

namespace BlogApi.Models;

public class ErrorDetails
{
    public string StatusCode { get; set; }
    public string Message { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}