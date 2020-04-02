using System;
namespace WinLineNotifyTCP.Model
{
    /// <summary>linenotifymsg表实体类
    /// 作者:alonso(line:menshin7)
    /// 创建时间:2019-07-28 00:19:24
    //////</summary>
    [Serializable]
    public partial class Linenotifymsg
    {
        public Linenotifymsg()
        { }
        private int _Id = 0;
		/// <summary>
		/// Id		/// 
///</summary>
		public int Id
        {
            set { _Id = value; }
            get { return _Id; }
        }
        private string _Title;
		/// <summary>
		/// Title		/// 
///</summary>
		public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }
        private string _PLCMsg;
		/// <summary>
		/// PLCMsg		/// 
///</summary>
		public string PLCMsg
        {
            set { _PLCMsg = value; }
            get { return _PLCMsg; }
        }
        private string _LineMsg;
		/// <summary>
		/// LineMsg		/// 
///</summary>
		public string LineMsg
        {
            set { _LineMsg = value; }
            get { return _LineMsg; }
        }
        private string _Statu;
		/// <summary>
		/// Statu		/// 
///</summary>
		public string Statu
        {
            set { _Statu = value; }
            get { return _Statu; }
        }
        private string _SendTime;
		/// <summary>
		/// SendTime		/// 
///</summary>
		public string SendTime
        {
            set { _SendTime = value; }
            get { return _SendTime; }
        }
        private string _CreateTime;
		/// <summary>
		/// CreateTime		/// 
///</summary>
		public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }
        private string _CreateUser;
		/// <summary>
		/// CreateUser		/// 
///</summary>
		public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }
        private string _UpdateTime;
		/// <summary>
		/// UpdateTime		/// 
///</summary>
		public string UpdateTime
        {
            set { _UpdateTime = value; }
            get { return _UpdateTime; }
        }
        private string _UpdateUser;
		/// <summary>
		/// UpdateUser		/// 
///</summary>
		public string UpdateUser
        {
            set { _UpdateUser = value; }
            get { return _UpdateUser; }
        }
        private string _IsDelete;
		/// <summary>
		/// IsDelete		/// 
///</summary>
		public string IsDelete
        {
            set { _IsDelete = value; }
            get { return _IsDelete; }
        }
    }
}
