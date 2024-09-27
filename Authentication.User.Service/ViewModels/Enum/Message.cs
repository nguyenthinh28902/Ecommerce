using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.Service.ViewModels.Enum
{
    public class Message
    {
        public const string MessageNotFoundUserLogin = "Đăng nhập trước khi thực hiện";
        public const string MessageCreateSuccess = "Đăng ký thành công.";
        public const string MessageSiginSuccess = "Đăng nhập thành công.";
        public const string MessageCreateFailure = "Đăng ký thất bại.";
        public const string MessageSiginFailure = "Đăng nhập thất bại.";
        public const string MessageInforFailure = "Người dùng không tồn tại.";
    }
}
