List<string> TaskList = new List<string>();

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


/// <summary>
/// Show the options for Task, 1. New task, 2. Remove task, 3. Pending task, 4. Exit
/// </summary>
/// <returns>Returns option selected by user</returns>
int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    string userOptionMainMenu = Console.ReadLine();
    int userOptionMenuInt = Convert.ToInt32(userOptionMainMenu);

    while (userOptionMenuInt < 1 || userOptionMenuInt > 4)
    {
        Console.WriteLine("Error! Ingrese una opción válida");
        userOptionMenuInt = Convert.ToInt32(Console.ReadLine());
    }

    return userOptionMenuInt;
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        PrintTaskList();

        string userTaskToRemove = Console.ReadLine();

        // Remove one position because the array starts in 0
        int indexToRemove = Convert.ToInt32(userTaskToRemove) - 1;

        if (indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
        {

            Console.WriteLine("Número de tarea no válido");
        }

        else if (indexToRemove > -1 && TaskList.Count > 0)
        {
            string taskToRemove = TaskList[indexToRemove];
            TaskList.RemoveAt(indexToRemove);
            Console.WriteLine($"Tarea {taskToRemove} eliminada");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string taskAdded = Console.ReadLine();

        if (string.IsNullOrEmpty(taskAdded.Trim()))
        {
            Console.WriteLine("El nombre de la tarea está vacío");
        }
        else
        {
            TaskList.Add(taskAdded);
            Console.WriteLine("Tarea registrada");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al guardar la tarea");
    }
}

void ShowMenuTaskLists()
{
    if (TaskList?.Count > 0)
    {
        PrintTaskList();
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}

void PrintTaskList()
{
    Console.WriteLine("----------------------------------------");
    var indexTask = 0;

    TaskList.ForEach(task => Console.WriteLine($"{++indexTask}. {task}"));

    Console.WriteLine("----------------------------------------");
}

public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}
