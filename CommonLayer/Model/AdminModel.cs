using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public  class AdminModel : IdentityUser
    {
     
        [RegularExpression("^[a-zA-Z ]*$")]
        public string FirstName { get; set; }

        [RegularExpression ("^[a-zA-Z]")]
        public string LastName { get; set; }
    }
}
