using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApplication.DataAccess.Models.StaticModels
{
    public enum Priority
    {
        [EnumMember(Value ="Low")]
        Low,
        [EnumMember(Value = "Medium")]
        Medium,
        [EnumMember(Value = "High")]
        High
    }
}
