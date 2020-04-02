using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLineNotify.Helper
{
    /// <summary>
    /// 的类型转换
    /// 不想每次类型转换都得 int a = 0; int.TryParse(....,out a)
    /// </summary>
    public class TypeChange
    {
        public static DateTime StringToDateTime(string str)
        {

            DateTime dttemp = DateTime.MinValue;
            DateTime.TryParse(str, out dttemp);
            return dttemp;
        }

        /// <summary>
        /// 字符串转为浮点数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="d">默认值0</param>
        /// <returns></returns>
        public static float StringToFloat(string str, float d = 0)
        {
            float.TryParse(str, out d);
            return d;
        }

        /// <summary>
        /// 字符串转为浮点数
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="d">默认值0</param>
        /// <returns></returns>
        public static double StringToDouble(string str, double d = 0)
        {
            double.TryParse(str, out d);
            return d;
        }

        /// <summary>
        /// 字符串转为整型
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="i">默认值0</param>
        /// <returns></returns>
        public static int StringToInt(string str, int i = 0)
        {
            int.TryParse(str, out i);
            return i;
        }
    }
}
