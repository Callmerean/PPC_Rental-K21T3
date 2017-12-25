using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPC_Rental.Models
{
    public class LoginModel
    {
        [Key]
        [Display(Name= "Email")]
        [Required(ErrorMessage ="Bạn phải đăng nhập tài khoản")]
        public string UserName { get; set; }
        
        [Display(Name ="Password")]
        [Required(ErrorMessage ="Bạn phải nhập mật khẩu")]
        public string Password { get; set; }
    }
}