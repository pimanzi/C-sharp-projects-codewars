using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.UI;


namespace ToDoApp;
public class Program
{
   public static void Main(string[] args)
   {
      
       bool on = true;
       
       while (on){ 
           Console.WriteLine("Modern Task Manager App , here is the Menu");
           Console.WriteLine("Input 1 for creating a task");
           Console.WriteLine("Input 2 for removing a task");
           Console.WriteLine("Input 3 for quitting the application");
      
           Console.Write("What do you want to do: " );
      
           string input = Console.ReadLine();
           
           while (!ConsoleUI.CheckInput(input))
           {
               Console.WriteLine("Please choose an option from menu"); 
               Console.Write("What do you want to do: " );
               input = Console.ReadLine();
        
           }

           if (input == "3")
           {
               on = false;
           }

           int actionInput = int.Parse(input);
           ConsoleUI.Action(actionInput);}
     
      
   }
}