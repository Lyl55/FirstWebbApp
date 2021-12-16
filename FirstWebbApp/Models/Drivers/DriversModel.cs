using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebbApp.Models.Derivers
{
    public class DriversModel
    {
        [Required] public int ID { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Number { get; set; }
        [Required] public string Email { get; set; }
    }
}
