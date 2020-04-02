using System;
namespace WinLineNotifyTCP.Model
{
    /// <summary>linetoken表实体类
    /// 作者:alonso(line:menshin7)
    /// 创建时间:2019-07-28 00:19:52
    //////</summary>
    [Serializable]
    public partial class Linetoken
    {
        public Linetoken()
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
        private string _ChannelName;
		/// <summary>
		/// ChannelName		/// 
///</summary>
		public string ChannelName
        {
            set { _ChannelName = value; }
            get { return _ChannelName; }
        }
        private string _TokenKey;
		/// <summary>
		/// TokenKey		/// 
///</summary>
		public string TokenKey
        {
            set { _TokenKey = value; }
            get { return _TokenKey; }
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
