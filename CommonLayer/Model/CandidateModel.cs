using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.Model
{
    public class CandidateModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Party")]
        public int PartyId { get; set; }

        [ForeignKey("Constituency")]
        public int ConstituencyId { get; set; }

        [Required]
        public string FirstName{ get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string MobileNo { get; set; }

        public int Votes { get; set; }

        [ForeignKey("Party")]
        public string PartyName { get; set; }

        [ForeignKey("Constituency")]
        public string ConstituencyName { get; set; }
    }
}
