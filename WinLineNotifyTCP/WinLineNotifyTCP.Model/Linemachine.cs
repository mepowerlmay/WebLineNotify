using System;
namespace WinLineNotifyTCP.Model
{
    /// <summary>linemachine表实体类
    /// 作者:alonso(line:menshin7)
    /// 创建时间:2019-08-03 19:29:48
    /// </summary>
    [Serializable]
    public partial class Linemachine
    {
        public Linemachine()
        { }
        private int _Id = 0;
        /// <summary>
        /// Id
        ///  </summary>
        public int Id
        {
            set { _Id = value; }
            get { return _Id; }
        }
        private string _MachineNo;
        /// <summary>
        /// MachineNo
        ///  </summary>
        public string MachineNo
        {
            set { _MachineNo = value; }
            get { return _MachineNo; }
        }
        private string _AlertNo;
        /// <summary>
        /// AlertNo
        ///  </summary>
        public string AlertNo
        {
            set { _AlertNo = value; }
            get { return _AlertNo; }
        }
        private string _AlertName;
        /// <summary>
        /// AlertName
        ///  </summary>
        public string AlertName
        {
            set { _AlertName = value; }
            get { return _AlertName; }
        }
        private string _CreateUser;
        /// <summary>
        /// CreateUser
        ///  </summary>
        public string CreateUser
        {
            set { _CreateUser = value; }
            get { return _CreateUser; }
        }
        private string _CreateTime;
        /// <summary>
        /// CreateTime
        ///  </summary>
        public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }
        private string _UpdateTime;
        /// <summary>
        /// UpdateTime
        ///  </summary>
        public string UpdateTime
        {
            set { _UpdateTime = value; }
            get { return _UpdateTime; }
        }
        private string _UpdateUser;
        /// <summary>
        /// UpdateUser
        ///  </summary>
        public string UpdateUser
        {
            set { _UpdateUser = value; }
            get { return _UpdateUser; }
        }
        private string _IsDelete;
        /// <summary>
        /// IsDelete
        ///  </summary>
        public string IsDelete
        {
            set { _IsDelete = value; }
            get { return _IsDelete; }
        }
    }
}
