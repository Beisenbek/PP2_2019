using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc1
{
    class Rules
    {
        public static bool IsOperator(string msg)
        {
            char[] arr = { '+', '-', '*', '/' };
            return arr.Contains(msg[0]);
        }
        public static bool IsEqualSign(string msg)
        {
            char[] arr = { '=' };
            return arr.Contains(msg[0]);
        }
        public static bool IsZero(string msg)
        {
            char[] arr = {'0'};
            return arr.Contains(msg[0]);
        }
        public static bool IsDigit(string msg)
        {
            char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            return arr.Contains(msg[0]);
        }
        public static bool IsNonZeroDigit(string msg)
        {
            char[] arr = {'1', '2', '3', '4', '5', '6', '7', '8', '9' };
            return arr.Contains(msg[0]);
        }
    }
}
