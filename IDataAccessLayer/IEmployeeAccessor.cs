﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataAccessLayer
{
    public interface IEmployeeAccessor
    {
        public bool verifyEmployee(string username, string password);
    }
}