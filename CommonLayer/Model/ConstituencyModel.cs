using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class ConstituencyModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string ConstituencyName { get; set; }

        [RegularExpression ("^[a-zA-Z]*$")]
        public string City { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string State { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
