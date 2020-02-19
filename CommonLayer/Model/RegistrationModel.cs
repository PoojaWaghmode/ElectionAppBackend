using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class RegistrationModel
    {

        public string UserName;

        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string FirstName;

        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string LastName;

        [DataType(DataType.EmailAddress)]
        public string Email;

        [DataType(DataType.PhoneNumber)]
        public string MobileNo;

        
        public string Password;
    }
}
