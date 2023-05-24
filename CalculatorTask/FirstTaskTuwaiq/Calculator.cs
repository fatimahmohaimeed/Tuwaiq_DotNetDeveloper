using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTaskTuwaiq
{
    public class Calculator
    {

        #region Add
        public int Add(int number1, int number2) 
        { 
            return number1 + number2;
        }
        #endregion

        #region Subtract
        public int Subtract(int number1, int number2) 
        { 
            return number1 - number2;
        }
        #endregion

        #region Multiply
        public int Multiply(int number1,int number2) 
        { 
            return number1 * number2;
        }

        #endregion

        #region Divide
        public int Divide(int number1,int number2) 
        {
            return number1 / number2;
        }
        #endregion

    }
}
