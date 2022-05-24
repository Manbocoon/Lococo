using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lococo
{
    static class _Math
    {
        // 최대공약수 반환
        public static int GetGCD(int x, int y)
        {
            int gcd = 1;

            int max_value = x > y ? x : y;

            for (int i = 1; i <= max_value; ++i)
            {
                if (x % i == 0 && y % i == 0)
                {
                    gcd = i;
                }
            }

            return gcd;
        }


        // 실수인지 정수인지 반환
        public static bool IsInteger(double number)
        {
            bool result = false;

            if ((double)(int)number == number)
            {
                result = true;
            }

            return result;
        }



    }
}
