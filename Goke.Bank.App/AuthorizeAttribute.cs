using System;
using System.Collections.Generic;
using System.Text;

namespace Goke.Bank.App
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class AuthorizeAttribute : Attribute
    {
        public string? Roles { get; set; }

        public AuthorizeAttribute() { }

        public AuthorizeAttribute(string roles)
        {
            Roles = roles;
        }
    }

}
