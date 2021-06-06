
namespace API.Errors
{
    public class ApiObjectResponse<T> : ApiResponse
    {
        public ApiObjectResponse(int statusCode, T result, string message = null) : base(statusCode, message)
        {
            Result = result;
        }

        public T Result { get; set; }
    }
}
