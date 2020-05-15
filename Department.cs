using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_Lab_6
{
    [Serializable()]
    class Department : Division
    {
        string division;
        string name;

        public Department(string name)
        {
            this.name = name;
            this.division = "Department";
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
