using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Domain.Constants
{
    public static class Roles
    {
        public const string Admin = "Admin";
        public const string Member = "Member";
        public const string System = "System";

        /// <summary>
        /// Returns roles ordered by access level from heighest (system) to lowest (member).
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> OrderedByAccessLevel()
        {
            return new List<string> { System, Admin, Member };
        }
    }
}
