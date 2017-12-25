using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPC_Rental.Models
{
    public class CPass
    {

        [Key]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu hiện tại")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu hiện tại")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu mới")]
        [StringLength(100, ErrorMessage = "Mật khẩu tối đa {0} ký tự và tối thiểu {2} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác thực mật khẩu mới")]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu mới và xác thực mật khẩu mới không khớp.")]
        public string ConfirmPassword { get; set; }
    }
}