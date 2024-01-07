using AntiToDo.Security.Common.Helpers.AuthenticationAudit.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Security.Common.Helpers.AuthenticationAudit
{
    public static class AuthenticationAuditExtensions
    {
        public static string ReturnAuditMessage(this AuthenticationAuditEnum enumValue)
        {
            return enumValue switch
            {
                AuthenticationAuditEnum.AuthenticationSuccessful => "Authentication successful. Token has been generated.",
                AuthenticationAuditEnum.AuthenticationFailed => "Authentication failed. Token hasn't been generated.",
                AuthenticationAuditEnum.AuthenticationRefreshed => "Validation parameters have been met. Token has been refreshed.",
                _ => "Could not detriment the result of the action.",
            };
        }
    }
}
