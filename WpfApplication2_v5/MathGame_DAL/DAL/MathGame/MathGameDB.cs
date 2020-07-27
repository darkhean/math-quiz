using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using MathGame_Models.Models;

namespace MathGame_DAL.DAL.MathGame
{
    public class MathGameDB
    {
            public string Name { get; private set; }

            public string ConnectionString { get; private set; }

            public MathGameDB(string name)
            {
                Name = name;
                ConnectionString = ConfigurationManager.AppSettings[Name].ToString();
            }


            public string InsertUserData(RegisterModel res)
            {
                string rtnMsg = string.Empty;
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO login(first_name,last_name,username,email,hash) values(@firstname,@lastname,@username,@email,PASSWORD(@password))";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("@firstname", res.first_name);
                    command.Parameters.AddWithValue("@lastname", res.last_name);
                    command.Parameters.AddWithValue("@email", res.email);
                    command.Parameters.AddWithValue("@username", res.username);
                    command.Parameters.AddWithValue("@password", res.password);
                    //command.Parameters.AddWithValue("@registered_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.ExecuteNonQuery();
                    conn.Close();
                    
                }
                return rtnMsg;
            }

            public string InsertCUserData(GetCUser res)
            {
                string rtnMsg = string.Empty;
                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "REPLACE INTO cuser values(1,@user)";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    //command.Parameters.AddWithValue("@firstname", res.id);
                    command.Parameters.AddWithValue("@user", res.user);
                    //command.Parameters.AddWithValue("@registered_date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.ExecuteNonQuery();  
                    conn.Close();

                }
                return rtnMsg;
            }
            

            public List<RegisterModel> GetUserInformation(string username,string password)
            {
                List<RegisterModel> model = new List<RegisterModel>();

                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    string login = "SELECT * FROM login WHERE username=@username && hash=PASSWORD(@password)";
                    MySqlCommand command = new MySqlCommand(login, conn);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    conn.Open();
                    command.Prepare();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        model.Add(new RegisterModel() { username = reader["username"].ToString(), password = reader["hash"].ToString() });
                    }

                    reader.Close();
                    conn.Close();
                }
                return model;
            }

            public List<RegisterModel> GetCUserInformation(string username, string password)
            {
                List<RegisterModel> model = new List<RegisterModel>();

                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    string login = "SELECT * FROM login WHERE username=@username && hash=@password";
                    MySqlCommand command = new MySqlCommand(login, conn);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    conn.Open();
                    command.Prepare();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        model.Add(new RegisterModel() { username = reader["username"].ToString(), password = reader["hash"].ToString() });
                    }

                    reader.Close();
                    conn.Close();
                }
                return model;
            }

            public string InsertScore(List<ScoreModel> res)
            {
                string rtnMsg = string.Empty;

                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            foreach (var obj in res)
                            {
                                string query = "INSERT INTO leaderboard(name,lvl,score,datetime) values(@name,@lvl,@score,@datetime)";
                                MySqlCommand command = new MySqlCommand(query, conn);
                                //command.Parameters.AddWithValue("@id", obj.id);
                                command.Parameters.AddWithValue("@name", obj.name);
                                command.Parameters.AddWithValue("@lvl", obj.lvl);
                                command.Parameters.AddWithValue("@score", obj.score);
                                command.Parameters.AddWithValue("@datetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                                command.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            rtnMsg = ex.Message.ToString();
                            throw new Exception(ex.Message.ToString());
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                    conn.Close();
                }

                return rtnMsg;
            }

            public List<GetCUser> GetCUser()
            {
                List<GetCUser> model = new List<GetCUser>();

                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    string login = "SELECT * FROM cuser";
                    MySqlCommand command = new MySqlCommand(login, conn);
                    
                    conn.Open();
                    command.Prepare();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        model.Add(new GetCUser() { user = reader["user"].ToString()});
                    }

                    reader.Close();
                    conn.Close();
                }
                return model;
            }
    }
}
