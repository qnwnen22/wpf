using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Model;

namespace WPF.Server
{
    public class Service : IService
    {
        private MySqlConnection conn = new MySqlConnection("Server=localhost;Port=3306;;Database=wpf;Uid=moka;Pwd=1234;");
        public string Hello(string name)
        {
            Console.WriteLine($"Hello {name}!");
            return $"Hello {name}!";
        }
        public bool SignIn(Member member)
        {
            string query = $"select * from member where account='{member.account}'";
            try
            {
                conn.Open();
                var mySqlCommand = new MySqlCommand(query, this.conn);
                MySqlDataReader rdr = mySqlCommand.ExecuteReader();
                string result = "";
                while (rdr.Read())
                {
                    result += $"{ rdr["_id"]}, {rdr["account"]}, {rdr["password"]}";
                }
                ;
                rdr.Close();
            }
            catch (MySqlException mySqlException)
            {

            }
            catch (Exception exception)
            {

            }
            finally
            {
                this.conn.Close();
            }
            return true;
        }


        public bool SignUp(Member member)
        {
            throw new NotImplementedException();
        }
    }

}
