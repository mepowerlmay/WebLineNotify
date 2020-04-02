using System;
namespace WebLineNotify.Model
{
    /// <summary>AlonsoLineNotify表实体类
    /// 作者:alonso(line:menshin7)
    /// 创建时间:2019-06-23 23:22:34
    /// </summary>
    [Serializable]
    public partial class AlonsoLineNotify
    {
        public AlonsoLineNotify()
        { }
        private Guid _Id;
        /// <summary>
        /// 
        /// </summary>
        public Guid Id
        {
            set { _Id = value; }
            get { return _Id; }
        }
        private string _ChannelToken;
        /// <summary>
        /// 
        /// </summary>
        public string ChannelToken
        {
            set { _ChannelToken = value; }
            get { return _ChannelToken; }
        }
        private string _ChannelName;
        /// <summary>
        /// 
        /// </summary>
        public string ChannelName
        {
            set { _ChannelName = value; }
            get { return _ChannelName; }
        }
        private string _Message;
        /// <summary>
        /// 
        /// </summary>
        public string Message
        {
            set { _Message = value; }
            get { return _Message; }
        }
        private DateTime? _SendTime;
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SendTime
        {
            set { _SendTime = value; }
            get { return _SendTime; }
        }
    }
}
