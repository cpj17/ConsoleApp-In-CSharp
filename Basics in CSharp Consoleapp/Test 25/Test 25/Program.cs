using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_25
{
    class Program
    {
        static void createAcc()
        {
            Console.WriteLine("Enter Your Name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Your Password");
            var psw = Console.ReadLine();
            File.AppendAllText("nameFile.txt", name + ",");
            File.AppendAllText("pswFile.txt", psw + ",");
        }
        static void viewPsw()
        {
            Console.WriteLine("Enter your name");
            var name = Console.ReadLine();
            string[] nameArr = File.ReadAllText("nameFile.txt").Split(',');
            var id = Array.IndexOf(nameArr, name);
            if (id == -1)
            {
                Console.WriteLine("Invalid Name\n");
            }
            else
            {
                string[] pswArr = File.ReadAllText("pswFile.txt").Split(',');
                Console.WriteLine("Your password is : "+pswArr[id]);
            }
            /*foreach (string i in nameArr)
            {
                Console.WriteLine(i);
            } */
        }
        static void Main(string[] args)
        {
            int choice = 0;
            do
            {
                Console.WriteLine("\n1. Create Account");
                Console.WriteLine("2. View Password");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        createAcc();
                        break;
                    case 2:
                        viewPsw();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter correct choice");
                        break;
                }
            } while (choice != 3);
            Console.ReadLine();
        }
    }
}
