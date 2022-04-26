using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodingTestStudy
{
    // 프로그래머스 스킬 체크 테스트 Level.2
    // 
    // 솔루션
    public class Programmers_Q13
    {
        public static int Solution(int n)
        {
 

            int minBattery = n;

            for (int i = 1; i <= n; i++)
            {
                int moveLocation = i;
                int battery = i;

                while (moveLocation < n)
                {
                    moveLocation *= 2;
                }

                moveLocation = moveLocation / 2;

                int jump = n - moveLocation;
                battery += jump;

                if (minBattery > battery)
                {
                    minBattery = battery;
                }
            }

            return minBattery;
            
        }
    }
}
