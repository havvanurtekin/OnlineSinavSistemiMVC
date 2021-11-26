using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjeMY.Model
{
    public class RegisterModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string pass { get; set; }
        public string confirmpass { get; set; }
        public string firstname  { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string statu { get; set; }

    }
}