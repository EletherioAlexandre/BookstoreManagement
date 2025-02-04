namespace GerenciadorDeLivraria.Entities;
public class ApiResponse
{
    public bool Success { get; set; }
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
}

public class ApiResponse<T> : ApiResponse
{
    public T Data { get; set; }
}
