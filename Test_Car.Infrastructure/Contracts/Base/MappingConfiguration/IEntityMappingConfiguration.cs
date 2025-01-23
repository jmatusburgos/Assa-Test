﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Car.Infrastructure.Contracts.Base.MappingConfiguration
{
    public interface IEntityMappingConfiguration<T>: IEntityTypeConfiguration<T> where T : class
    {
    }
}
