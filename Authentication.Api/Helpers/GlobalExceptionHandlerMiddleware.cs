using Authentication.User.Service.Helpers.Exceptions;

namespace Authentication.Api.Helpers
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // Thực thi các middleware khác trong pipeline
                await _next(context);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ tại đây
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Đặt mã trạng thái HTTP
            context.Response.StatusCode = exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,       // 404 - Không tìm thấy
                BadRequestException => StatusCodes.Status400BadRequest,   // 400 - Yêu cầu không hợp lệ
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized, // 401 - Không có quyền truy cập
                ForbiddenException => StatusCodes.Status403Forbidden,     // 403 - Cấm truy cập
                _ => StatusCodes.Status500InternalServerError             // 500 - Lỗi hệ thống
            };

            context.Response.ContentType = "application/json";

            // Tạo nội dung phản hồi lỗi
            var result = new
            {
                error = exception.Message
            };

            return context.Response.WriteAsJsonAsync(result);
        }
    }

}
