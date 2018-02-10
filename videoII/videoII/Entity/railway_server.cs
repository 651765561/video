using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace videoII.Entity
{
    /// <summary>
    /// railway_server:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class railway_server
    {
        public railway_server()
        { }
        #region Model
       
        /// <summary>
        /// auto_increment
        /// </summary>
        public int id
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string server_id
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int server_type
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string server_public
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string server_name
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string server_ip
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string server_ip2
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int server_mport
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int server_vport
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int server_maxin
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int server_maxout
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int online
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string access_id
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string vtdu_id
        {
            set;
            get;
        }
        #endregion Model

    }
}
