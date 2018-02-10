using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace videoII.BusinessLogic
{
    public class railway_server
    {
        string MySqlConnString = ConfigurationManager.ConnectionStrings["MySqlConnString"].ToString();

        public string GetServerIP(string deviceId)
        {
            string str = "";
            var m = GetModel(deviceId);
            if (m != null)
            {
                str = m.server_ip;
            }
            return str;
        }
        //
        public Entity.railway_server GetModel(string deviceId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT * FROM railway_server WHERE server_id = (SELECT access_id FROM railway_encoder_info WHERE dev_id = '" + deviceId + "') ");
            MySqlConnection myCon = new MySqlConnection(MySqlConnString);
            MySqlDataAdapter da = new MySqlDataAdapter(strSql.ToString(), myCon);
            DataSet ds = new DataSet();
            da.Fill(ds);
            myCon.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.railway_server DataRowToModel(DataRow row)
        {
            Entity.railway_server model = new Entity.railway_server();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["server_id"] != null)
                {
                    model.server_id = row["server_id"].ToString();
                }
                if (row["server_type"] != null && row["server_type"].ToString() != "")
                {
                    model.server_type = int.Parse(row["server_type"].ToString());
                }
                if (row["server_public"] != null)
                {
                    model.server_public = row["server_public"].ToString();
                }
                if (row["server_name"] != null)
                {
                    model.server_name = row["server_name"].ToString();
                }
                if (row["server_ip"] != null)
                {
                    model.server_ip = row["server_ip"].ToString();
                }
                if (row["server_ip2"] != null)
                {
                    model.server_ip2 = row["server_ip2"].ToString();
                }
                if (row["server_mport"] != null && row["server_mport"].ToString() != "")
                {
                    model.server_mport = int.Parse(row["server_mport"].ToString());
                }
                if (row["server_vport"] != null && row["server_vport"].ToString() != "")
                {
                    model.server_vport = int.Parse(row["server_vport"].ToString());
                }
                if (row["server_maxin"] != null && row["server_maxin"].ToString() != "")
                {
                    model.server_maxin = int.Parse(row["server_maxin"].ToString());
                }
                if (row["server_maxout"] != null && row["server_maxout"].ToString() != "")
                {
                    model.server_maxout = int.Parse(row["server_maxout"].ToString());
                }
                if (row["online"] != null && row["online"].ToString() != "")
                {
                    model.online = int.Parse(row["online"].ToString());
                }
                if (row["access_id"] != null)
                {
                    model.access_id = row["access_id"].ToString();
                }
                if (row["vtdu_id"] != null)
                {
                    model.vtdu_id = row["vtdu_id"].ToString();
                }
            }
            return model;
        }

    }
}
