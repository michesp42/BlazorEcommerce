namespace BlazorEcommerce.Shared;

public class ServiceResponse<T>
{
    public T? Data { get; set; }
    public bool Sources { get; set; } = true;
    public string Message { get; set; } = string.Empty;
}
