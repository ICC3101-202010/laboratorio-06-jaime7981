using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_Lab_6
{
    [Serializable()]
    class Division
    {
        string name;
        string manager;

        public Division()
        {

        }

        public Division(string name, string manager)
        {
            this.name = name;
            this.manager = manager;
        }
    }
}
