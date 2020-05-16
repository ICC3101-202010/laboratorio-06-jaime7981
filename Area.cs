using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_Lab_6
{
    [Serializable()]
    class Area : Division
    {
        protected string division;
        string name;

        public Area(string name)
        {
            this.name = name;
            this.division = "Area";
        }

        public new string GetName()
        {
            return name;
        }

        public string GetDivision()
        {
            return division;
        }
    }
}
