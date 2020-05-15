using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_Lab_6
{
    [Serializable()]
    class Secction : Division
    {
        string division;
        string name;

        public Secction(string name)
        {
            this.name = name;
            this.division = "Secction";
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
