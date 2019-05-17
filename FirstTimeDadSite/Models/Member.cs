using System.ComponentModel.DataAnnotations;

namespace FirstTimeDadSite.Models
{
    public class Member
    {
        //Data Annotations - Validation and DB markup
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //int is automatically required because
        //it is a value type
        [Key] //Mark this field as PK (Primary Key)
        public int MemberID { get; set; }

        [Required]
        [DataType(DataType.Password)] //Enum/Enumeration
        public string Password { get; set; }


    }

    //This is a View model for the Login Page
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}