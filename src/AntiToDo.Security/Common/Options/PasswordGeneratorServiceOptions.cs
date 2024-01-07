using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Security.Common.Options
{
    public class PasswordGeneratorServiceOptions
    {
        public int SaltSize { get; set; } = 16;
        public int HashSize { get; set; } = 20;
        public int HashIter { get; set; } = 10000;
    }
}
