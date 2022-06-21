using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tour_Planner_DAL
{
    public class SQLCommands
    {
        public NpgsqlConnection conn;
        public string TournamesSQL = "SELECT * FROM tour_lists";
        public NpgsqlCommand cmd;
        private Database db;

        public SQLCommands()
        {
            if(db == null)
            {
                db = new Database();
            }
            
        }



        private void getTourNames()
        {

        }

        private void addNewTour()
        {

        }

        private void deleteTour()
        {

        }

        //private void 



    }
}
