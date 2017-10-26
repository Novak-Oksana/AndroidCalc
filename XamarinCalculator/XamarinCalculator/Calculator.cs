using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinCalculator
{
    public class Calculator
    {
        private int result = 0;
        private char last_operator = '+';

        public static int funct_calc(int a, int b, char op)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '/':
                    return a / b;
                case '*':
                    return a * b;
            }
            throw new ArgumentException("Illegal operator");
        }

        public void set_last_operator(char op)
        {
            last_operator = op;
        }

        public void calculate(int num)
        {
            result = funct_calc(result, num, last_operator);
        }

        public int get_result()
        {
            return result;
        }

    }
}
