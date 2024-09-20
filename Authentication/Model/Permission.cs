using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Model
{
    public class Permission
    {
        public const string Create = "Create";
        public const string Read = "Read";
        public const string Update = "Update";
        public const string Delete = "Delete";
        public const string Publish = "Publish";

        private static readonly Dictionary<string, List<string>> RolePermission = new Dictionary<string, List<string>>
        {
            {"Admin", new List<string>
                {
                    Create,
                    Read,
                    Update,
                    Delete,
                    Publish

                }
            },
            {"Author", new List<string>
                {
                    Create,
                    Publish,
                    Read
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
            }
        };

    }
}
