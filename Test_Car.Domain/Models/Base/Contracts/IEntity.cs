using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Car.Domain.Models.Base.Contracts
{
    /// <summary>
    /// IEntity Interface
    /// </summary>
    public interface IEntity
    {
    }

    /// <summary>
    /// IEntity interface with Id type generic
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntity<T> : IEntity
    {
        T Id { get; set; }
    }
}
