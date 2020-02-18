using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

namespace UserAdminProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingManager pm = new ParkingManager();
            pm.exitCar("77수7777");
            /* string strConn = "Server=localhost;Database=parkingsystem;Uid=root;Pwd=fkdlxmsld13#;";

             using (MySqlConnection conn = new MySqlConnection(strConn))
             {
                 conn.Open();
                 string sql = "SELECT * FROM User";


                 MySqlCommand cmd = new MySqlCommand(sql, conn);
                 MySqlDataReader rdr = cmd.ExecuteReader();
                 while (rdr.Read())
                 {
                     Console.WriteLine("{0}: {1}", rdr["Id"], rdr["Name"]);
                 }
                 rdr.Close();
             }
             Console.WriteLine("end");

             UserManager manager = new UserManager();
             ParkingManager pManager = new ParkingManager();

             while (true)
             {
                 Console.Clear();
                 Console.WriteLine("** 회원관리 프로그램 **");
                 Console.WriteLine("[1] 등록하기");
                 Console.WriteLine("[2] 불러오기(List)");
                 Console.WriteLine("[3] 상세보기");
                 Console.WriteLine("[4] 저장하기");
                 Console.WriteLine("[5] 불러오기");
                 Console.WriteLine("[6] 종료");

                 SelectMenuNum selectmenunumber = (SelectMenuNum)Int32.Parse(Console.ReadLine());

                 switch (selectmenunumber)
                 {
                     case SelectMenuNum.Regesiter:
                         {
                             Console.Clear();
                             Console.WriteLine("[1] 신규회원 등록하기---");
                             manager.CreateUser(Input());
                             break;
                         }

                     case SelectMenuNum.List:
                         {
                             bool editpage = true;

                             while (editpage)
                             {
                                 Console.Clear();
                                 Console.WriteLine("[2] 불러오기(List)");
                                 pManager.exitCar("65호4084");
                                 Console.WriteLine("------------END------------");
                                 Console.WriteLine("[1] Edit User");
                                 Console.WriteLine("[2] Delete User");
                                 Console.WriteLine("[3] Find User by Name");
                                 Console.WriteLine("[4] Back to the Mainpage");
                                 Console.WriteLine("[5] Exit");

                                 EditMenuNum editmenumumber = (EditMenuNum)Int32.Parse(Console.ReadLine());

                                 switch(editmenumumber)
                                 {
                                     case EditMenuNum.Edit:
                                         {
                                             Console.Write("[Edit] which number? : ");
                                             int editnumber = Int32.Parse(Console.ReadLine());
                                             manager.EditUser(editnumber, Input());
                                             break;
                                         }
                                     case EditMenuNum.Delete:
                                         {
                                             Console.Write("[Delete] which number? :");
                                             int deletenumber = Int32.Parse(Console.ReadLine());
                                             manager.DeleteUser(deletenumber);
                                             break;
                                         }
                                     case EditMenuNum.Find:
                                         {
                                             Console.Write("Name : ");
                                             List<User> findresult = manager.FindByName(Console.ReadLine());
                                             DisplayUsers(findresult);
                                             string pause = Console.ReadLine();
                                             break;
                                         }
                                     default:
                                     case EditMenuNum.BackToMain:
                                         {
                                             editpage = false;
                                             break;
                                         }
                                     case EditMenuNum.Exit:
                                         {
                                             return;
                                         }

                                 }
                             }
                             break;
                         }
                     case SelectMenuNum.Definite:
                         {
                             bool step = true;
                             while(step)
                             {
                                 Console.Clear();
                                 Console.WriteLine("[3] 상세보기");
                                 DisplayDetailUsers(manager.Users);
                                 string pause = Console.ReadLine();
                                 step = false;

                             }
                             break;
                         }

                     case SelectMenuNum.Save:
                         {
                             Console.WriteLine("File name : ");
                             string filename = Console.ReadLine();
                             manager.SaveFile(filename);
                             Console.WriteLine("---완료!---");
                             System.Threading.Thread.Sleep(300);
                             break;
                         }

                     case SelectMenuNum.Load:
                         {
                             Console.WriteLine("File name : ");
                             string filename = Console.ReadLine();
                             manager.LoadFile(filename);
                             Console.WriteLine("---완료!---");
                             System.Threading.Thread.Sleep(300);
                             break;
                         }

                     default:
                     case SelectMenuNum.Exit:
                         return;
                 }
             }
         }


         public static User Input()
         {
             Console.Write("Name : ");
             string name = Console.ReadLine();
             Console.Write("Phone : ");
             string phone = Console.ReadLine();
             Console.Write("Type<Admin / User> : ");
             string type = Console.ReadLine();
             Console.Write("Car Type : ");
             string car_type = Console.ReadLine();
             Console.Write("Car Number : ");
             string car_number = Console.ReadLine();
             Console.Write("Id : ");
             int id = Int32.Parse(Console.ReadLine());

             return new User(name, phone, type, car_type, car_number, id);
         }

         public static void DisplayUsers(List<User> Users)
         {
             int count = 1;
             foreach (User i in Users)
             {
                 Console.Write("<{0}>", count);
                 Console.WriteLine(i.GetUserInfo());
                 count++;
             }
         }

         public static void DisplayDetailUsers(List<User> Users)
         {
             int count = 1;
             foreach(User i in Users)
             {
                 Console.Write("<{0}>", count);
                 Console.WriteLine(i.GetDetailUserInfo());
                 count++;
             }
         }

         public enum SelectMenuNum
         {
             Regesiter = 1,
             List,
             Definite,
             Save,
             Load,
             Exit
         }

         public enum EditMenuNum
         {
             Edit=1,
             Delete,
             Find,
             BackToMain,
             Exit
         }

     }   */
        }
    }
}

