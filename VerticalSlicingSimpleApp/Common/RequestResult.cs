using VerticalSlicingSimpleApp.Common.Enums;

namespace VerticalSlicingSimpleApp.Common
{
    public record RequestResult<T>(T Data, bool IsSuccess, string message, ErrorCode ErrorCode)
    {
        public static RequestResult<T> Success(T data, string message = "")
        {
            return new RequestResult<T>(data, true, message, ErrorCode.NoError);
        }
        public static RequestResult<T> Failure(string message, ErrorCode errorCode = ErrorCode.NoError)
        {
            return new RequestResult<T>(default, false, message, errorCode);
        }
        public static EndPointResonseBase<T> Failure(ErrorCode errorCode)
        {
            return new EndPointResonseBase<T>(default, false, string.Empty, errorCode);
        }
    }
}
