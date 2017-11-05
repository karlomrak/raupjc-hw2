using System;
using System.Threading.Tasks;
using static System.Threading.Tasks.Task;

namespace Assignment6_7
{
    public class FactorialSum
    {
        public static async Task<int> FactorialDigitSum(int n)
        {
            return await Run(() =>
            {
                int result = 1;
                for (int i = n; i > 0; i--)
                {
                    result = result * i;
                }
                int sum1 = 0;

                while (result != 0)
                {
                    sum1 = sum1 + result % 10;
                    result = result / 10;
                }
                
                return sum1;
            });
        }
    }
}