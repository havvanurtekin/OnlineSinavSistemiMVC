namespace ProjeMY.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.tblDersler = new HashSet<tblDersler>();
        }

        [Key]
        [DisplayName("User Id:")]
        [Required(ErrorMessage = "User Id is required")]
        public int UserId { get; set; }

        [DisplayName("First Name: ")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [DisplayName("Surname: ")]
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [DisplayName("Email Adress: ")]
        [Required(ErrorMessage = "Email Adress is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string Email { get; set; }

        [DisplayName("User Name: ")]
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [DisplayName("Password: ")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [DisplayName("Confirm Password: ")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Statu: ")]
        [Required(ErrorMessage = "Statu is required")]
        public string Statu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDersler> tblDersler { get; set; }


    }
}

