using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace UserAdminProgram
{
    class ParkingManager
    {
        UserManager um = new UserManager();

        public Parking getParkingbyNumber(string car_number)
        {
            string strConn = "Server=localhost;Database=parkingsystem;Uid=root;Pwd=fkdlxmsld13#;";
            Parking p = new Parking();
            MySqlConnection conn = new MySqlConnection(strConn);
            conn.Open();
            string sql = "SELECT id, car_number, in_time, out_time, user_id, amount FROM Parking Where car_number = @car_number order by id desc limit 1";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@car_number", car_number);
            cmd.Prepare();
            MySqlDataReader rdr = cmd.ExecuteReader();

            try
            {
                while (rdr.Read())
                {
                    p.Id = (int)rdr["id"];
                    p.CarNumber = (string)rdr["car_number"];
                    p.InTime = (DateTime)rdr["in_time"];
                    p.OutTime = (DateTime)rdr["out_time"];
                    p.Amount = (int)rdr["amount"];
                }

                Console.WriteLine(":::: 가져온 Parking Info ::::");
                Console.WriteLine("Id : {0}", p.Id);
                Console.WriteLine("CarNumber : {0}", p.CarNumber);
                Console.WriteLine("InTime : {0}", p.InTime);
                Console.WriteLine("OutTime : {0}", p.OutTime);
                Console.WriteLine("Amount : {0}", p.Amount);

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

            return p;
        }

        public void exitCar(string car_number)
        {
            string strConn = "Server=localhost;Database=parkingsystem;Uid=root;Pwd=fkdlxmsld13#;";
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                string sql = "Update Parking set out_time=@out_time, amount = @amount where car_number = @car_number";
                int amount = 0;
                string purchaseprice;
                Parking p = getParkingbyNumber(car_number);

                if (um.getuserType(car_number).Type != "admin")
                {
                    amount = chargeCost(p.InTime, DateTime.Now);
                    Console.WriteLine("주차금액 : {0}", amount);
                    Console.WriteLine("할인권을 투입해주세요 : (1hr, 2hr, 3hr, 4hr, 5hr)");
                    string hour = Console.ReadLine();
                    Console.WriteLine("구매금액을 입력해주세요 : (1만원, 3만원, 5만원, 10만원)");
                    string price = Console.ReadLine();
                    purchaseprice = purchaseDiscount(price);
                    amount = chargeCost(p.InTime, DateTime.Now, hour);
                    Console.WriteLine("할인권을 적용한 주차금액 : {0}", amount);
                    amount = chargeCost(p.InTime, DateTime.Now, purchaseprice);
                    Console.WriteLine("구매금액 별 할인 주차금액 : {0}", amount);
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@car_number", car_number);
                cmd.Parameters.AddWithValue("@out_time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Prepare();
                Console.WriteLine(cmd.ExecuteNonQuery());

            }
        }

        public int entryCar(string car_number)
        {
            string strConn = "Server=localhost;Database=parkingsystem;Uid=root;Pwd=fkdlxmsld13#;";

            using(MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                String sql = "INSERT INTO Parking(car_number, in_time) VALUES(@car_number, @in_time)";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@car_number", car_number);
                cmd.Parameters.AddWithValue("@in_time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Prepare();
                Console.WriteLine(cmd.ExecuteNonQuery());

                return 1;
            }
        }

        public int chargeCost(DateTime in_time, DateTime out_time, string hour="")
        {
            Console.WriteLine("출차시간 : " + out_time.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine("입차시간 : " + in_time.ToString("yyyy-MM-dd HH:mm:ss"));

            TimeSpan time_diff = out_time - in_time;

            Console.WriteLine("총 주차시간 : {0}", time_diff.TotalMinutes);

            int cost = 0;
            int discount = 0;

            if (time_diff.TotalMinutes > 30)
            {
                switch (hour)
                {
                    case "1hr":
                        {
                            discount = (int)time_diff.TotalMinutes - 60;
                            cost = discount / 10 * 1000;
                            cost += 1000;
                            return cost;
                        }

                    case "2hr":
                        {
                            discount = (int)time_diff.TotalMinutes - 120;
                            cost = discount / 10 * 1000;
                            cost += 1000;
                            return cost;
                        }

                    case "3hr":
                        {
                            discount = (int)time_diff.TotalMinutes - 180;
                            cost = discount / 10 * 1000;
                            cost += 1000;
                            return cost;
                        }

                    case "4hr":
                        {
                            discount = (int)time_diff.TotalMinutes - 240;
                            cost = discount / 10 * 1000;
                            cost += 1000;
                            return cost;
                        }

                    case "5hr":
                        {
                            discount = (int)time_diff.TotalMinutes - 300;
                            cost = discount / 10 * 1000;
                            cost += 1000;
                            return cost;
                        }
                }

                cost = (int)time_diff.TotalMinutes / 10 * 1000;
                cost += 1000;
            }

            return cost;
        }
       
        public string purchaseDiscount(string amount)
        {
            string cost="";

            if (amount == "1만원")
            {
                cost = "2hr";
            }

            else if (amount == "3만원")
            {
                cost = "3hr";
            }

            else if (amount == "5만원")
            {
                cost = "4hr";
            }

            else if (amount == "10만원")
            {
                cost = "5hr";
            }

            else
            {
                Console.WriteLine("잘못 입력했습니다.");
            }

            return cost;
        }

    }
}


