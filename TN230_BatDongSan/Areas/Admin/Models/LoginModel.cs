using System.ComponentModel.DataAnnotations;

namespace TN230_BatDongSan.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Tài khoản không được trống")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được trống")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}