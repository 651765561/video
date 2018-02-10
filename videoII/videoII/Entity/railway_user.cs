using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace videoII.Entity
{
    /// <summary>
    /// railway_user:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class railway_user
    {
        public railway_user()
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
        public int akt_id
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_id
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_name
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_passwd
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string outdate
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime create_time
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string mobile
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string email
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool online
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
        /// <summary>
        /// 
        /// </summary>
        public int role_id
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int organ_id
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int user_pri
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public int used
        {
            set;
            get;
        }
        #endregion Model

    }
}
