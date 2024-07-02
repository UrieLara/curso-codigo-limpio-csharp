using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if ((Menu)menuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuTaskLists();
                }
            } while ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string userOptionMainMenu = Console.ReadLine();
            return Convert.ToInt32(userOptionMainMenu);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                PrintTaskList();

                string userTaskToRemove = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(userTaskToRemove) - 1;
                if (indexToRemove > -1 && TaskList.Count > 0)
                {
                    string taskToRemove = TaskList[indexToRemove];
                    TaskList.RemoveAt(indexToRemove);
                    Console.WriteLine("Tarea " + taskToRemove + " eliminada");
    
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string taskAdded = Console.ReadLine();
                TaskList.Add(taskAdded);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuTaskLists()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                PrintTaskList();
            }
        }

         static void PrintTaskList(){
            Console.WriteLine("----------------------------------------");
            var indexTask = 0;
            foreach (var task in TaskList)
            {
                Console.WriteLine(++indexTask + ". "+ task);
            }
            Console.WriteLine("----------------------------------------");
        }
    }

    public enum Menu{
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4
    }
}
