
namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "İşlem başarılı bir şekilde yapıldı.",
                400 => "Yanlış bir istekte bulunuldu.",
                401 => "Sisteme giriş yapmalısınız.",
                404 => "İstenilen sonuç bulunamadı.",
                500 => "Errors are the path to the dark side. Errors lead to anger. Anger leads to hate. Hate leads to career change",
                _ => null

            };
        }
    }
}
