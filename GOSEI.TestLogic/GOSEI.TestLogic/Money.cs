using System;
using System.Collections.Generic;
using System.Text;

namespace GOSEI.TestLogic
{
    class Money
    {
        public int M;
        public int[] valueOfMoney;
        public Money()
        {
            valueOfMoney = new int[9] { 500, 200, 100, 50, 20, 10, 5, 2, 1 };
        }
        public string Solution(int M)
        {
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine(valueOfMoney[i]);
            }
            return "yes";
        }
    }
}
