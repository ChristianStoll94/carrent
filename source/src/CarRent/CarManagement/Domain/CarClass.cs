using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.CarManagement.Domain
{
    public class CarClass
    {
        [Key]
        public string Description { get; set; }
        public double Price { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
