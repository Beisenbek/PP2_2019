using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caclulator
{
    class Rules
    {
        public static bool IsDigit(char c)
        {
            char[] arr = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            return arr.Contains(c);
        }
        public static bool IsNonZeroDigit(char c)
        {
            char[] arr = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            return arr.Contains(c);
        }
        public static bool IsZeroDigit(char c)
        {
            char[] arr = new char[] { '0' };
            return arr.Contains(c);
        }
        public static bool IsOperation(char c)
        {
            char[] arr = new char[] { '+', '-'};
            return arr.Contains(c);
        }
        public static bool IsEqualSign(char c)
        {
            char[] arr = new char[] { '=' };
            return arr.Contains(c);
        }
    }
}
