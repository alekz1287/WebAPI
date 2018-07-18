using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HillmanGroup.API.Models
{
    public class PointOfInterestForCreationDTO
    {
        [Required(ErrorMessage ="Name is Required")]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
