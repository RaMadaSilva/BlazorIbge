using Challenge.Ibge.Blazor.Service.Dtos;

namespace Challenge.Ibge.Blazor.Service.Results;

public class Result
{
    public string Message { get; set; } = String.Empty;
    public object? Data { get; set; }
}