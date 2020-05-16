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
            ConsoleKeyInfo selectedOption;

            int counter = 1;
            foreach (Division value in this.division)
            {
                Console.WriteLine(counter + ".- " + value.GetName());
                counter++;
            }

            selectedOption = Console.ReadKey();
            Console.Clear();

            String option = selectedOption.Key.ToString();
            String[] spearator = { "D" };
            String[] optionlist = option.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
            bool isNumeric = int.TryParse(optionlist[0], out _);

            if (isNumeric == true && Int32.Parse(optionlist[0]) - 1 < counter)
            {
                foreach (Division div in division)
                {
                    try
                    {
                        if (div == division[Int32.Parse(optionlist[0]) - 1])
                        {
                            div.DivisionsMenu();
                        }
                    }
                    catch { }
                }
            }
        }

        public void AddDivision()
        {
            string op1 = Input("Escoger nombre de la division");
            string op2 = Input("Agregar nombre del manager");
            division.Add(new Division(op1, op2));
            Console.WriteLine("Division creada");
            Console.ReadKey();
            Console.Clear();
        }

        public void RemoveDivision()
        {
            int counter = 1;
            foreach(Division div in division)
            {
                Console.WriteLine(counter + ".- " + div.GetName());
                counter++;
            }
            Console.WriteLine("Select the division you want to Remove");

            ConsoleKeyInfo selectedOption;
            selectedOption = Console.ReadKey();
            Console.Clear();

            String option = selectedOption.Key.ToString();
            String[] spearator = { "D" };
            String[] optionlist = option.Split(spearator, StringSplitOptions.RemoveEmptyEntries);
            bool isNumeric = int.TryParse(optionlist[0], out _);

            if (isNumeric == true && Int32.Parse(optionlist[0]) - 1 < counter)
            {
                try
                {
                    division.RemoveAt(Int32.Parse(optionlist[0]) - 1);
                }
                catch { }
            }
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
