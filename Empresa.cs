using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_Lab_6
{
    [Serializable()]
    class Empresa
    {
        string name;
        string rut;
        List<Division> division = new List<Division>();

        public Empresa(string name, string rut)
        {
            this.name = name;
            this.rut = rut;
        }

        public void ShowDivision()
        {
            int counter = 1;
            foreach (Division div in division)
            {
                Console.WriteLine(counter + ".- ");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public void CreateDivision()
        {
            string selectedOption;
            string[] options = { "Area (a)", "Department (d)", "Secction (s)", "Block (b)" };
            switch (SelectOption(" Create Division \n", options))
                {
                case "A":
                    selectedOption = Input("Area name");
                    Area area = new Area(selectedOption);
                    division.Add(area);
                    break;
                case "D":
                    selectedOption = Input("Department name");
                    Department department = new Department(selectedOption);
                    division.Add(department);
                    break;
                case "S":
                    selectedOption = Input("Section name");
                    Secction secction = new Secction(selectedOption);
                    division.Add(secction);
                    break;
                case "B":
                    selectedOption = Input("Block name");
                    Block block = new Block(selectedOption);
                    division.Add(block);
                    break;
            }
            Console.Clear();
        }

        public void ShowOptions(string[] options)
        {
            int optionIndex = 1;

            foreach (string option in options)
            {
                Console.WriteLine($"{optionIndex} - {option}");

                optionIndex += 1;
            }
        }

        public string SelectOption(string title, string[] options)
        {
            Console.WriteLine(title);
            ConsoleKeyInfo selectedOption;
            ShowOptions(options);
            selectedOption = Console.ReadKey();
            return selectedOption.Key.ToString();
        }

        public string Input(string input)
        {
            Console.Clear();
            Console.WriteLine(input);
            return Console.ReadLine();
        }

        public string GetName()
        {
            return name;
        }

        public string GetRut()
        {
            return rut;
        }
    }
}
