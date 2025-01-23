using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Car.Domain.Models.Base.Contracts;

namespace Test_Car.Domain.Models.Base
{
    /// <summary>
    /// Base class for Auditable Entities
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class AuditableEntity<TKey> : Catalog<TKey>, IAuditableEntity
    {
        public AuditableEntity()
        {
            CreatedBy = string.Empty;
            ModifiedBy = string.Empty;
        }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
