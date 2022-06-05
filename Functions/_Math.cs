using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Lococo
{
    static class _Math
    {
        /// <summary>
        /// 어떤 두 수의 최대공약수를 구하는 함수입니다.
        /// </summary>
        /// <param name="x">첫번째 수입니다.</param>
        /// <param name="y">두번째 수입니다.</param>
        /// <returns></returns>
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


        /// <summary>
        /// 어떤 숫자가 정수인지, 실수인지 확인합니다.
        /// </summary>
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
