using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Car.Domain.Models.Base.Contracts
{
    /// <summary>
    /// Interface for entities auditable properties
    /// </summary>
    public interface IAuditableEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
