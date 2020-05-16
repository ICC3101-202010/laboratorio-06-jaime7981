using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Empresa_Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool main = true;
            List<Empresa> empresas = new List<Empresa>();
            empresas = LoadData();

            while (main)
            {
                main = StartMenu(empresas);
            }
        }

        static bool StartMenu(List<Empresa> empresas)
        {
            bool flag = true;

            while (flag)
            {
                ConsoleKeyInfo selectedOption;
                Console.WriteLine("Menu de inicio");
                Console.WriteLine("Cargar Archivo (s/n)  /  Limpiar Datos (Opcion Oculta)  /  Exit (q)");
                SaveData(empresas);
                selectedOption = Console.ReadKey();
                Console.Clear();

                switch (selectedOption.Key.ToString())
                {
                    case "S":
                        {
                            Console.WriteLine("Cargar Archivo \n");

                            string op1 = AskData(" Nombre de empresa");
                            string op2 = AskData(" Rut de empresa");
                            foreach (Empresa emp in empresas)
                            {
                                if (emp.GetName() == op1 && emp.GetRut() == op2)
                                {
                                    PrintString("Empresa encontrada");
                                    MainMenu(emp);
                                    flag = false;
                                }
                            }

                            if (flag == true)
                            {
                                Console.WriteLine("Archivo empresa no encontrado");
                                Console.WriteLine("¿Desea agregar esos datos? (s/n)");
                                selectedOption = Console.ReadKey();
                                Console.Clear();

                                if (selectedOption.Key.ToString() == "S")
                                {
                                    Empresa newempresa = new Empresa(op1, op2);
                                    empresas.Add(newempresa);

                                    SaveData(empresas);

                                    PrintString("Empresa agregada");
                                    flag = false;
                                }
                            }
                            break;
                        }

                    case "N":
                        {
                            Console.WriteLine("Crear Empresa \n");
                            
                            string op1 = AskData(" Nombre de empresa");
                            string op2 = AskData(" Rut de empresa");

                            Empresa newempresa = new Empresa(op1, op2);
                            empresas.Add(newempresa);

                            SaveData(empresas);

                            PrintString("Empresa agregada");
                            flag = false;

                            break;
                        }
                    case "C":
                        {
                            SaveData(new List<Empresa>());
                            break;
                        }
                    case "Q":
                        {
                            return false;
                        }
                }
            }
            return true;
        }

        static void MainMenu(Empresa empresa)
        {
            ConsoleKeyInfo selectedOption;
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Menu Principal");
                string[] options = { "Ver Divisiones", "Crear Divisiones", "Eliminar Divisiones", "Salir"};

                ShowMenuOptions(options);

                selectedOption = Console.ReadKey();
                Console.Clear();

                switch (selectedOption.Key.ToString())
                {
                    case "D1":
                        empresa.ShowDivision();
                        break;
                    case "D2":
                        empresa.AddDivision();
                        break;
                    case "D3":
                        
                        Console.WriteLine("Ingresar nombre de la division que se quiere borrar");
                        empresa.RemoveDivision();
                        break;
                    case "D4":
                        flag = false;
                        break;
                }
            }
        }

        static void SaveData(List<Empresa> empresas)
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream FS = new FileStream("Empresas.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                binaryFormatter.Serialize(FS, empresas);
                FS.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while saving");
                Console.WriteLine(ex);
            }
        }
        static List<Empresa> LoadData()
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream FS = new FileStream("Empresas.bin", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                List<Empresa> empresas = (List<Empresa>)binaryFormatter.Deserialize(FS);
                FS.Close();
                return empresas;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while loading");
                Console.WriteLine(ex);
                return null;
            }
        }

        static void PrintString(string sentence)
        {
            Console.WriteLine(sentence);
            Console.ReadKey();
            Console.Clear();
        }

        static string AskData(string sentence)
        {
            Console.WriteLine(sentence);
            return Console.ReadLine();
        }

        static void ShowMenuOptions(string[] options)
        {
            int optionIndex = 1;

            foreach (string option in options)
            {
                Console.WriteLine($"{optionIndex} - {option}");

                optionIndex += 1;
            }
        }
    }
}
