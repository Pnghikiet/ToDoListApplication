using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApplication.DataAccess.Models;
using ToDoListApplication.DataAccess.Parammeters;

namespace ToDoListApplication.DataAccess.Specifications
{
    public class TodoWithFilterForCount : BaseSpecifications<ToDoItem>
    {
        public TodoWithFilterForCount(Params param) : base(
            x =>
            (x.UserId == param.UserID) &&
            (x.IsCleared == false))
        {
            

        }
    }
}
