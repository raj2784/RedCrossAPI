using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RedCrossAPI.Models
{
    public class Volunteer
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string FullName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Mobile { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string Age { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string BloodGroup { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string Address { get; set; }

    }
}
