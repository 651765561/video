using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace videoII
{
   public class BLLMySql
    {
       string MySqlConnString = ConfigurationManager.ConnectionStrings["MySqlConnString"].ToString();

    }
}
