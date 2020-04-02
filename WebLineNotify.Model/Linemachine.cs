using System;
using System.ComponentModel.DataAnnotations;
namespace WebLineNotify.Model
{
	/// <summary>linemachine表实体类
	/// 作者:alonso(line:menshin7)
	/// 创建时间:2019-07-13 22:29:53
	/// </summary>
	[Serializable]
	public partial class Linemachine
	{
		public Linemachine()
		{}
		private int _Id ;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _Id=value;}
			get{return _Id;}
		}
		private string _MachineNo ;
		/// <summary>
		/// 
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string MachineNo
		{
			set{ _MachineNo=value;}
			get{return _MachineNo;}
		}
		private string _AlertNo ;
		/// <summary>
		/// 
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string AlertNo
		{
			set{ _AlertNo=value;}
			get{return _AlertNo;}
		}
		private string _AlertName ;
		/// <summary>
		/// 
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string AlertName
		{
			set{ _AlertName=value;}
			get{return _AlertName;}
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
