using System;
using System.Threading;

namespace Lab
{
    class Program
    {
        private static int[] a = new int[50];
        //private static int[] a = { 1, 2, 3, 4, 5 };
        public static int totalInt;
        private static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            AddItem();
            

            Console.ReadKey(true);
        }

        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "*List Operations\n1. Add Item\n2. Insert Item\n3. Modify\n4. Search Item\n5. Delete Item\n6. Display List\nEsc. Exit");
            Console.Write("\nEnter your choice: ");
            //int n = Convert.ToInt32(Console.ReadLine());
            char n = Console.ReadKey().KeyChar;
            switch (n)
            {
                case '1':
                    AddItem();
                    break;
                case '2':
                    InsertItem();
                    break;
                case '3':
                    ModifyItem();
                    break;
                case '4':
                    SearchItem();
                    break;
                case '5':
                    DeleteItem();
                    break;
                case '6':
                    DisplayList();
                    break;
                default:
                    {
                       if (n == 27)
                            Environment.Exit(0);
                        else
                            Console.WriteLine("\aWrong Entry!:\"{0}\"", n);
                        break;
                    }
            }
        }

        public static void AddItem()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(15, 2);
            Console.WriteLine("******First we have to make a list******");
            Console.SetCursorPosition(0, 4);
            Console.Write("How many integers you wanna add in list? ");
            totalInt = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            for (int i = 0; i < totalInt; i++)
            {
                Console.Write("Enter integer at index[{0}]: ",i);
                a[i]= Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine();
            
            Console.WriteLine();
            Console.Write("Going to main menu.");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            MainMenu();
        }
        public static void InsertItem()
        {
            Console.Clear();
            
            Console.Write("Enter the index where you wanna insert integer: ");
            int ind = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the integer: ");
            int num = Convert.ToInt32(Console.ReadLine());

            for (int i = totalInt-1; i >= ind; i--)
            {
                a[i + 1] = a[i];
            }

            a[ind] = num;
            totalInt++;

            Console.WriteLine();
            Console.WriteLine("Press 1 to display modified list, Enter to insert more or Escape to go back to menu...");
            char ch = Console.ReadKey().KeyChar;
            if (ch == '1')
                DisplayList();
            else if (ch == 13)
                InsertItem();
            else
            {
                MainMenuTransition();
                MainMenu();
            }

        }

        public static void ModifyItem()
        {
            Console.Clear();
            Console.Write("How you wanna add integer?\n1. By index\n2. By Value");
            char c = Console.ReadKey().KeyChar;
            Console.WriteLine();
            switch (c)
            {
                case '1':
                    {
                        Console.Write("Enter index where you wanna modify value: ");
                        int ind = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter integer you wanna add integer: ");
                        int num = Convert.ToInt32(Console.ReadLine());
                        a[ind] = num;
                        break;
                    }
                case '2':
                    {
                        Console.Write("Enter integer which you wanna add integer: ");
                        int num = Convert.ToInt32(Console.ReadLine());
                        bool check = false;
                        int ind = 0;
                        for (int i = 0; i < totalInt; i++)
                        {
                            if (a[i] == num)
                            {
                                check = true;
                                ind = i;
                                break;
                            }
                        }
                        if (check)
                        {
                            Console.WriteLine("Value found!");
                            Console.Write("Enter new value: ");
                            int num2 = Convert.ToInt32(Console.ReadLine());
                            a[ind] = num2;

                        }
                        else
                            Console.WriteLine("\aNot Found!");

                    }
                    break;
                default:
                    Console.WriteLine("\aWrong entry!");
                    break;
            }

            Console.WriteLine();
            Console.Write("Press Enter to modify more or Escape to go back to menu...");
            char ch = Console.ReadKey().KeyChar;
            if (ch == 13)
                ModifyItem();
            else
            {
                MainMenuTransition();
                MainMenu();
            }
        }

        public static void SearchItem()
        {
            Console.Clear();
            Console.Write("Enter integer which you wanna search: ");
            int num = Convert.ToInt32(Console.ReadLine());
            bool check = false;
            int ind = 0;
            for (int i = 0; i < totalInt; i++)
            {
                if (a[i] == num)
                {
                    check = true;
                    ind = i;
                    break;
                }
            }
            if (check)
            {
                Console.WriteLine("Value found at {0}", ind);
            }
            else
                Console.WriteLine("\aNot Found!");

            Console.WriteLine();
            Console.WriteLine("Press Enter to search more or Escape to go back to menu...");
            char ch= Console.ReadKey().KeyChar;
            if(ch==13)
                SearchItem();
            else
            {
                MainMenuTransition();
                MainMenu();
            }
        }

   

        public static void DeleteItem()
        {
            Console.Clear();
            Console.Write("Enter integer which you wanna delete? ");
            int num = Convert.ToInt32(Console.ReadLine());
            bool check = false;
            int ind = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == num)
                {
                    check = true;
                    ind = i;
                    break;
                }
            }
            if (check)
            {
                Console.WriteLine("Value found!");
                totalInt--;
                for (int i = ind; i < a.Length - 1; i++)
                {
                    /*if (i==a.Length-2)
                    {
                        break;
                    }
                    else*/
                    a[i] = a[i + 1];
                    
                }
                Console.WriteLine("After deletion {0}", num);
                DisplayList();

            }
            else
                Console.WriteLine("\aNot Found!");

            Console.WriteLine();
            Console.WriteLine("Press Enter to delete more or Escape to go back to menu...");
            char ch = Console.ReadKey().KeyChar;
            if (ch == 13)
                DeleteItem();
            else
            {
                MainMenuTransition();
                MainMenu();
            }
        }

        public static void DisplayList()
        {
            //Console.Clear();
            Console.WriteLine();
            Console.WriteLine("List:");
            for (int i = 0; i < totalInt; i++)
            {
                Console.WriteLine(a[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to go back to menu...");
            Console.ReadKey();
                MainMenu();
        }

        public static void MainMenuTransition()
        {
            Console.WriteLine();
            Console.Write("Going back to main menu.");
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(300);
            Console.Write(".");
            Thread.Sleep(300);
            MainMenu();
        }

    }

    

}
