using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcLoginAppDemo.Models
{
    public class ProductDetailModel
    {
        public List<loginModel> listofLogin = new List<loginModel>();
    }
    public class loginModel
    {
        [Required]
        [DisplayName("username")]
        public string UsernName { get; set; }
        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

}