using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMPLOYEE_CRUD_ADONET
{
    class CrudExecution
    {
        static void Main(string[] args)
        {
          
            Console.WriteLine("Enter the Choice of action on Employee");
            Console.WriteLine("\n1=>Create Employee \n2=>Display Employee\n3=>Update Employee Details \n4=>Delete Employee");
            String choice = Console.ReadLine();

            Insert_Employee_Method e = new Insert_Employee_Method();
            Display_Employee_Method d = new Display_Employee_Method();
            Update_Employee_Method update = new Update_Employee_Method();
            Delete_Employee_Method delete = new Delete_Employee_Method();
            
            switch (choice)
            {
                case "1":
                    e.EmployeeCreate();
                    Console.ReadKey();
                    break;
                case "2":
                    d.EmployeeDisplay();
                    Console.ReadKey();
                    break;
                case "3":
                    update.EmployeeUpdate();
                    Console.ReadKey();
                    break;
                case "4":
                    delete.EmployeeDelete();
                    Console.ReadKey();
                    break;

            }
            Console.ReadKey();
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
