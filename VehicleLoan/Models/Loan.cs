using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VehicleLoan.Models
{
    public class Loan
    {
        [ForeignKey("Customers")]
        public int CustomerID { get; set; }
        [Key]
        public int LoanID { get; set; }
        [Required, MaxLength(30)]
        public string VehicleBrand { get; set; }
        [Required, MaxLength(20)]
        public string Model { get; set; }
        [Required]
        public int OnRoadPrice { get; set; }
        [Required, MaxLength(20)]
        public string Status { get; set; } = "Processing";

        public virtual Customer Customers { get; set; }
    }
}