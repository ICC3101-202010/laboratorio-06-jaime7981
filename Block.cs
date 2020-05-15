using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_Lab_6
{
    [Serializable()]
    class Block : Division
    {
        string division;
        string name;

        public Block(string name)
        {
            this.name = name;
            this.division = "Block";
        }

        public string GetName()
        {
            return name;
        }

        public string GetDivision()
        {
            return division;
        }
    }
}
