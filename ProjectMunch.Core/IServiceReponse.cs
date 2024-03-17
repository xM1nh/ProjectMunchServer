namespace ProjectMunch.Domain
{
    public enum ServiceResponseType { }

    public interface IServiceReponse<TData, TResponse> 
        where TResponse : Enum 
        where TData : class
    {
        bool IsSuccess { get; set; }
        bool IsError { get; set; }
        TData? Data { get; set; }
        string? Error { get; set; }
    }
}
