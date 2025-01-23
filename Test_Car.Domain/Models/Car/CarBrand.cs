using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Car.Domain.Models.Base;

namespace Test_Car.Domain.Models.Car
{
    /// <summary>
    /// Entity for Car Models
    /// </summary>
    public class CarBrand : AuditableEntity<int>
    {
        public string Description { get; set; }
    }
}
