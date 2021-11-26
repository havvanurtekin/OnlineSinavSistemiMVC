using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace ProjeMY.Model
{
    public class LoginModel
    {
        public int id { get; set; }
       
        public string pass { get; set; }
    }
}