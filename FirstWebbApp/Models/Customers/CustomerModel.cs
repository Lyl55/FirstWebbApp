using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebbApp.Models.Customers
{
    public class CustomerModel
    {
        [Required] public int ID { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string Number { get; set; }
        [Required(ErrorMessage = "Email is required for registration")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Range(18,100,ErrorMessage = "Enter correct your age!")]
        public string Age { get; set; }
    }
}
