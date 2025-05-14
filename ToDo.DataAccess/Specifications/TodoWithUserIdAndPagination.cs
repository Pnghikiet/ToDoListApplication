using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApplication.DataAccess.Models;
using ToDoListApplication.DataAccess.Parammeters;

namespace ToDoListApplication.DataAccess.Specifications
{
    public class TodoWithUserIdAndPagination : BaseSpecifications<ToDoItem>
    {
        public TodoWithUserIdAndPagination(Params param) : base(
            x => 
            (x.UserId == param.UserID) &&
            (x.IsCleared == false))
        {
            ApplyPaging((param.PageIndex - 1) * param.PageSize, param.PageSize);
        }
    }
}
