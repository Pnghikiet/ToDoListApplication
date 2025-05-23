﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApplication.DataAccess.Specifications
{
    public interface Ispecification<T>
    {
        Expression<Func<T,bool>> Criteria { get; }
        List<Expression<Func<T,object>>> Includes { get; }
        int Take { get; }
        int Skip {  get; }
        bool IsPagingEnabled { get; }
    }
}
