using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

namespace UserAdminProgram
{
    class UserManager
    {
        public List<User> Users = new List<User>();
        
        public void CreateUser(User newUser)
        {
            Users.Add(newUser);
        }

        public void EditUser(int editnumber, User newUser)
        {
            Users[editnumber] = newUser;
        }

        public void DeleteUser(int deletenumber)
        {
            Users.RemoveAt(deletenumber);
        }

        public List<User> FindByName(string name)
        {
            int count = 0;
            List<User> findresult = new List<User>();
            foreach(User e in Users)
            {
                if(e.Name == name)
                {
                    findresult.Add(e);
                }
                count++;
            }
            return findresult;
        }

        public void SaveFile(string filename)
        {
            StreamWriter savefile = new StreamWriter(@"C:\Users\tjals\desktop\practice\" + filename + ".txt");
            foreach(User e in Users)
            {
                savefile.WriteLine(e.Name);
                savefile.WriteLine(e.Phone);
                savefile.WriteLine(e.Type);
                savefile.WriteLine(e.Car_Type);
                savefile.WriteLine(e.Car_Number);
            }
            savefile.Close();
        }

        public void LoadFile(string filename)
        {
            try
            {
                using (StreamReader loadfile = new StreamReader(@"C:\Users\tjals\desktop\practice\" + filename + ".txt"))
                {
                    string line;
                    while ((line = loadfile.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
           
        }

        public void GetUserbyId(int id)
        {
            string strConn = "Server=localhost;Database=parkingsystem;Uid=root;Pwd=fkdlxmsld13#;";

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                string sql = $"SELECT *FROM User where id = {id}";


                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine($"Name : {rdr["Name"]}, Phone : {rdr["Phone"]}, Type : {rdr["Type"]}, Car_Type : {rdr["Car_type"]}, Car_Number : {rdr["Car_number"]}");
                }
                rdr.Close();
                Console.WriteLine("End");

            }
        }

        public void GetUserbyName(string name)
        {
            string strConn = "Server=localhost;Database=parkingsystem;Uid=root;Pwd=fkdlxmsld13#;";

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                string sql = $"SELECT *FROM User where name = {"name"}";


                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine($"Name : {rdr["Name"]}, Phone : {rdr["Phone"]}, Type : {rdr["Type"]}, Car_Type : {rdr["Car_type"]}, Car_Number : {rdr["Car_number"]}");
                }
                rdr.Close();
                Console.WriteLine("End");
            }
        }

        public void SetUserbyInstance(int id)
        {
            string strConn = "Server=localhost;Database=parkingsystem;Uid=root;Pwd=fkdlxmsld13#;";

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                string sql = $"Update User set name=@name, phone=@phone, type=@type, car_type=@car_type, car_number=@car_number where id={id}";


                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                Console.WriteLine(cmd.ExecuteNonQuery());
            }
        }

        public void DeleteUserbyId(int id)
        {
            string strConn = "Server=localhost;Database=parkingsystem;Uid=root;Pwd=fkdlxmsld13#;";

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                string sql = $"Update User set is_deleted = 'Y' where id = {id}";
                    

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Prepare();
                Console.WriteLine(cmd.ExecuteNonQuery());
            }
        }

        public void Save(User user)
        {
            string strConn = "Server=localhost;Database=parkingsystem;Uid=root;Pwd=fkdlxmsld13#;";

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                String sql = "INSERT INTO User(name, phone, type, car_type, car_number) VALUES(@name, @phone, @type, @car_type, @car_number)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@phone", user.Phone);
                cmd.Parameters.AddWithValue("@type", user.Type);
                cmd.Parameters.AddWithValue("@car_type", user.Car_Type);
                cmd.Parameters.AddWithValue("@car_number", user.Car_Number);
            }
        }

        public User getuserType(string car_number)
        {
            string strConn = "Server=localhost;Database=parkingsystem;Uid=root;Pwd=fkdlxmsld13#;";
            User u = new User();
            MySqlConnection conn = new MySqlConnection(strConn);
            conn.Open();
            string sql = "SELECT ID, NAME, TYPE, CAR_NUMBER, CAR_TYPE, PHONE FROM USER Where car_number = @car_number order by id desc limit 1";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@car_number", car_number);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();

            try
            {
                while (rdr.Read())
                {
                    u.Id = (int)rdr["id"];
                    u.Name = (string)rdr["name"];
                    u.Type = (string)rdr["type"];
                    u.Car_Number = (string)rdr["car_number"];
                    u.Car_Type = (string)rdr["car_type"];
                    u.Phone = (string)rdr["phone"];
                }

                Console.WriteLine(":::: 가져온 User Info ::::");
                Console.WriteLine("Id : {0}", u.Id);
                Console.WriteLine("Name : {0}", u.Name);
                Console.WriteLine("Type : {0}", u.Type);
                Console.WriteLine("Car_Number : {0}", u.Car_Number);
                Console.WriteLine("Car_Type : {0}", u.Car_Type);
                Console.WriteLine("Phone : {0}", u.Phone);

            }
            catch (MySqlException e)
            {
                Console.WriteLine("MySql Exception !!!");
                Console.WriteLine(e.Message);

            }
            finally
            {
                rdr.Close();
                conn.Close();
            }
            return u;
        }
    }
}
