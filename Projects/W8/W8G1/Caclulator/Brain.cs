using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Caclulator
{
    enum CalcState
    {
        Zero,
        AccumulateDigits,
        Operation,
        Equals
    }
    class Brain
    {
        DisplayTextDelegate textDelegate;
        CalcState calcState = CalcState.Zero;
        string tempNumber = "";
        string resultNumber = "";
        string op = "";
        public Brain(DisplayTextDelegate textDelegate)
        {
            this.textDelegate = textDelegate;
        }
        public void Process(string msg)
        {
            switch (calcState)
            {
                case CalcState.Zero:
                    Zero(msg, false);
                    break;
                case CalcState.AccumulateDigits:
                    AccumulateDigits(msg, false);
                    break;
                case CalcState.Operation:
                    Operation(msg, false);
                    break;
                case CalcState.Equals:
                    break;
                default:
                    break;
            }
        }

        void Zero(string msg, bool isInput)
        {
            if (isInput)
            {
                calcState = CalcState.Zero;
            }
            else
            {
                if (Rules.IsNonZeroDigit(msg[0]))
                {
                    AccumulateDigits(msg, true);
                }
            }
        }

        void AccumulateDigits(string msg, bool isInput)
        {
            if (isInput)
            {
                calcState = CalcState.AccumulateDigits;
                tempNumber = tempNumber + msg;
                textDelegate.Invoke(tempNumber);
            }
            else
            {
                if (Rules.IsDigit(msg[0]))
                {
                    AccumulateDigits(msg, true);
                }else if (Rules.IsOperation(msg[0]))
                {
                    Operation(msg, true);
                }else if (Rules.IsEqualSign(msg[0]))
                {
                    Equals(msg, true);
                }
            }
        }

        void Operation(string msg, bool isInput)
        {
            if (isInput)
            {
                resultNumber = tempNumber;
                tempNumber = "";
                op = msg;
            }
            else
            {
                if (Rules.IsNonZeroDigit(msg[0]))
                {
                    AccumulateDigits(msg, true);
                }
            }
        }
        void Equals(string msg, bool isInput)
        {
            if (isInput)
            {
                if (op == "+")
                {
                    resultNumber = (int.Parse(tempNumber) + int.Parse(resultNumber)).ToString();
                    textDelegate(resultNumber);
                    tempNumber = "";
                    resultNumber = "";
                    op = "";
                }
            }
        }
    }
}
