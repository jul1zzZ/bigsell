using JumperApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumperApplication
{
    static class AuthStorage
    {
        static public bool IsAuth { get; set; } = false;
        static public Role Role { get; set; }
    }
}
