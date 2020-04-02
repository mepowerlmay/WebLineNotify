using System;
using System.ComponentModel.DataAnnotations;
namespace WebLineNotify.Model
{
    /// <summary>linenotifymsg表实体类
    /// 作者:alonso(line:menshin7)
    /// 创建时间:2019-07-21 15:32:31
    /// </summary>
    [Serializable]
    public partial class Linenotifymsg
    {
        public Linenotifymsg()
        { }
        private int _Id;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _Id = value; }
            get { return _Id; }
        }
        private string _Title;
        /// <summary>
        /// 
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }
        private string _PLCMsg;
        /// <summary>
        /// 
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PLCMsg
        {
            set { _PLCMsg = value; }
            get { return _PLCMsg; }
        }
        private string _LineMsg;
        /// <summary>
        /// 
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string LineMsg
        {
            set { _LineMsg = value; }
            get { return _LineMsg; }
        }
        private string _Statu;
        /// <summary>
        /// 
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Statu
        {
            set { _Statu = value; }
            get { return _Statu; }
        }
        private DateTime _SendTime;
        /// <summary>
        /// 
        /// </summary>
        public DateTime SendTime
        {
            set { _SendTime = value; }
            get { return _SendTime; }
        }
        private DateTime _CreateTime;
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }
        private string _CreateUser;
        /// <summary>
        /// 
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }
        private DateTime _UpdateTime;
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime
        {
            set { _UpdateTime = value; }
            get { return _UpdateTime; }
        }
        private string _UpdateUser;
        /// <summary>
        /// 
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UpdateUser
        {
            set { _UpdateUser = value; }
            get { return _UpdateUser; }
        }
        private string _IsDelete = "0";
        /// <summary>
        /// 
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string IsDelete
        {
            set { _IsDelete = value; }
            get { return _IsDelete; }
        }
    }
}
