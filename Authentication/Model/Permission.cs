using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Model
{
    public static class Permission
    {
        public const string Create = "Create";
        public const string Read = "Read";
        public const string Update = "Update";
        public const string Delete = "Delete";

        private static readonly Dictionary<string, List<string>> RolePermission = new Dictionary<string, List<string>>
        {
            {"Admin", new List<string>
                {
                    Create,
                    Read,
                    Update,
                    Delete
                }
            },
            {"Editor", new List<string>
                {
                    Read,
                    Update
                }
            },
            {"Contributor", new List<string>
                {
                    Create,
                    Read
                }
            },
            {"Subscriber", new List<string>
                {
                    Read
                }
            
            }
        };

    }
}
