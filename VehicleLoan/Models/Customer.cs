using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleLoan.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get;set; }
        
        [Required,MaxLength(30)]
        public string Name { get;set; }
        
        [Required,MaxLength(15)]
        public string PhoneNumber { get; set; }
        
        [Required,MaxLength(50)]      
        public string City { get; set; }
        
        [Required, MaxLength(50)]
        public string Email { get; set; }
        
        
        [Required,MaxLength(15)]
        public string Password { get; set; }
    }
}