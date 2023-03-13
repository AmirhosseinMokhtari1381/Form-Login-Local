using System.ComponentModel.DataAnnotations;

namespace Contactus1.Models
{
    public class Message
    {
        [Display(Name= "نام و نام خانوادگی")]
        [Required(ErrorMessage ="{0} را وارد کنید")]
        public string FullName { get; set; }
        [Display(Name = "موضوع پیام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Subject { get; set; }
        [Display(Name = "شماره تماس")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MaxLength(11,ErrorMessage ="نامعتبر است {0}")]
        public string PhoneNumber { get; set; }
        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string MessageBody { get; set; }
        //[DataType(DataType.Password)]
        //public int COde { get; set; }

        //confirm phoneNumber Or Password
        //[Display(Name ="تکرار شماره تماس")]
        //[Required(ErrorMessage = "{0} را وارد کنید")]
        //[MaxLength(11)]

        //[Compare("PhoneNumber",ErrorMessage ="شماره موبایل یکسان نیست ")]
        //public int confirmPhoneNumber { get; set; }

    }

}
