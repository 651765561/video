using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace videoII.BusinessLogic
{
    public class railway_user
    {
        string MySqlConnString = ConfigurationManager.ConnectionStrings["MySqlConnString"].ToString();
        public Entity.railway_user GetModelByUser_name(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from railway_user where user_name='" + user_name + "'  ");
            //Maticsoft.Model.railway_user model = new Maticsoft.Model.railway_user();
            //DataSet ds = DbHelperMySQL.Query(strSql.ToString());
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

        public string GetUserID(string user_name)
        {
            string str = "";
            var m = GetModelByUser_name(user_name);
            if (m != null)
            {
                str = m.user_id;
            }
            return str;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.railway_user DataRowToModel(DataRow row)
        {
            Entity.railway_user model = new Entity.railway_user();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["akt_id"] != null && row["akt_id"].ToString() != "")
                {
                    model.akt_id = int.Parse(row["akt_id"].ToString());
                }
                if (row["user_id"] != null)
                {
                    model.user_id = row["user_id"].ToString();
                }
                if (row["user_name"] != null)
                {
                    model.user_name = row["user_name"].ToString();
                }
                if (row["user_passwd"] != null)
                {
                    model.user_passwd = row["user_passwd"].ToString();
                }
                if (row["outdate"] != null)
                {
                    model.outdate = row["outdate"].ToString();
                }
                if (row["create_time"] != null && row["create_time"].ToString() != "")
                {
                    model.create_time = DateTime.Parse(row["create_time"].ToString());
                }
                if (row["mobile"] != null)
                {
                    model.mobile = row["mobile"].ToString();
                }
                if (row["email"] != null)
                {
                    model.email = row["email"].ToString();
                }
                if (row["online"] != null && row["online"].ToString() != "")
                {
                    model.online = bool.Parse(row["online"].ToString());
                }
                if (row["access_id"] != null)
                {
                    model.access_id = row["access_id"].ToString();
                }
                if (row["vtdu_id"] != null)
                {
                    model.vtdu_id = row["vtdu_id"].ToString();
                }
                if (row["role_id"] != null && row["role_id"].ToString() != "")
                {
                    model.role_id = int.Parse(row["role_id"].ToString());
                }
                if (row["organ_id"] != null && row["organ_id"].ToString() != "")
                {
                    model.organ_id = int.Parse(row["organ_id"].ToString());
                }
                if (row["user_pri"] != null && row["user_pri"].ToString() != "")
                {
                    model.user_pri = int.Parse(row["user_pri"].ToString());
                }
                if (row["used"] != null && row["used"].ToString() != "")
                {
                    model.used = int.Parse(row["used"].ToString());
                }
            }
            return model;
        }
    }
}
