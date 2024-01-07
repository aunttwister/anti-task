using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Security.Common.Interfaces
{
    public interface IPasswordGeneratorService
    {
        public (byte[] hashPassword, byte[] salt) GenerateHash(string password);
        public bool CompareHash(string password, byte[] salt, byte[] storedHash);
    }
}
