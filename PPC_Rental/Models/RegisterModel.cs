using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPC_Rental.Models
{
    public class RegisterModel
    {   [Key]
        public long ID { set; get; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Yêu cầu nhập đúng định dạng email")]
        [Required(ErrorMessage ="Yêu cầu nhập Email")]
        public string Email { set; get; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Yêu cầu nhập Password")]
        [StringLength(20,MinimumLength =6,ErrorMessage ="Độ dài mật khẩu ít nhất là 6 kí tự")]
        public string Password { set; get; }

        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage ="Xác nhận mật khẩu không đúng")]
        public string ConfirmPassword { set; get; }

        [Display(Name = "Fullname")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên")]
        public string FullName { set; get; }

        [Display(Name = "Phone")]
        [Phone(ErrorMessage = "Yêu cầu nhập đúng định dạng số điện thoại")]
        [Required(ErrorMessage = "Yêu cầu nhập số điện thoại")]
        public string Phone { set; get; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Yêu cầu nhập địa chỉ")]
        public string Address { set; get; }
    }
}