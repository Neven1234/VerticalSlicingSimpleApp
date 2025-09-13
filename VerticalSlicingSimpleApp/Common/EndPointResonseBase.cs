using VerticalSlicingSimpleApp.Common.Enums;

namespace VerticalSlicingSimpleApp.Common
{
    public record EndPointResonseBase<T>(T Data, bool IsSuccess, string message, ErrorCode ErrorCode)
    {
        public static EndPointResonseBase<T> Success(T data, string message = "")
        {
            return new EndPointResonseBase<T>(data, true, message, ErrorCode.NoError);
        }
        public static EndPointResonseBase<T> Failure(string message, ErrorCode errorCode = ErrorCode.NoError)
        {
            return new EndPointResonseBase<T>(default, false, message, errorCode);
        }
        public static EndPointResonseBase<T> Failure(ErrorCode errorCode)
        {
            return new EndPointResonseBase<T>(default, false, string.Empty, errorCode);
        }
    }
}
