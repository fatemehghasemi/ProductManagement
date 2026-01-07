namespace Domain.Common;

public class Result<T>
{
    public T Data { get; set; }
    public bool IsSuccess { get; set; }
    public int? Code { get; set; }
    public string? Message { get; set; }

    public static Result<T> Fail(string message, int code) => new Result<T>
    {
        IsSuccess = false,
        Message = message,
        Code = code
    };
    public static Result<T> Success(T Data) => new Result<T>
    {
        IsSuccess = true,
        Data = Data
    };
}
