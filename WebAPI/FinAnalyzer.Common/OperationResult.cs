using StafferyInternal.StafferyInternal.Common;

namespace FinAnalyzer.Common;

public class OperationResult
{
    public bool Success => ErrorCode == 0;

    public OperationCode ErrorCode { get; set; }
    public string? Message { get; set; }
    public string? StackTrace { get; set; }

    public static OperationResult OK => new OperationResult();

    //public static OperationResult Fail(OperationCode errorCode, string? message = null, string? stackTrace = null)
    //    => new OperationResult(errorCode, message, stackTrace);

    public static OperationResult<T> Fail<T>(OperationCode errorCode, string? message = null, string? stackTrace = null)
        => new(errorCode, message, stackTrace);

    public static OperationResult<T> Ok<T>(T result) => new(result);

    protected OperationResult()
    {
    }

    public OperationResult(OperationCode errorCode, string? message = null, string? stackTrace = null)
    {
        ErrorCode = errorCode;
        Message = message;
        StackTrace = stackTrace;
    }
}

public class OperationResult<T> : OperationResult
{
    public T? Result { get; set; }

    public static new OperationResult<T> Fail(OperationCode errorCode, string? message = null, string? stackTrace = null)
        => new OperationResult<T>(errorCode, message, stackTrace);

    public static OperationResult<T> Ok(T result) => new OperationResult<T>(result);

    public OperationResult()
    {
    }

    public OperationResult(T result)
    {
        Result = result;
    }

    public OperationResult(OperationCode errorCode, string? message = null, string? stackTrace = null)
        : base(errorCode, message, stackTrace)
    {
    }
}

