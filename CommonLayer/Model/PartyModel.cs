using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
    public class PartyModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string PartyName { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string RegisteredBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public  DateTime MofifiedDate { get; set; }
    }
}
