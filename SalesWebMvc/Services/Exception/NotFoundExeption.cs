﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services.Exception
{
    public class NotFoundExeption : ApplicationException
    {
        public NotFoundExeption(string messsage) : base(messsage)
        {

        }
    }
}
