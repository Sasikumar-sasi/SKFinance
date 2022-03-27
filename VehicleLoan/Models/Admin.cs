using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleLoan.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [Required,MaxLength(30)]
        public string AdminName { get; set; }
        [Required,MaxLength(16)]
        public string Password { get; set; }
    }
}