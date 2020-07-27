using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathGame_Models.Models;
using MathGame_DAL.DAL.MathGame;

namespace MathGame_BLL.BLL.MathGame
{
    public class MathGameBLL
    {
        public string InsertUserData(RegisterModel Model)
        {
            MathGameDB gameDB = new MathGameDB("GameConnstring");
            return gameDB.InsertUserData(Model);
        }

        public string InsertCUserData(GetCUser Model)
        {
            MathGameDB gameDB = new MathGameDB("GameConnstring");
            return gameDB.InsertCUserData(Model);
        }

        public List<RegisterModel> GetUserInformation(string username,string password)
        {
            MathGameDB gameDB = new MathGameDB("GameConnstring");
            return gameDB.GetUserInformation(username,password);
        }

        public List<GetCUser> GetCUser()
        {
            MathGameDB gameDB = new MathGameDB("GameConnstring");
            return gameDB.GetCUser();
        }

        public string InsertScore(List<ScoreModel>model)
        {
            MathGameDB gameDB = new MathGameDB("GameConnstring");
            return gameDB.InsertScore(model);
        }
    }
}
