using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_40
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
                Console.WriteLine("Your password is : " + pswArr[id]);
            }
            /*foreach (string i in nameArr)
            {
                Console.WriteLine(i);
            } */
        }
        static void delAcc()
        {
            Console.WriteLine("Enter your name");
            var name = Console.ReadLine();

            string[] nameArr = File.ReadAllText("nameFile.txt").Split(',');
            var id = Array.IndexOf(nameArr, name);

            Console.WriteLine(id);

            if (id == -1)
            {
                Console.WriteLine("Invalid Name\n");
            }
            else
            {
                string[] pswArr = File.ReadAllText("pswFile.txt").Split(',');
                string path2 = "pswFile.txt";
                string txt2 = File.ReadAllText(path2);
                string[] arr2 = txt2.Split(',');
                ArrayList list2 = new ArrayList();
                foreach (string item2 in arr2)
                    list2.Add(item2);
                list2.RemoveAt(id);
                string data2 = "";
                foreach (string item3 in list2)
                    data2 += item3 + ",";
                File.WriteAllText(path2, data2.Remove(data2.Length - 1, 1));
            }

            string path = "nameFile.txt";
            string txt = File.ReadAllText(path);
            string[] arr = txt.Split(',');
            ArrayList list = new ArrayList();
            foreach (string item in arr)
                list.Add(item);
            list.Remove(name);
            //File.WriteAllText(path, "");
            string data = "";
            foreach (string item2 in list)
                data += item2 + ",";
            File.WriteAllText(path, data.Remove(data.Length - 1, 1));

            

            Console.WriteLine("Your account was deleted successfully.....");
        }

        static void Main(string[] args)
        {
            int choice = 0;
            do
            {
                Console.WriteLine("\n1. Create Account");
                Console.WriteLine("2. View Password");
                Console.WriteLine("3. Delete Account");
                Console.WriteLine("4. Exit");
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
                        delAcc();
                        break;
                    case 4:
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
