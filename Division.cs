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
        List<Area> areas = new List<Area>();
        List<Department> departments = new List<Department>();
        List<Secction> sections = new List<Secction>();
        List<Block> blocks = new List<Block>();

        protected string name;
        string manager;

        public Division()
        {

        }

        public Division(string name, string manager)
        {
            this.name = name;
            this.manager = manager;
        }

        public void DivisionsMenu()
        {
            bool flag = true;
            while (flag == true)
            {
                string[] options = { "Show Divisions (s)", "Create Divisions (c)", "Back (b)" };
                switch (SelectOption(" Menu"+ name + " \n", options))
                {
                    case "S":
                        {
                            Console.Clear();
                            ShowDivisions();
                            break;
                        }
                    case "C":
                        {
                            Console.Clear();
                            CreateDivision();
                            break;
                        }
                    case "B":
                        {
                            flag = false;
                            break;
                        }
                }
                Console.Clear();
            }
        }

        public void ShowDivisions()
        {
            int counter = 1;
            if (areas != null)
            {
                Console.WriteLine("Area:");
                foreach (Area value in this.areas)
                {
                    Console.WriteLine(" " + counter + ".- " + value.GetName());
                    counter++;
                }
            }
            if (departments != null)
            {
                counter = 1;
                Console.WriteLine("Department:");
                foreach (Department value in this.departments)
                {
                    Console.WriteLine(" " + counter + ".- " + value.GetName());
                    counter++;
                }
            }
            if (sections != null)
            {
                counter = 1;
                Console.WriteLine("Sections:");
                foreach (Secction value in this.sections)
                {
                    Console.WriteLine(" " + counter + ".- " + value.GetName());
                    counter++;
                }
            }
            if (blocks != null)
            {
                counter = 1;
                Console.WriteLine("Blocks:");
                foreach (Block value in this.blocks)
                {
                    Console.WriteLine(" " + counter + ".- " + value.GetName());
                    counter++;
                }
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
                    areas.Add(area);
                    break;
                case "D":
                    selectedOption = Input("Department name");
                    Department department = new Department(selectedOption);
                    departments.Add(department);
                    break;
                case "S":
                    selectedOption = Input("Section name");
                    Secction secction = new Secction(selectedOption);
                    sections.Add(secction);
                    break;
                case "B":
                    selectedOption = Input("Block name");
                    Block block = new Block(selectedOption);
                    blocks.Add(block);
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

        public string GetManager()
        {
            return manager;
        }
    }
}
