using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLineNotifyTCP.Helper
{
    public class ListItem :IDisposable
    {

        private string _Text;
        private string _Value;

        //根據自己的需求繼續添加 如：private Int32 m_Index；
        //建構式
        public ListItem()
        { }

        public ListItem(string t, string v)
        {
            _Text = t;
            _Value = v;
        }

     

        ~ListItem() {
            
        }


        public void Dispose()
        {
            
            GC.SuppressFinalize(this);
        }

        //設定或取得ListItem的ID
        public string Text
        {
            get
            {
                return this._Text;
            }
            set
            {
                this._Text = value;
            }
        }

        //設定或取得ListItem的Name
        public string Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                this._Value = value;
            }
        }
    }
}
