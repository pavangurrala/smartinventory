namespace SmartInventory.Api.Middlewares
{
    public sealed class ApiErrorResponse
    {
        public int StatusCode { get; init; }
        public string Message { get; init;  }
        public string? Detail { get; init;  }
        public string TraceId { get; init;  }

    }
}
