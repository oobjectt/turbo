﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbo.Database.Repositories
{
    public interface IRepository<T> where T : class
    {
        // Todo: Put methods that every repository needs in here

        T Find(int id);
    }
}
