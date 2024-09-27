﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.User.DataAccess.Service.DataModels
{
    public class DataResultModel<T>
    {
        public T? Value { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}