using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc1
{
    enum CalcState
    {
        Zero,
        AccumulateDigit,
        Compute,
        Result
    }

    class Brain
    {
        MyDelegate displayMsg;
        CalcState calcState = CalcState.Zero;
        string firstNumber;
        string secondNumber;

        public Brain(MyDelegate displayMsg)
        {
            this.displayMsg = displayMsg;
            firstNumber = "";
            secondNumber = "";
        }

        public void Process(string msg)
        {
            switch (calcState)
            {
                case CalcState.Zero:
                    Zero(false, msg);
                    break;
                case CalcState.AccumulateDigit:
                    AccumulateDigit(false, msg);
                    break;
                case CalcState.Compute:
                    break;
                case CalcState.Result:
                    break;
                default:
                    break;
            }
        }

        void Zero(bool isInput, string msg)
        {
            if (isInput)
            {
                calcState = CalcState.Zero;
            }
            else
            {
                if (Rules.IsNonZeroDigit(msg))
                {
                    AccumulateDigit(true, msg);
                }
            }
        }

        void AccumulateDigit(bool isInput, string msg)
        {
            if (isInput)
            {
                calcState = CalcState.AccumulateDigit;
                firstNumber += msg;
                displayMsg.Invoke(firstNumber);
            }
            else
            {
                if (Rules.IsDigit(msg))
                {
                    AccumulateDigit(true, msg);
                }
            }
        }
    }
}
