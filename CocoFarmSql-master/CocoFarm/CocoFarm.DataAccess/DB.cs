using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocoFarm.DataAccess
{
    public sealed class DB
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ZHRConnection"].ToString(); }
        }
    }
}
