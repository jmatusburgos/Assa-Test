using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Car.Domain.Models.Base.Contracts
{
    /// <summary>
    /// Interface for catalog entities
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface ICatalog<TKey> : IEntity<TKey>
    {
        /// <summary>
        /// Name property
        /// </summary>
        string Name { get; }
    }
}
