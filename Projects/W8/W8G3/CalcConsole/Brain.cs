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

    public delegate void MyDelegate(string text);

    class Brain
    {
        MyDelegate displayMsg;
        CalcState calcState = CalcState.Zero;
        string tempNumber;
        string resultNumber;
        string operation;

        public Brain(MyDelegate displayMsg)
        {
            this.displayMsg = displayMsg;
            tempNumber = "";
            resultNumber = "";
            operation = "";
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
                    Compute(false, msg);
                    break;
                case CalcState.Result:
                    Result(false, msg);
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
                tempNumber += msg;
                displayMsg(tempNumber);
            }
            else
            {
                if (Rules.IsDigit(msg))
                {
                    AccumulateDigit(true, msg);
                }
                else if (Rules.IsOperator(msg))
                {
                    Compute(true, msg);
                }else if (Rules.IsEqualSign(msg))
                {
                    Result(true, msg);
                }
            }
        }
        void Compute(bool isInput, string msg)
        {
            if (isInput)
            {
                calcState = CalcState.Compute;

                if (operation.Length > 0)
                {
                    Calculate();
                    displayMsg(resultNumber);
                }
                else
                {
                    resultNumber = tempNumber;
                }

                tempNumber = "";
                operation = msg;
            }
            else
            {
                if (Rules.IsDigit(msg))
                {
                    AccumulateDigit(true, msg);
                }
            }
        }
        void Result(bool isInput, string msg)
        {
            if (isInput)
            {
                calcState = CalcState.Result;
                Calculate();
                displayMsg(resultNumber);
            }
            else
            {

                if (Rules.IsNonZeroDigit(msg))
                {
                    AccumulateDigit(true, msg);
                }else if (Rules.IsZero(msg))
                {
                    Zero(true, msg);
                }else if (Rules.IsOperator(msg))
                {
                    operation = "";
                    tempNumber = resultNumber;
                    Compute(true, msg);
                }
            }
        }

        void Calculate()
        {
            if (operation == "+")
            {
                resultNumber = (int.Parse(resultNumber) + int.Parse(tempNumber)).ToString();
            }
            else if (operation == "-")
            {
                resultNumber = (int.Parse(resultNumber) - int.Parse(tempNumber)).ToString();
            }
            else if (operation == "*")
            {
                resultNumber = (int.Parse(resultNumber) * int.Parse(tempNumber)).ToString();
            }
            else if (operation == "/")
            {
                resultNumber = (int.Parse(resultNumber) / int.Parse(tempNumber)).ToString();
            }
        }
    }
}
