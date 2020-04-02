using System;
using System.ComponentModel.DataAnnotations;
namespace WebLineNotify.Model
{
	/// <summary>linetoken表实体类
	/// 作者:alonso(line:menshin7)
	/// 创建时间:2019-07-13 22:29:53
	/// </summary>
	[Serializable]
	public partial class Linetoken
	{
		public Linetoken()
		{}
		private int _Id ;
		/// <summary>主key
		/// 
		/// </summary>
		public int Id
		{
			set{ _Id=value;}
			get{return _Id;}
		}
		private string _ChannelName ;
		/// <summary>頻道名稱
		/// 
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string ChannelName
		{
			set{ _ChannelName=value;}
			get{return _ChannelName;}
		}
		private string _TokenKey ;
		/// <summary>Line的token
		/// 
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string TokenKey
		{
			set{ _TokenKey=value;}
			get{return _TokenKey;}
		}
		private DateTime _CreateTime ;
		/// <summary>
		/// 
		/// </summary>
		public DateTime CreateTime
		{
			set{ _CreateTime=value;}
			get{return _CreateTime;}
		}
		private string _CreateUser ;
		/// <summary>
		/// 
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string CreateUser
		{
			set{ _CreateUser=value;}
			get{return _CreateUser;}
		}
		private DateTime _UpdateTime ;
		/// <summary>
		/// 
		/// </summary>
		public DateTime UpdateTime
		{
			set{ _UpdateTime=value;}
			get{return _UpdateTime;}
		}
		private string _UpdateUser ;
		/// <summary>
		/// 
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string UpdateUser
		{
			set{ _UpdateUser=value;}
			get{return _UpdateUser;}
		}
        private string _IsDelete = "0";
        /// <summary>
        /// 
        /// </summary>
        [DisplayFormat(ConvertEmptyStringToNull = false)]
		public string IsDelete
		{
			set{ _IsDelete=value;}
			get{return _IsDelete;}
		}
	}
}
