using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPC_Rental.Models.FixBug
{
    public class PostModel
    {
        [Key]
        public long ID { set; get; }
        [Display(Name = "Property Name")]
        [Required(ErrorMessage = "Bạn phải nhập tên của dự án")]
        public string PropertyName { set; get; }

        [Display(Name = "Avatar")]
        [Required(ErrorMessage = "Bạn phải chọn avatar cho dự án")]       
        public string Avatar { set; get; }

        [Display(Name = "Property Type")]
        public string PropertyType { set; get; }

        [Display(Name = "Content")]
        [Required(ErrorMessage = "Yêu cầu nhập nội dung của dự án")]
        public string Content { set; get; }

        [Display(Name = "District")]
        public string District { set; get; }

        [Display(Name = "Ward")]
        public string Ward { set; get; }

        [Display(Name = "Street")]
        public string Street { set; get; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Bạn phải nhập giá")]
        public string Price { set; get; }


        [Display(Name = "Area")]
        [Required(ErrorMessage = "Bạn phải nhập diện tích")]
        public string Area { set; get; }

        [Display(Name = "Bed rooms")]
        [Required(ErrorMessage = "Bạn phải nhập số phòng ngủ")]
        public string Bedroom { set; get; }

        [Display(Name = "Bath rooms")]
        [Required(ErrorMessage = "Bạn phải nhập số phòng tắm")]
        public string Bathroom { set; get; }

        [Display(Name = "ParkingPlace")]
        [Required(ErrorMessage = "Bạn phải nhập số chỗ để xe")]
        public string ParkingPlace { set; get; }
    }
}