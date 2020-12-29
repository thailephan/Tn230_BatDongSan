using System.ComponentModel.DataAnnotations;

namespace TN230_BatDongSan.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { set; get; }
        public string Password { set; get; }
        public bool Rememberme { set; get; }
    }
}