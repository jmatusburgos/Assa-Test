using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Car.Domain.Models.Base.Contracts;

namespace Test_Car.Domain.Models.Base
{
    /// <summary>
    /// Base clase for Catalog Entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Catalog<T> : ICatalog<T>
    {
        public T Id { get ; set ; }
        public string Name { get; set; }
    }
}
